using System;
using System.ComponentModel;
using System.Drawing;
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
			this.disassemblyDisplay1 = new Lettuce.DisassemblyDisplay();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepIntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defineValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// disassemblyDisplay1
			// 
			this.disassemblyDisplay1.CPU = dcpu1;
			this.disassemblyDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.disassemblyDisplay1.EnableUpdates = true;
			this.disassemblyDisplay1.EndAddress = ((ushort)(0));
			this.disassemblyDisplay1.Font = new System.Drawing.Font("Courier New", 12F);
			this.disassemblyDisplay1.Location = new System.Drawing.Point(0, 24);
			this.disassemblyDisplay1.Margin = new System.Windows.Forms.Padding(4);
			this.disassemblyDisplay1.Name = "disassemblyDisplay1";
			this.disassemblyDisplay1.SelectedAddress = ((ushort)(0));
			this.disassemblyDisplay1.Size = new System.Drawing.Size(358, 293);
			this.disassemblyDisplay1.TabIndex = 6;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(358, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepIntoToolStripMenuItem,
            this.stepOverToolStripMenuItem,
            this.loadListingToolStripMenuItem,
            this.defineValueToolStripMenuItem,
            this.reloadToolStripMenuItem});
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.debugToolStripMenuItem.Text = "Debug";
			// 
			// stepIntoToolStripMenuItem
			// 
			this.stepIntoToolStripMenuItem.Name = "stepIntoToolStripMenuItem";
			this.stepIntoToolStripMenuItem.ShortcutKeyDisplayString = "F6";
			this.stepIntoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stepIntoToolStripMenuItem.Text = "Step Into";
			this.stepIntoToolStripMenuItem.Click += new System.EventHandler(this.StepIntoToolStripMenuItemOnClick);
			// 
			// stepOverToolStripMenuItem
			// 
			this.stepOverToolStripMenuItem.Name = "stepOverToolStripMenuItem";
			this.stepOverToolStripMenuItem.ShortcutKeyDisplayString = "F7";
			this.stepOverToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stepOverToolStripMenuItem.Text = "Step Over";
			this.stepOverToolStripMenuItem.Click += new System.EventHandler(this.StepOverToolStripMenuItemOnClick);
			// 
			// loadListingToolStripMenuItem
			// 
			this.loadListingToolStripMenuItem.Name = "loadListingToolStripMenuItem";
			this.loadListingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadListingToolStripMenuItem.Text = "Load Listing";
			this.loadListingToolStripMenuItem.Click += new System.EventHandler(this.LoadListingToolStripMenuItemOnClick);
			// 
			// defineValueToolStripMenuItem
			// 
			this.defineValueToolStripMenuItem.Name = "defineValueToolStripMenuItem";
			this.defineValueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.defineValueToolStripMenuItem.Text = "Define Value";
			this.defineValueToolStripMenuItem.Click += new System.EventHandler(this.DefineValueToolStripMenuItemOnClick);
			// 
			// reloadToolStripMenuItem
			// 
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.reloadToolStripMenuItem.Text = "Reload";
			this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItemOnClick);
			// 
			// DisassemblyWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 317);
			this.Controls.Add(this.disassemblyDisplay1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(374, 355);
			this.Name = "DisassemblyWindow";
			this.Text = "Disassembly";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisassemblyWindow_FormClosing);
			this.Shown += new System.EventHandler(this.DisassemblyWindow_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			this.Resize += new System.EventHandler(this.OnResize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}  

		#endregion

		private DisassemblyDisplay disassemblyDisplay1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem debugToolStripMenuItem;
		private ToolStripMenuItem stepIntoToolStripMenuItem;
		private ToolStripMenuItem stepOverToolStripMenuItem;
		private ToolStripMenuItem loadListingToolStripMenuItem;
		private ToolStripMenuItem defineValueToolStripMenuItem;
		private ToolStripMenuItem reloadToolStripMenuItem;

	}
}