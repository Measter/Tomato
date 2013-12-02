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
			ushort address = SelectedAddress;
			int offset = e.Y / ( gutterSize.Height + 2 );
			int index = 0;
			while( offset != 0 )
			{
				if( !Disassembly[index].IsLabel )
					address += CPU.InstructionLength( address );
				index++;
				offset--;
			}
			if( CPU.Breakpoints.Any( b => b.Address == address ) )
				CPU.Breakpoints.Remove( CPU.Breakpoints.First(b => b.Address == address) );
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

			ushort disNum = (ushort)( this.Height / ( gutterSize.Height + 2 ) + 1 );
			disNum *= 2;

			FastDisassembler disassembler = new FastDisassembler( Debugger.KnownLabels );
			Disassembly = disassembler.FastDisassemble( ref CPU.Memory, SelectedAddress, (ushort)( SelectedAddress + disNum ) );

			int index = 0;
			bool setLast = false, dark = SelectedAddress%2 == 0, hasBroke = false;

			Brush yellowBrush = Brushes.Yellow;
			Brush blackBrush = Brushes.Black;
			Brush darkRedBrush = Brushes.DarkRed;
			Brush lightBlueBrush = Brushes.LightBlue;
			Brush greyBrush = Brushes.Gray;
			Brush lightGreyBrush = new SolidBrush( Color.FromArgb( 255, 230, 230, 230 ) );

			#region Draw Loop
			for( int y = 0; y < this.Height; y += gutterSize.Height + 2 )
			{
				if( index == Disassembly.Count )
				{
					hasBroke = true;
					break;
				}

				string address = Debugger.GetHexString( Disassembly[index].Address, 4 ) + ": ";
				Brush foreground = blackBrush;
				
				bool isBreakPoint = CPU.Breakpoints.Any( b => b.Address == Disassembly[index].Address );
				if( isBreakPoint )
				{
					e.Graphics.FillRectangle( darkRedBrush, new Rectangle( 0, y, this.Width, gutterSize.Height + 2 ) );
					foreground = Brushes.White;
				} else if ( dark )
					e.Graphics.FillRectangle( lightGreyBrush, new Rectangle( 0, y, this.Width, gutterSize.Height + 2 ) );
				dark = !dark;
					
				if( Disassembly[index].Address == CPU.PC )
				{
					if( isBreakPoint )
					{
						if( Disassembly[index].IsLabel )
							e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y + 2, this.Width, gutterSize.Height ) );
						else
						{
							if( index != 0 && Disassembly[index - 1].IsLabel )
								e.Graphics.FillRectangle( yellowBrush, new Rectangle( 0, y, this.Width, gutterSize.Height ) );
							else
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
			#endregion
			if( !setLast && hasBroke )
				EndAddress = Disassembly[Disassembly.Count - 1].Address;
			else if( !setLast )
				EndAddress = Disassembly[index--].Address;
			index = 0;
			hasBroke = false;
			#region Mouse Over
			if( IsMouseWithin && !CPU.IsRunning ) // TODO: Make this more versatile, probably integrate with organic
			{
				int x = MouseLocation.X;
				List<string> tooltipLines = new List<string>();
				int len = this.Width;
				for( int y = 0; y < this.Height; y += gutterSize.Height + 2 )
				{
					if( index == Disassembly.Count )
					{
						hasBroke = true;
						break;
					}

					if( Disassembly[index].IsLabel || Disassembly[index].Code.StartsWith( "DAT" ) )
					{
						index++;
						continue;
					}

					string dispCode;
					if ( !Debugger.KnownCode.ContainsKey( Disassembly[index].Address ) || Disassembly[index].IsLabel )
						dispCode = Disassembly[index].Code;
					else
						dispCode = Debugger.KnownCode[Disassembly[index].Address];

					Size size = new Size( this.Width, gutterSize.Height + 2 );
					Rectangle textRect = new Rectangle( new Point( gutterSize.Width+3, y ), size );
					Rectangle mouseRect = new Rectangle( new Point( x, MouseLocation.Y ), new Size( 1, 1 ) );
					if( textRect.IntersectsWith( mouseRect ) )
					{
						ushort oldPC = CPU.PC;
						ushort oldSP = CPU.SP;
						CPU.PC = (ushort)( Disassembly[index].Address + 1 );
						ushort valueAcalc = CPU.Get( Disassembly[index].ValueA );
						ushort valueBcalc = CPU.Get( Disassembly[index].ValueB );

						// Highlight line.
						e.Graphics.FillRectangle( lightBlueBrush, gutterSize.Width + 3, y, len, size.Height );

						if( !Debugger.KnownCode.ContainsKey( Disassembly[index].Address ) || Disassembly[index].IsLabel )
							e.Graphics.DrawString( dispCode, Program.MonoFont, blackBrush, 2 + gutterSize.Width + 3, y );
						else
							e.Graphics.DrawString( dispCode, Program.MonoFont, blackBrush, 2 + gutterSize.Width + 3, y );

						// Calculate height of box.
						int locY = y + size.Height;
						int sizeY;
						if ( Disassembly[index].Opcode == 0 )
							sizeY = gutterSize.Height;
						else
							sizeY = gutterSize.Height*2;
						if ( ( locY + sizeY ) > this.Height )
							locY = y - gutterSize.Height*2;

						// Value B.
						tooltipLines.Add( Disassembly[index].ValueBText + " = 0x" + Debugger.GetHexString( valueBcalc, 4 ) );
						// Value A.
						if ( Disassembly[index].Opcode != 0 )
							tooltipLines.Add( Disassembly[index].ValueAText + " = 0x" + Debugger.GetHexString( valueAcalc, 4 ) );

						e.Graphics.FillRectangle( lightBlueBrush, gutterSize.Width + 3, locY, len, sizeY );

						for ( int i = 0; i < tooltipLines.Count; i++ )
						{
							e.Graphics.DrawString( tooltipLines[i], Program.MonoFont, blackBrush,
							                       new PointF( 2 + gutterSize.Width + 3, locY + ( gutterSize.Height*i ) ) );
						}
						CPU.PC = oldPC;
						CPU.SP = oldSP;
						break;
					}
					index++;
				}
			} 
			#endregion
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
			int offset = MouseLocation.Y / ( gutterSize.Height + 2 );
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
