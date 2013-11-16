using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tomato;
using Tomato.Hardware;

namespace Lettuce
{
	public partial class HardwareWindow : Form
	{
		public ListBox ConnectedDevices
		{
			get;
			private set;
		}
		public PropertyGrid PropertyGrid
		{
			get;
			private set;
		}
		public CheckBox BreakOnInterrupt
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
		public List<bool> InterruptBreakDevices
		{
			get;
			set;
		}

		public HardwareWindow()
		{
			InitializeComponent();
			ConnectedDevices = listBoxConnectedDevices;
			PropertyGrid = propertyGrid1;
			BreakOnInterrupt = checkBoxBreakOnInterrupt;

			if( Program.Configuration.WindowSizes.ContainsKey( "hardWindow" ) )
				this.Size = Program.Configuration.WindowSizes["hardWindow"];
			if( Program.Configuration.WindowPositions.ContainsKey( "hardWindow" ) )
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Location = Program.Configuration.WindowPositions["hardWindow"];
			}
		}

		private void Hardware_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
			Hide();
			Program.Configuration.WindowSizes["hardWindow"] = this.Size;
			Program.Configuration.WindowPositions["hardWindow"] = this.Location;
		}

		private void ListBoxConnectedDevicesOnSelectedIndexChanged( object sender, EventArgs eventArgs )
		{
			checkBoxBreakOnInterrupt.Enabled = ( listBoxConnectedDevices.SelectedIndex != -1 );
			if( listBoxConnectedDevices.SelectedIndex == -1 )
				return;
			Device selected = CPU.Devices[listBoxConnectedDevices.SelectedIndex];
			propertyGrid1.SelectedObject = selected;
			checkBoxBreakOnInterrupt.Checked = InterruptBreakDevices[listBoxConnectedDevices.SelectedIndex];
		}

		private void ListBoxConnectedDevicesOnMouseDoubleClick( object sender, MouseEventArgs mouseEventArgs )
		{
			Device selected = (Device)propertyGrid1.SelectedObject;
			if( selected != null && Lettuce.Program.Windows.ContainsKey( selected ) )
			{
				Form window = Lettuce.Program.Windows[selected];
				window.Show();
				window.BringToFront();
				window.Focus();
			}
		}

		private void CheckBoxBreakOnInterruptOnCheckedChanged( object sender, EventArgs eventArgs )
		{
			InterruptBreakDevices[listBoxConnectedDevices.SelectedIndex] = checkBoxBreakOnInterrupt.Checked;
		}

		private void PropertyGrid1OnPropertyValueChanged( object o, PropertyValueChangedEventArgs e )
		{
			CPU.IsRunning = false;
			Debugger.ResetLayout();
		}

		private void HardwareWindow_Shown( object sender, EventArgs e )
		{
			this.Icon = Debugger.Icon;
		}
	}
}
