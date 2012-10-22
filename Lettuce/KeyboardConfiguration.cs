using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lettuce.Config;

namespace Lettuce
{
    public partial class KeyboardConfiguration : Form
    {
        private Dictionary<string, Tuple<Keys, Keys>> _bindings;

        public KeyboardConfiguration()
        {
            InitializeComponent();

            _bindings = Program.Configuration.Keybindings;

            txtStepInto.Tag = Debugger.FUNC_STEP_INTO;
            txtStepOver.Tag = Debugger.FUNC_STEP_OVER;
            txtChangeRunning.Tag = Debugger.FUNC_CHANGE_RUNNING;
            txtGotoAddr.Tag = Debugger.FUNC_GOTO_ADDRESS;

            foreach (var txt in this.Controls.OfType<TextBox>())
            {
                txt.KeyDown += TxtOnKeyDown;
                txt.Text = _bindings[txt.Tag.ToString()].Item1 + " + " + _bindings[txt.Tag.ToString()].Item2;
            }
        }

        private void TxtOnKeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            _bindings[txt.Tag.ToString()] = new Tuple<Keys, Keys>(e.KeyCode, e.Modifiers);
            txt.Text = e.KeyCode.ToString() + " + " + e.Modifiers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.Configuration.Keybindings = _bindings;
            ConfigurationManager.SaveConfiguration(Program.Configuration, Program.ConfigFilePath);
            this.Close();
        }
    }
}
