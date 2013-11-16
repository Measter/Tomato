using System.ComponentModel;

namespace Lettuce
{
	partial class WatchWindow
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
			this.watchTextBox = new System.Windows.Forms.TextBox();
			this.addWatchButton = new System.Windows.Forms.Button();
			this.watchesListView = new System.Windows.Forms.ListView();
			this.expressionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.resultHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.watchesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.watchesContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// watchTextBox
			// 
			this.watchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.watchTextBox.Location = new System.Drawing.Point(12, 328);
			this.watchTextBox.Name = "watchTextBox";
			this.watchTextBox.Size = new System.Drawing.Size(186, 20);
			this.watchTextBox.TabIndex = 14;
			this.watchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.watchTextBox_KeyUp);
			// 
			// addWatchButton
			// 
			this.addWatchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addWatchButton.Location = new System.Drawing.Point(204, 326);
			this.addWatchButton.Name = "addWatchButton";
			this.addWatchButton.Size = new System.Drawing.Size(46, 23);
			this.addWatchButton.TabIndex = 13;
			this.addWatchButton.Text = "Add";
			this.addWatchButton.UseVisualStyleBackColor = true;
			this.addWatchButton.Click += new System.EventHandler(this.addWatchButton_Click);
			// 
			// watchesListView
			// 
			this.watchesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.watchesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.expressionHeader,
            this.resultHeader});
			this.watchesListView.ContextMenuStrip = this.watchesContextMenuStrip;
			this.watchesListView.Location = new System.Drawing.Point(12, 12);
			this.watchesListView.MultiSelect = false;
			this.watchesListView.Name = "watchesListView";
			this.watchesListView.Size = new System.Drawing.Size(238, 308);
			this.watchesListView.TabIndex = 12;
			this.watchesListView.UseCompatibleStateImageBehavior = false;
			this.watchesListView.View = System.Windows.Forms.View.Details;
			// 
			// expressionHeader
			// 
			this.expressionHeader.Text = "Expression";
			this.expressionHeader.Width = 167;
			// 
			// resultHeader
			// 
			this.resultHeader.Text = "Result";
			this.resultHeader.Width = 66;
			// 
			// watchesContextMenuStrip
			// 
			this.watchesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeWatchToolStripMenuItem});
			this.watchesContextMenuStrip.Name = "watchesContextMenuStrip";
			this.watchesContextMenuStrip.Size = new System.Drawing.Size(155, 26);
			this.watchesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.watchesContextMenuStrip_Opening);
			// 
			// removeWatchToolStripMenuItem
			// 
			this.removeWatchToolStripMenuItem.Name = "removeWatchToolStripMenuItem";
			this.removeWatchToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.removeWatchToolStripMenuItem.Text = "Remove Watch";
			this.removeWatchToolStripMenuItem.Click += new System.EventHandler(this.removeWatchToolStripMenuItem_Click);
			// 
			// WatchWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 361);
			this.Controls.Add(this.watchTextBox);
			this.Controls.Add(this.addWatchButton);
			this.Controls.Add(this.watchesListView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "WatchWindow";
			this.Text = "Watches";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatchWindow_FormClosing);
			this.Shown += new System.EventHandler(this.WatchWindow_Shown);
			this.watchesContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox watchTextBox;
		private System.Windows.Forms.Button addWatchButton;
		private System.Windows.Forms.ListView watchesListView;
		private System.Windows.Forms.ColumnHeader expressionHeader;
		private System.Windows.Forms.ColumnHeader resultHeader;
		private System.Windows.Forms.ContextMenuStrip watchesContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem removeWatchToolStripMenuItem;
	}
}