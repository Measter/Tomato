﻿using System;
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
			Tomato.DCPU dcpu3 = new Tomato.DCPU();
			Tomato.DCPU dcpu1 = new Tomato.DCPU();
			this.stackDisplay = new Lettuce.MemoryDisplay();
			this.label18 = new System.Windows.Forms.Label();
			this.rawMemoryDisplay = new Lettuce.MemoryDisplay();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.memoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gotoAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// stackDisplay
			// 
			this.stackDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.stackDisplay.AsStack = true;
			this.stackDisplay.CPU = dcpu3;
			this.stackDisplay.DisplayScrollBar = false;
			this.stackDisplay.Font = new System.Drawing.Font("Courier New", 12F);
			this.stackDisplay.Location = new System.Drawing.Point(14, 41);
			this.stackDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.stackDisplay.Name = "stackDisplay";
			this.stackDisplay.SelectedAddress = ((ushort)(0));
			this.stackDisplay.Size = new System.Drawing.Size(84, 340);
			this.stackDisplay.TabIndex = 7;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 24);
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
			this.rawMemoryDisplay.CPU = dcpu1;
			this.rawMemoryDisplay.DisplayScrollBar = true;
			this.rawMemoryDisplay.Font = new System.Drawing.Font("Courier New", 12F);
			this.rawMemoryDisplay.Location = new System.Drawing.Point(108, 41);
			this.rawMemoryDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.rawMemoryDisplay.Name = "rawMemoryDisplay";
			this.rawMemoryDisplay.SelectedAddress = ((ushort)(0));
			this.rawMemoryDisplay.Size = new System.Drawing.Size(625, 340);
			this.rawMemoryDisplay.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Raw Memory";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(747, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// memoryToolStripMenuItem
			// 
			this.memoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoAddressToolStripMenuItem,
            this.resetToolStripMenuItem1});
			this.memoryToolStripMenuItem.Name = "memoryToolStripMenuItem";
			this.memoryToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.memoryToolStripMenuItem.Text = "Memory";
			// 
			// gotoAddressToolStripMenuItem
			// 
			this.gotoAddressToolStripMenuItem.Name = "gotoAddressToolStripMenuItem";
			this.gotoAddressToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
			this.gotoAddressToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.gotoAddressToolStripMenuItem.Text = "Goto Address";
			this.gotoAddressToolStripMenuItem.Click += new System.EventHandler(this.gotoAddressToolStripMenuItem_Click);
			// 
			// resetToolStripMenuItem1
			// 
			this.resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
			this.resetToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
			this.resetToolStripMenuItem1.Text = "Reset";
			this.resetToolStripMenuItem1.Click += new System.EventHandler(this.resetToolStripMenuItem1_Click);
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
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(483, 365);
			this.Name = "MemoryWindow";
			this.Text = "Memory";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoryWindow_OnFormClosing);
			this.Shown += new System.EventHandler(this.MemoryWindow_Shown);
			this.Resize += new System.EventHandler(this.OnResize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MemoryDisplay stackDisplay;
		private System.Windows.Forms.Label label18;
		private MemoryDisplay rawMemoryDisplay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem memoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gotoAddressToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem1;

	}
}