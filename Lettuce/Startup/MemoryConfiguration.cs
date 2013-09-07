using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lettuce
{
	public partial class MemoryConfiguration : Form
	{
		public bool LittleEndian
		{
			get
			{
				return cbLittleEndian.Checked;
			}
		}

		public string BinName
		{
			get {
				return File.Exists( tbListFile.Text ) ? tbBinFile.Text : null;
			}
		}

		public string ListName
		{
			get
			{
				return File.Exists( tbListFile.Text ) ? tbListFile.Text : null;
			}
		}

		public MemoryConfiguration()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			DialogResult = DialogResult.Cancel;
		}

		private void btnOpenBin_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Binary Files (*.bin)|*.bin|All Files(*.*)|*.*";
			if( ofd.ShowDialog() != DialogResult.OK )
				return;
			tbBinFile.Text = ofd.FileName;
		}

		private void btnOpenList_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Listing Files (*.lst)|*.lst|All Files (*.*)|*.*";
			if( ofd.ShowDialog() != DialogResult.OK )
				return;

			tbListFile.Text = ofd.FileName;
		}

		private void btnSkip_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.Ignore;
			Close();
		}

		private void btnOK_Click( object sender, EventArgs e )
		{
			Program.lastbinFilepath = tbBinFile.Text;

			DialogResult = DialogResult.OK;
			Close();
			Program.lastlittleEndian = cbLittleEndian.Checked;
		}

	}
}
