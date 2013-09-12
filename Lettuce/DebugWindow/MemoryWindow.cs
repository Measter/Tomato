using System;
using System.Windows.Forms;
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

		#region Overrides of DeviceHostForm

		public override Device[] ManagedDevices
		{
			get { return new Device[] {}; }
		}

		#endregion
	}
}
