using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lettuce
{
    public partial class MemoryConfiguration : Form
    {
        public bool LittleEndian
        {
            get { return checkBox1.Checked; }
        }

        public string FileName
        {
            get { return textBox1.Text; }
        }

        public MemoryConfiguration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DialogResult = DialogResult.Cancel;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary Files (*.bin)|*.bin|All Files(*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            textBox1.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.lastbinFilepath = textBox1.Text;

            DialogResult = DialogResult.OK;
            Close();
            Program.lastlittleEndian = checkBox1.Checked;
        }
    }
}
