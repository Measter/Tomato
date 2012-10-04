using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tomato.Hardware;
using System.Windows.Forms;

namespace Lettuce
{
    public abstract class DeviceHostForm : Form, IDeviceHost
    {
        public DeviceHostForm()
        {
            this.FormClosing += new FormClosingEventHandler(DeviceHost_FormClosing);
        }

        void DeviceHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public abstract Device[] ManagedDevices { get; }
    }
}
