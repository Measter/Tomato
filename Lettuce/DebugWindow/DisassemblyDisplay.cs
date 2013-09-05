using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tomato;
using System.Threading;

namespace Lettuce
{
	public partial class DisassemblyDisplay : UserControl
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
		public ushort EndAddress
		{
			get;
			set;
		}
		private Point MouseLocation;
		private bool IsMouseWithin;

		private Size gutterSize;

		public DisassemblyDisplay()
		{
			this.CPU = new DCPU();
			InitializeComponent();
			this.MouseMove += new MouseEventHandler( DisassemblyDisplay_MouseMove );
			this.MouseEnter += new EventHandler( DisassemblyDisplay_MouseEnter );
			this.MouseLeave += new EventHandler( DisassemblyDisplay_MouseLeave );
			this.MouseDoubleClick += new MouseEventHandler( DisassemblyDisplay_MouseDoubleClick );
			this.KeyDown += new KeyEventHandler( DisassemblyDisplay_KeyDown );
			EnableUpdates = true;
			vScrollBar.Maximum = 65535;

			gutterSize = TextRenderer.MeasureText( "0000: ", Program.MonoFont );
		}

		public DisassemblyDisplay( ref DCPU CPU )
			: this()
		{
			InitializeComponent();
			this.CPU = CPU;
			this.MouseMove += new MouseEventHandler( DisassemblyDisplay_MouseMove );
			this.MouseDoubleClick += new MouseEventHandler( DisassemblyDisplay_MouseDoubleClick );
			EnableUpdates = true;
		}

		void DisassemblyDisplay_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.PageDown )
			{
				SelectedAddress += CPU.InstructionLength( SelectedAddress );
				this.Invalidate();
			} else if( e.KeyCode == Keys.PageUp )
			{
				SelectedAddress--;
				this.Invalidate();
			}
		}

		void DisassemblyDisplay_MouseLeave( object sender, EventArgs e )
		{
			IsMouseWithin = false;
		}

		void DisassemblyDisplay_MouseEnter( object sender, EventArgs e )
		{
			IsMouseWithin = true;
		}

		void DisassemblyDisplay_MouseMove( object sender, MouseEventArgs e )
		{
			MouseLocation = e.Location;
			this.Invalidate();
		}

		protected override void OnMouseWheel( MouseEventArgs e )
		{
			if( ClientRectangle.IntersectsWith( new Rectangle( e.Location, new Size( 1, 1 ) ) ) )
			{
				if( !RuntimeInfo.IsMono )
					( (HandledMouseEventArgs)e ).Handled = true;
				if( e.Delta > 0 )
					SelectedAddress--;
				else if( e.Delta < 0 )
					SelectedAddress += CPU.InstructionLength( SelectedAddress );
				vScrollBar.Value = SelectedAddress;
				this.Invalidate();
				base.OnMouseWheel( e );
			}
		}

		void DisassemblyDisplay_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			Font font = new Font( FontFamily.GenericMonospace, 12 );
			ushort address = SelectedAddress;
			int offset = e.Y / ( TextRenderer.MeasureText( "0000", font ).Height + 2 );
			int index = 0;
			while( offset != 0 )
			{
				if( !Disassembly[index].IsLabel )
					address += CPU.InstructionLength( address );
				index++;
				offset--;
			}
			if( CPU.Breakpoints.Where( b => b.Address == address ).Count() != 0 )
				CPU.Breakpoints.Remove( CPU.Breakpoints.Where( b => b.Address == address ).First() );
			else
				CPU.Breakpoints.Add( new Breakpoint()
				{
					Address = address
				} );
			this.Invalidate();
		}

		static Color[] PriorToPC;
		List<CodeEntry> Disassembly;
		public bool EnableUpdates
		{
			get;
			set;
		}

		private void DisassemblyDisplay_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.FillRectangle( Brushes.White, this.ClientRectangle );
			if( this.DesignMode )
			{
				e.Graphics.DrawRectangle( Pens.Black, new Rectangle( 0, 0, this.Width - 1, this.Height - 1 ) );
				return;
			}

			FastDisassembler disassembler = new FastDisassembler( Debugger.KnownLabels );
			Disassembly = disassembler.FastDisassemble( ref CPU.Memory, SelectedAddress, (ushort)( SelectedAddress + 100 ) );

			int index = 0;
			bool setLast = false, dark = SelectedAddress % 2 == 0;

			Brush yellowBrush = Brushes.Yellow;
			Brush blackBrush = Brushes.Black;
			Brush darkRedBrush = Brushes.DarkRed;
			Brush lightBlueBrush = Brushes.LightBlue;
			Brush greyBrush = Brushes.Gray;
			Brush lightGreyBrush = new SolidBrush( Color.FromArgb( 255, 230, 230, 230 ) );

			for( int y = 0; y < this.Height; y += gutterSize.Height + 2 )
			{
				string address = Debugger.GetHexString( Disassembly[index].Address, 4 ) + ": ";
				Brush foreground = blackBrush;
				if( dark )
					e.Graphics.FillRectangle( lightGreyBrush, new Rectangle( 0, y, this.Width, gutterSize.Height + 2 ) );
				dark = !dark;

				int breakPointCount = CPU.Breakpoints.Where( b => b.Address == Disassembly[index].Address ).Count();

				if( breakPointCount != 0 )
				{
					e.Graphics.FillRectangle( darkRedBrush, new Rectangle( 0, y, this.Width, gutterSize.Height + 2 ) );
					foreground = Brushes.White;
				}
				if( Disassembly[index].Address == CPU.PC )
				{
					if( breakPointCount != 0 )
					{
						if( Disassembly[index].IsLabel )
							e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y + 2, this.Width, gutterSize.Height ) );
						else
						{
							if( index != 0 )
							{
								if( Disassembly[index - 1].IsLabel )
									e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y, this.Width, gutterSize.Height ) );
								else
									e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y + 2, this.Width, gutterSize.Height - 2 ) );
							} else
								e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y + 2, this.Width, gutterSize.Height - 2 ) );
						}
					} else
						e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y, this.Width, gutterSize.Height + 2 ) );
					foreground = blackBrush;
				}

				e.Graphics.DrawString( address, Program.MonoFont, greyBrush, 2, y );

				if( !Debugger.KnownCode.ContainsKey( Disassembly[index].Address ) || Disassembly[index].IsLabel )
					e.Graphics.DrawString( Disassembly[index].Code, Program.MonoFont, foreground, 2 + gutterSize.Width + 3, y );
				else
					e.Graphics.DrawString( Debugger.KnownCode[Disassembly[index].Address], Program.MonoFont, foreground,
						2 + gutterSize.Width + 3, y );

				if( y + gutterSize.Height > this.Height )
				{
					setLast = true;
					EndAddress = Disassembly[index].Address;
				}

				index++;
			}
			if( !setLast )
				EndAddress = Disassembly[index--].Address;
			index = 0;
			if( IsMouseWithin && !CPU.IsRunning ) // TODO: Make this more versatile, probably integrate with organic
			{
				int x = MouseLocation.X;
				for( int y = 0; y < this.Height; y += gutterSize.Height + 2 )
				{
					if( Disassembly[index].IsLabel || Disassembly[index].Code.StartsWith( "DAT" ) )
					{
						index++;
						continue;
					}
					Size size = TextRenderer.MeasureText( "0000: " + Disassembly[index].Code, Program.MonoFont );
					size.Width += 12;
					Rectangle textRect = new Rectangle( new Point( 0, y ), size );
					Rectangle mouseRect = new Rectangle( new Point( x, MouseLocation.Y ), new Size( 1, 1 ) );
					if( textRect.IntersectsWith( mouseRect ) )
					{
						ushort oldPC = CPU.PC;
						ushort oldSP = CPU.SP;
						CPU.PC = (ushort)( Disassembly[index].Address + 1 );
						int right, left;
						ushort valueAcalc = CPU.Get( Disassembly[index].ValueA );
						ushort valueBcalc = CPU.Get( Disassembly[index].ValueB );
						if( Disassembly[index].Opcode == 0 )
						{
							left = int.MaxValue;
							right = TextRenderer.MeasureText( "0000: " + Disassembly[index].OpcodeText + " ", Program.MonoFont ).Width + 8;
						} else
						{
							left = TextRenderer.MeasureText( "0000: " + Disassembly[index].OpcodeText + " ", Program.MonoFont ).Width + 7;
							right = left + TextRenderer.MeasureText( Disassembly[index].ValueBText, Program.MonoFont ).Width;
						}
						if( x >= left && x <= right )
						{
							// hovering over value B
							if( Disassembly[index].ValueB <= 0x1E )
							{
								e.Graphics.FillRectangle( lightBlueBrush, new Rectangle( new Point( left, y ),
									TextRenderer.MeasureText( Disassembly[index].ValueBText, Program.MonoFont ) ) );
								e.Graphics.DrawString( Disassembly[index].ValueBText, Program.MonoFont, blackBrush, new PointF( left, y ) );
								int locationY = y + size.Height;
								if( this.Height / 2 < y )
									locationY = y - size.Height;
								string text = Disassembly[index].ValueBText + " = 0x" + Debugger.GetHexString( valueBcalc, 4 );
								Size hoverSize = TextRenderer.MeasureText( text, Program.MonoFont );
								hoverSize.Width += 3;
								e.Graphics.FillRectangle( lightBlueBrush, new Rectangle( new Point(
									( left + ( TextRenderer.MeasureText( Disassembly[index].ValueBText, Program.MonoFont ).Width / 2 ) ) -
									( hoverSize.Width / 2 ), locationY ), hoverSize ) );
								e.Graphics.DrawString( text, Program.MonoFont, blackBrush, new Point(
									( left + ( TextRenderer.MeasureText( Disassembly[index].ValueBText, Program.MonoFont ).Width / 2 ) ) -
									( hoverSize.Width / 2 ), locationY ) );
							}
						} else if( x >= right+8 )
						{
							// hovering over value A
							if( Disassembly[index].ValueA <= 0x1E )
							{
								e.Graphics.FillRectangle( lightBlueBrush, new Rectangle( new Point( right + 8, y ),
									TextRenderer.MeasureText( Disassembly[index].ValueAText, Program.MonoFont ) ) );
								e.Graphics.DrawString( Disassembly[index].ValueAText, Program.MonoFont, blackBrush, new PointF( right + 8, y ) );
								int locationY = y + size.Height;
								if( this.Height / 2 < y )
									locationY = y - size.Height;
								string text = Disassembly[index].ValueAText + " = 0x" + Debugger.GetHexString( valueAcalc, 4 );
								Size hoverSize = TextRenderer.MeasureText( text, Program.MonoFont );
								e.Graphics.FillRectangle( lightBlueBrush, new Rectangle( new Point(
									( right + 8 + ( TextRenderer.MeasureText( Disassembly[index].ValueAText, Program.MonoFont ).Width / 2 ) ) -
									( hoverSize.Width / 2 ), locationY ), hoverSize ) );
								e.Graphics.DrawString( text, Program.MonoFont, blackBrush, new Point(
									( right + 8 + ( TextRenderer.MeasureText( Disassembly[index].ValueAText, Program.MonoFont ).Width / 2 ) ) -
									( hoverSize.Width / 2 ), locationY ) );
							}
						}
						CPU.PC = oldPC;
						CPU.SP = oldSP;
						break;
					}
					index++;
				}
			}
			e.Graphics.DrawRectangle( Pens.Black, new Rectangle( 0, 0, this.Width - 1 - vScrollBar.Width, this.Height - 1 ) );
		}

		private void gotoAddressToolStripMenuItem_Click( object sender, EventArgs e )
		{
			GoToAddressForm gtaf = new GoToAddressForm( SelectedAddress );
			if( gtaf.ShowDialog() == DialogResult.OK )
			{
				SelectedAddress = gtaf.Value;
				this.Invalidate();
			}
		}

		private void setPCToAddressToolStripMenuItem_Click( object sender, EventArgs e )
		{
			ushort address = SelectedAddress;
			int offset = MouseLocation.Y / ( TextRenderer.MeasureText( "0", Program.MonoFont ).Height + 2 );
			int index = 0;
			while( offset != 0 )
			{
				if( !Disassembly[index].IsLabel )
					address += CPU.InstructionLength( address );
				index++;
				offset--;
			}
			CPU.PC = address;
			this.Invalidate();
		}

		private void vScrollBar1_Scroll( object sender, ScrollEventArgs e )
		{
			if( e.Type == ScrollEventType.EndScroll )
				return;
			if( e.Type == ScrollEventType.SmallDecrement )
				SelectedAddress--;
			else if( e.Type == ScrollEventType.SmallIncrement )
				SelectedAddress += CPU.InstructionLength( SelectedAddress );
			else
				SelectedAddress = (ushort)vScrollBar.Value;
			vScrollBar.Value = SelectedAddress;
			this.Invalidate();
		}
	}
}
