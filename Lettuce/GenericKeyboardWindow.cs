using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tomato;
using Tomato.Hardware;

namespace Lettuce
{
    public partial class GenericKeyboardWindow : DeviceHost
    {
        private Device[] managedDevices;
        public override Device[] ManagedDevices
        {
            get { return managedDevices; }
        }
        public GenericKeyboard Keyboard;
        public DCPU CPU;

        public GenericKeyboardWindow(GenericKeyboard Keyboard, DCPU CPU) : base()
        {
            InitializeComponent();
            this.CPU = CPU;
            this.Keyboard = Keyboard;
            managedDevices = new Device[] { Keyboard };
            this.KeyDown += new KeyEventHandler(GenericKeyboardWindow_KeyDown);
            this.KeyUp += new KeyEventHandler(GenericKeyboardWindow_KeyUp);
            this.label1.Text = "Generic Keyboard #" + CPU.Devices.IndexOf(Keyboard);
        }

        void GenericKeyboardWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.KeyDown(e.KeyCode);
        }

        void GenericKeyboardWindow_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard.KeyUp(e.KeyCode);
        }
    }
}
