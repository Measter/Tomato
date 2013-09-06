using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lettuce
{
	partial class HardwareWindow
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
			this.checkBoxBreakOnInterrupt = new System.Windows.Forms.CheckBox();
			this.listBoxConnectedDevices = new System.Windows.Forms.ListBox();
			this.label17 = new System.Windows.Forms.Label();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// checkBoxBreakOnInterrupt
			// 
			this.checkBoxBreakOnInterrupt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxBreakOnInterrupt.AutoSize = true;
			this.checkBoxBreakOnInterrupt.Enabled = false;
			this.checkBoxBreakOnInterrupt.Location = new System.Drawing.Point(12, 247);
			this.checkBoxBreakOnInterrupt.Name = "checkBoxBreakOnInterrupt";
			this.checkBoxBreakOnInterrupt.Size = new System.Drawing.Size(111, 17);
			this.checkBoxBreakOnInterrupt.TabIndex = 5;
			this.checkBoxBreakOnInterrupt.Text = "Break on Interrupt";
			this.checkBoxBreakOnInterrupt.UseVisualStyleBackColor = true;
			this.checkBoxBreakOnInterrupt.CheckedChanged += CheckBoxBreakOnInterruptOnCheckedChanged;
			// 
			// listBoxConnectedDevices
			// 
			this.listBoxConnectedDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxConnectedDevices.FormattingEnabled = true;
			this.listBoxConnectedDevices.Location = new System.Drawing.Point(12, 25);
			this.listBoxConnectedDevices.Name = "listBoxConnectedDevices";
			this.listBoxConnectedDevices.Size = new System.Drawing.Size(183, 186);
			this.listBoxConnectedDevices.TabIndex = 4;
			this.listBoxConnectedDevices.SelectedIndexChanged += ListBoxConnectedDevicesOnSelectedIndexChanged;
			this.listBoxConnectedDevices.MouseDoubleClick += ListBoxConnectedDevicesOnMouseDoubleClick;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(12, 9);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(104, 13);
			this.label17.TabIndex = 3;
			this.label17.Text = "Connected Devices:";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(201, 9);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(183, 261);
			this.propertyGrid1.TabIndex = 6;
			// 
			// Hardware
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 282);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.checkBoxBreakOnInterrupt);
			this.Controls.Add(this.listBoxConnectedDevices);
			this.Controls.Add(this.label17);
			this.Name = "Hardware";
			this.Text = "Hardware";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hardware_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxBreakOnInterrupt;
		private System.Windows.Forms.ListBox listBoxConnectedDevices;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
	}
}