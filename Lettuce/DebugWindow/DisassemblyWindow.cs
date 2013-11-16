using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Tomato;
using Tomato.Hardware;

namespace Lettuce
{
	public partial class DisassemblyWindow : Form
	{
		public DCPU CPU { get; set; }
		public Debugger Debugger { get; set; }
		
		public DisassemblyDisplay Disassembly
		{
			get;
			private set;
		}

		public DisassemblyWindow()
		{
			InitializeComponent();
			Disassembly = disassemblyDisplay1;
			disassemblyDisplay1.KeyDown += OnKeyDown;

			if( Program.Configuration.WindowSizes.ContainsKey( "disWindow" ) )
				this.Size = Program.Configuration.WindowSizes["disWindow"];
			if( Program.Configuration.WindowPositions.ContainsKey( "disWindow" ) )
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Location = Program.Configuration.WindowPositions["disWindow"];
			}
		}

		private void DisassemblyWindow_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
			Hide();
			Program.Configuration.WindowSizes["disWindow"] = this.Size;
			Program.Configuration.WindowPositions["disWindow"] = this.Location;
		}
		private void OnResize( object sender, EventArgs eventArgs )
		{
			disassemblyDisplay1.Invalidate();
		}

		private void OnKeyDown( object sender, KeyEventArgs e )
		{
			foreach ( var keybinding in Program.Configuration.Keybindings )
			{
				if ( e.KeyCode == keybinding.Value.Item1 && e.Modifiers == keybinding.Value.Item2 )
				{
					switch ( keybinding.Key )
					{
						case Debugger.FUNC_STEP_INTO:
							StepIntoToolStripMenuItemOnClick( sender, e );
							break;
						case Debugger.FUNC_STEP_OVER:
							StepOverToolStripMenuItemOnClick( sender, e );
							break;
						case Debugger.FUNC_CHANGE_RUNNING:
							Debugger.ToggleRunning();
							break;
						case Debugger.FUNC_GOTO_ADDRESS:
							Debugger.GotoAddress( sender, e );
							break;
					}
				}
			}
		}

		private void StepIntoToolStripMenuItemOnClick( object sender, EventArgs eventArgs )
		{
			CPU.Execute( -1 );
			Debugger.ResetLayout();
		}	
		private void StepOverToolStripMenuItemOnClick( object sender, EventArgs eventArgs )
		{
			Debugger.StepOver();
		}
		private void LoadListingToolStripMenuItemOnClick( object sender, EventArgs eventArgs )
		{
			//Load organic listing
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Listing files (*.lst)|*.lst|Text files (*.txt)|*.txt|All files (*.*)|*.*";
			ofd.FileName = "";
			if ( ofd.ShowDialog() != DialogResult.OK )
				return;
			Debugger.LoadOrganicListing( ofd.FileName );
			Program.lastlistingFilepath = ofd.FileName;
			Debugger.ResetLayout();
		}
		private void DefineValueToolStripMenuItemOnClick( object sender, EventArgs eventArgs )
		{
			DefineValueForm dvf = new DefineValueForm();
			var res = dvf.ShowDialog();
			if ( res == DialogResult.OK && !Debugger.KnownLabels.ContainsKey( dvf.Value ) )
				Debugger.KnownLabels.Add( dvf.Value, dvf.Name );
		}
		private void ReloadToolStripMenuItemOnClick( object sender, EventArgs eventArgs )
		{
			CPU.Reset();
			CPU.Memory = new ushort[0x10000];

			//Load binary file
			List<ushort> data = new List<ushort>();
			if ( !string.IsNullOrEmpty( Lettuce.Program.lastbinFilepath ) )
			{
				using ( Stream stream = File.OpenRead( Lettuce.Program.lastbinFilepath ) )
				{
					for ( int i = 0; i < stream.Length; i+=2 )
					{
						byte a = (byte)stream.ReadByte();
						byte b = (byte)stream.ReadByte();
						if ( Lettuce.Program.lastlittleEndian )
							data.Add( (ushort)( a | ( b << 8 ) ) );
						else
							data.Add( (ushort)( b | ( a << 8 ) ) );
					}
				}
			}
			Lettuce.Program.CPU.FlashMemory( data.ToArray() );
			Debugger.KnownCode = new Dictionary<ushort, string>();
			Debugger.KnownLabels = new Dictionary<ushort, string>();
			Debugger.ResetLayout();
		}

		private void DisassemblyWindow_Shown( object sender, EventArgs e )
		{
			this.Icon = Debugger.Icon;
		}

	}
}
