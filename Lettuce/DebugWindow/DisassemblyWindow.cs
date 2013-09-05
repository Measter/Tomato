using System.ComponentModel;
using System.Windows.Forms;
using Tomato.Hardware;

namespace Lettuce
{
	public partial class DisassemblyWindow : DeviceHostForm
	{
		public DisassemblyDisplay Disassembly
		{
			get;
			private set;
		}

		public DisassemblyWindow()
		{
			InitializeComponent();
			Disassembly = disassemblyDisplay1;
		}

		private void DisassemblyWindow_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
			Hide();
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
