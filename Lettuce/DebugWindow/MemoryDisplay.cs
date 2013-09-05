using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tomato;
using System.Globalization;

namespace Lettuce
{
	public partial class MemoryDisplay : UserControl
	{
		public ushort SelectedAddress
		{
			get;
			set;
		}
		public DCPU CPU
		{
			get;
			set;
		}
		private ushort wordsWide;
		private Point MouseLocation;
		public bool AsStack
		{
			get;
			set;
		}
		public bool DisplayScrollBar
		{
			get
			{
				return vScrollBar.Visible;
			}
			set
			{
				vScrollBar.Visible = value;
			}
		}

		private Size cellSize;
		private Size gutterSize;

		public MemoryDisplay()
		{
			AsStack = false;
			this.CPU = new DCPU();

			cellSize = TextRenderer.MeasureText( "0000", Program.MonoFont );
			gutterSize = TextRenderer.MeasureText( "0000:", Program.MonoFont );

			InitializeComponent();
			wordsWide = 8;
			this.MouseMove += new MouseEventHandler( MemoryDisplay_MouseMove );
			this.KeyDown += new KeyEventHandler( MemoryDisplay_KeyDown );
		}

		public MemoryDisplay( ref DCPU cpu )
		{
			AsStack = false;
			cellSize = TextRenderer.MeasureText( "0000", Program.MonoFont );
			gutterSize = TextRenderer.MeasureText( "0000:", Program.MonoFont );

			InitializeComponent();
			this.CPU = cpu;
			wordsWide = 8;
		}

		void MemoryDisplay_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.PageDown )
			{
				SelectedAddress += wordsWide;
				this.Invalidate();
			} else if( e.KeyCode == Keys.PageUp )
			{
				SelectedAddress -= wordsWide;
				this.Invalidate();
			}
		}

		void MemoryDisplay_MouseMove( object sender, MouseEventArgs e )
		{
			MouseLocation = e.Location;
		}

		protected override void OnMouseWheel( MouseEventArgs e )
		{
			if( !RuntimeInfo.IsMono )
				( (HandledMouseEventArgs)e ).Handled = true;
			int delta = e.Delta;
			if( delta > 0 )
				SelectedAddress -= wordsWide;
			else if( delta < 0 )
				SelectedAddress += wordsWide;
			vScrollBar.Value = SelectedAddress / wordsWide;
			this.Invalidate();
			base.OnMouseWheel( e );
		}

		private void MemoryDisplay_Paint( object sender, PaintEventArgs e )
		{
			if( wordsWide <= 0 )
				return;

			bool dark = (int)( SelectedAddress / wordsWide ) % 2 == 0;
			int Width = this.Width;
			if( DisplayScrollBar )
				Width -= vScrollBar.Width;

			Brush greyBrush = Brushes.Gray;
			Brush blackBrush = Brushes.Black;
			Brush blueBrush = Brushes.LightBlue;
			Pen blackPen = Pens.Black;
			SolidBrush lightGreyBrush = new SolidBrush( Color.FromArgb( 255, 230, 230, 230 ) );

			e.Graphics.FillRectangle( Brushes.White, this.ClientRectangle );
			ushort address = SelectedAddress;
			for( int y = 0; y < this.Height; y += cellSize.Height + 2 )
			{
				if( dark )
					e.Graphics.FillRectangle( lightGreyBrush, 0, y, Width, cellSize.Height );
				dark = !dark;

				e.Graphics.DrawString( Debugger.GetHexString( address, 4 ) + ":", Program.MonoFont, greyBrush, 2, y );
				wordsWide = 0;
				for( int x = 4 + gutterSize.Width; x < Width; )
				{
					string value = Debugger.GetHexString( CPU.Memory[address], 4 );
					if( x + cellSize.Width < Width )
					{
						if( CPU.SP == address && AsStack )
							e.Graphics.FillRectangle( blueBrush, new Rectangle( x, y, cellSize.Width - 4, cellSize.Height - 1 ) );
						if( outlinedAddress == address && !AsStack )
							e.Graphics.DrawRectangle( blackPen, new Rectangle( x, y, cellSize.Width - 4, cellSize.Height - 1 ) );
						e.Graphics.DrawString( value, Program.MonoFont, blackBrush, x, y );
						address++;
						wordsWide++;
					}
					x += cellSize.Width;
				}
			}
			e.Graphics.DrawRectangle( blackPen, new Rectangle( 0, 0, Width - 1, this.Height - 1 ) );
			if( wordsWide > 0 )
				vScrollBar.Maximum = 65535 / wordsWide;
		}

		TextBox textBox;

		private void MemoryDisplay_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			if( this.Controls.Contains( textBox ) )
				this.Controls.Remove( textBox );
			Size cell = cellSize;
			Size gutter = gutterSize;
			gutter.Width += 2;
			cell.Height += 2;
			if( e.X > gutter.Width )
			{
				textBox = new TextBox();
				ushort address = (ushort)(
					( e.Y / cell.Height ) * wordsWide +
					( ( e.X - gutter.Width ) / cell.Width )
					+ SelectedAddress );
				textBox.Tag = address;
				textBox.KeyDown += textBoxRegisterX_KeyDown;
				textBox.Location = new Point(
					( ( e.X - gutter.Width ) / cell.Width ) * cell.Width + gutter.Width,
					e.Y / cell.Height * cell.Height );
				textBox.Text = Debugger.GetHexString( CPU.Memory[address], 4 );
				textBox.Size = cell;
				textBox.MaxLength = 4;
				this.Controls.Add( textBox );
			}
		}

		private void textBoxRegisterX_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.Control || e.Alt )
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}
			if( e.KeyCode == Keys.Enter )
			{
				this.Controls.Remove( textBox );
				ushort address = (ushort)textBox.Tag;
				CPU.Memory[address] = ushort.Parse( textBox.Text, NumberStyles.HexNumber );
				this.Invalidate();
				return;
			}
			if( e.KeyCode == Keys.D1 ||
				e.KeyCode == Keys.D2 ||
				e.KeyCode == Keys.D3 ||
				e.KeyCode == Keys.D4 ||
				e.KeyCode == Keys.D5 ||
				e.KeyCode == Keys.D6 ||
				e.KeyCode == Keys.D7 ||
				e.KeyCode == Keys.D8 ||
				e.KeyCode == Keys.D9 ||
				e.KeyCode == Keys.D0 ||
				e.KeyCode == Keys.NumPad1 ||
				e.KeyCode == Keys.NumPad2 ||
				e.KeyCode == Keys.NumPad3 ||
				e.KeyCode == Keys.NumPad4 ||
				e.KeyCode == Keys.NumPad5 ||
				e.KeyCode == Keys.NumPad6 ||
				e.KeyCode == Keys.NumPad7 ||
				e.KeyCode == Keys.NumPad8 ||
				e.KeyCode == Keys.NumPad9 ||
				e.KeyCode == Keys.NumPad0 ||
				e.KeyCode == Keys.A ||
				e.KeyCode == Keys.B ||
				e.KeyCode == Keys.C ||
				e.KeyCode == Keys.D ||
				e.KeyCode == Keys.E ||
				e.KeyCode == Keys.F ||
				e.KeyCode == Keys.Back ||
				e.KeyCode == Keys.Delete ||
				e.KeyCode == Keys.Left ||
				e.KeyCode == Keys.Right )
			{
				return;
			}
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		private ushort outlinedAddress = 0;
		private void MemoryDisplay_MouseClick( object sender, MouseEventArgs e )
		{
			if( this.Controls.Contains( textBox ) )
				this.Controls.Remove( textBox );

			Size cell = cellSize;
			Size gutter = gutterSize;
			gutter.Width += 2;
			cell.Height += 2;
			outlinedAddress = (ushort)(
				( e.Y / cell.Height ) * wordsWide +
				( ( e.X - gutter.Width ) / cell.Width )
				+ SelectedAddress );
			this.Invalidate();
		}

		private void editValueToolStripMenuItem_Click( object sender, EventArgs e )
		{
			MemoryDisplay_MouseDoubleClick( sender, new MouseEventArgs( MouseButtons.Left, 2, MouseLocation.X, MouseLocation.Y, 0 ) );
		}

		private void contextMenuStrip1_Opening( object sender, CancelEventArgs e )
		{
			MemoryDisplay_MouseClick( sender, new MouseEventArgs( MouseButtons.Left, 2, MouseLocation.X, MouseLocation.Y, 0 ) );
		}

		public void gotoAddressToolStripMenuItem_Click( object sender, EventArgs e )
		{
			GoToAddressForm gtaf = new GoToAddressForm( SelectedAddress );
			gtaf.ShowDialog();
			SelectedAddress = gtaf.Value;
			this.Invalidate();
		}

		private void vScrollBar_Scroll( object sender, ScrollEventArgs e )
		{
			SelectedAddress = (ushort)( vScrollBar.Value * wordsWide );
			this.Invalidate();
		}
	}
}
