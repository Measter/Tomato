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
			ComponentResourceManager resources = new ComponentResourceManager( typeof( LEM1802Window ) );
			this.disassemblyDisplay1 = new Lettuce.DisassemblyDisplay();
			menuStrip1 = new MenuStrip();
			debugToolStripMenuItem = new ToolStripMenuItem();
			stepIntoToolStripMenuItem = new ToolStripMenuItem();
			stepOverToolStripMenuItem = new ToolStripMenuItem();
			loadListingToolStripMenuItem = new ToolStripMenuItem();
			defineValueToolStripMenuItem = new ToolStripMenuItem();
			reloadToolStripMenuItem = new ToolStripMenuItem();
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
			this.Controls.Add( this.menuStrip1 );
			this.MinimumSize = new System.Drawing.Size(374, 355);
			this.MainMenuStrip = menuStrip1;
			this.Name = "Disassembly";
			this.Text = "Disassembly";
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisassemblyWindow_FormClosing);
			this.Resize += OnResize;
			this.KeyDown += OnKeyDown;
			this.ResumeLayout(false);
			//
			// menuStrip1
			//
			this.menuStrip1.Items.Add( this.debugToolStripMenuItem );
			this.menuStrip1.Location = new Point(0,0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size( 358, 24 );
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			//
			// debugToolStripMenuItem
			//
			this.debugToolStripMenuItem.DropDownItems.AddRange( new ToolStripItem[]
			                                                    {
				                                                    this.stepIntoToolStripMenuItem,
																	this.stepOverToolStripMenuItem,
																	this.loadListingToolStripMenuItem,
																	this.defineValueToolStripMenuItem,
																	this.reloadToolStripMenuItem
			                                                    } );
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new Size( 54, 20 );
			this.debugToolStripMenuItem.Text = "Debug";
			//
			// stepIntoToolStripMenuItem
			//
			this.stepIntoToolStripMenuItem.Name = "stepIntoToolStripMenuItem";
			this.stepIntoToolStripMenuItem.ShortcutKeyDisplayString = "F6";
			this.stepIntoToolStripMenuItem.Size = new Size( 144, 22 );
			this.stepIntoToolStripMenuItem.Text = "Step Into";
			this.stepIntoToolStripMenuItem.Click += StepIntoToolStripMenuItemOnClick;
			//
			// stepOverToolStripMenuItem
			//
			this.stepOverToolStripMenuItem.Name = "stepOverToolStripMenuItem";
			this.stepOverToolStripMenuItem.ShortcutKeyDisplayString = "F7";
			this.stepOverToolStripMenuItem.Size = new Size( 144, 22 );
			this.stepOverToolStripMenuItem.Text = "Step Over";
			this.stepOverToolStripMenuItem.Click += StepOverToolStripMenuItemOnClick; 
			//
			// loadListingToolStripMenuItem
			//
			this.loadListingToolStripMenuItem.Name = "loadListingToolStripMenuItem";
			this.loadListingToolStripMenuItem.Size = new Size( 144, 22 );
			this.loadListingToolStripMenuItem.Text = "Load Listing";
			this.loadListingToolStripMenuItem.Click += LoadListingToolStripMenuItemOnClick;
			//
			// defineValueToolStripMenuItem
			//
			this.defineValueToolStripMenuItem.Name = "defineValueToolStripMenuItem";
			this.defineValueToolStripMenuItem.Size = new Size( 144, 22 );
			this.defineValueToolStripMenuItem.Text = "Define Value";
			this.defineValueToolStripMenuItem.Click += DefineValueToolStripMenuItemOnClick;
			// 
			// reloadToolStripMenuItem
			//
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.Size = new Size( 144, 22 );
			this.reloadToolStripMenuItem.Text = "Reload";
			this.reloadToolStripMenuItem.Click += ReloadToolStripMenuItemOnClick;
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