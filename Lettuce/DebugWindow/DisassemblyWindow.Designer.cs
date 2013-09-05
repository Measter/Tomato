using System.ComponentModel;
using System.Windows.Forms;

namespace Lettuce
{
	partial class DisassemblyWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Tomato.DCPU dcpu1 = new Tomato.DCPU();
			ComponentResourceManager resources = new ComponentResourceManager( typeof( LEM1802Window ) );
			this.disassemblyDisplay1 = new Lettuce.DisassemblyDisplay();
			this.SuspendLayout();
			// 
			// disassemblyDisplay1
			// 
			this.disassemblyDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.disassemblyDisplay1.CPU = dcpu1;
			this.disassemblyDisplay1.EnableUpdates = true;
			this.disassemblyDisplay1.Dock = DockStyle.Fill;
			this.disassemblyDisplay1.EndAddress = ((ushort)(0));
			this.disassemblyDisplay1.Font = new System.Drawing.Font("Courier New", 12F);
			this.disassemblyDisplay1.Location = new System.Drawing.Point(13, 13);
			this.disassemblyDisplay1.Margin = new System.Windows.Forms.Padding(4);
			this.disassemblyDisplay1.Name = "disassemblyDisplay1";
			this.disassemblyDisplay1.SelectedAddress = ((ushort)(0));
			this.disassemblyDisplay1.Size = new System.Drawing.Size(332, 291);
			this.disassemblyDisplay1.TabIndex = 6;
			// 
			// DisassemblyWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 317);
			this.Controls.Add(this.disassemblyDisplay1);
			this.MinimumSize = new System.Drawing.Size(374, 355);
			this.Name = "DisassemblyWindow";
			this.Text = "DisassemblyWindow";
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisassemblyWindow_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private DisassemblyDisplay disassemblyDisplay1;

	}
}