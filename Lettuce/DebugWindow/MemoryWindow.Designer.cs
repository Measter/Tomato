using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lettuce
{
	partial class MemoryWindow
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
			ComponentResourceManager resources = new ComponentResourceManager( typeof( LEM1802Window ) );
			this.stackDisplay = new Lettuce.MemoryDisplay();
			this.label18 = new System.Windows.Forms.Label();
			this.rawMemoryDisplay = new Lettuce.MemoryDisplay();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// stackDisplay
			// 
			this.stackDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.stackDisplay.AsStack = true;
			this.stackDisplay.DisplayScrollBar = false;
			this.stackDisplay.Font = new System.Drawing.Font("Courier New", 12F);
			this.stackDisplay.Location = new System.Drawing.Point(14, 25);
			this.stackDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.stackDisplay.Name = "stackDisplay";
			this.stackDisplay.SelectedAddress = ((ushort)(0));
			this.stackDisplay.Size = new System.Drawing.Size(84, 356);
			this.stackDisplay.TabIndex = 7;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 9);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(35, 13);
			this.label18.TabIndex = 6;
			this.label18.Text = "Stack";
			// 
			// rawMemoryDisplay
			// 
			this.rawMemoryDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rawMemoryDisplay.AsStack = false;
			this.rawMemoryDisplay.DisplayScrollBar = true;
			this.rawMemoryDisplay.Font = new System.Drawing.Font("Courier New", 12F);
			this.rawMemoryDisplay.Location = new System.Drawing.Point(108, 25);
			this.rawMemoryDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.rawMemoryDisplay.Name = "rawMemoryDisplay";
			this.rawMemoryDisplay.SelectedAddress = ((ushort)(0));
			this.rawMemoryDisplay.Size = new System.Drawing.Size(625, 356);
			this.rawMemoryDisplay.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Raw Memory";
			// 
			// MemoryWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 394);
			this.Controls.Add(this.rawMemoryDisplay);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.stackDisplay);
			this.Controls.Add(this.label18);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(483, 365);
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "MemoryWindow";
			this.Text = "Memory";
			this.ResumeLayout(false);
			this.PerformLayout();
			this.FormClosing += MemoryWindow_OnFormClosing;

		}

		#endregion

		private MemoryDisplay stackDisplay;
		private System.Windows.Forms.Label label18;
		private MemoryDisplay rawMemoryDisplay;
		private System.Windows.Forms.Label label1;

	}
}