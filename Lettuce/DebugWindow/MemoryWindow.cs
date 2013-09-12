using System;
using System.Windows.Forms;
using Tomato;
using Tomato.Hardware;

namespace Lettuce
{
	public partial class MemoryWindow : DeviceHostForm
	{
		public MemoryDisplay Stack
		{
			get;
			private set;
		}
		public MemoryDisplay Memory
		{
			get;
			private set;
		}

		public DCPU CPU
		{
			get;
			set;
		}

		public Debugger Debugger
		{
			get;
			set;
		}

		public MemoryWindow()
		{
			InitializeComponent();
			Stack = stackDisplay;
			Memory = rawMemoryDisplay;
		}

		private void MemoryWindow_OnFormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
			Hide();
		}
		private void OnResize( object sender, EventArgs eventArgs )
		{
			rawMemoryDisplay.Invalidate();
			stackDisplay.Invalidate();
		}

		private void resetToolStripMenuItem1_Click( object sender, EventArgs e )
		{
			CPU.Memory = new ushort[0x10000];
			Debugger.ResetLayout();
		}

		private void gotoAddressToolStripMenuItem_Click( object sender, EventArgs e )
		{
			GotoAddress( sender, e );
		}

		public void GotoAddress( object sender, EventArgs e )
		{
			rawMemoryDisplay.gotoAddressToolStripMenuItem_Click( sender, e );
		}

		#region Overrides of DeviceHostForm

		public override Device[] ManagedDevices
		{
			get
			{
				return new Device[] { };
			}
		}

		#endregion
	}
}
