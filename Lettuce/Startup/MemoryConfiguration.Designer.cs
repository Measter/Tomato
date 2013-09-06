namespace Lettuce
{
    partial class MemoryConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryConfiguration));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbBinFile = new System.Windows.Forms.TextBox();
			this.btnOpenBin = new System.Windows.Forms.Button();
			this.cbLittleEndian = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnSkip = new System.Windows.Forms.Button();
			this.tbListFile = new System.Windows.Forms.TextBox();
			this.btnOpenList = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Memory Configuration";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(260, 45);
			this.label2.TabIndex = 1;
			this.label2.Text = "If you\'d like to load a binary file into memory, you may select it here.  Start L" +
    "ettuce with a filename (\"Lettuce.exe file.bin\") to skip this step.";
			// 
			// tbBinFile
			// 
			this.tbBinFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBinFile.Enabled = false;
			this.tbBinFile.Location = new System.Drawing.Point(12, 77);
			this.tbBinFile.Name = "tbBinFile";
			this.tbBinFile.Size = new System.Drawing.Size(182, 20);
			this.tbBinFile.TabIndex = 2;
			this.tbBinFile.Text = "Binary file";
			// 
			// btnOpenBin
			// 
			this.btnOpenBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenBin.Location = new System.Drawing.Point(200, 75);
			this.btnOpenBin.Name = "btnOpenBin";
			this.btnOpenBin.Size = new System.Drawing.Size(75, 23);
			this.btnOpenBin.TabIndex = 3;
			this.btnOpenBin.Text = "Browse...";
			this.btnOpenBin.UseVisualStyleBackColor = true;
			this.btnOpenBin.Click += new System.EventHandler(this.btnOpenBin_Click);
			// 
			// cbLittleEndian
			// 
			this.cbLittleEndian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbLittleEndian.AutoSize = true;
			this.cbLittleEndian.Location = new System.Drawing.Point(16, 140);
			this.cbLittleEndian.Name = "cbLittleEndian";
			this.cbLittleEndian.Size = new System.Drawing.Size(84, 17);
			this.cbLittleEndian.TabIndex = 4;
			this.cbLittleEndian.Text = "Little Endian";
			this.cbLittleEndian.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(200, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnSkip
			// 
			this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSkip.Location = new System.Drawing.Point(119, 136);
			this.btnSkip.Name = "btnSkip";
			this.btnSkip.Size = new System.Drawing.Size(75, 23);
			this.btnSkip.TabIndex = 6;
			this.btnSkip.Text = "Skip";
			this.btnSkip.UseVisualStyleBackColor = true;
			this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
			// 
			// tbListFile
			// 
			this.tbListFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbListFile.Enabled = false;
			this.tbListFile.Location = new System.Drawing.Point(12, 106);
			this.tbListFile.Name = "tbListFile";
			this.tbListFile.Size = new System.Drawing.Size(182, 20);
			this.tbListFile.TabIndex = 2;
			this.tbListFile.Text = "Listing file";
			// 
			// btnOpenList
			// 
			this.btnOpenList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenList.Location = new System.Drawing.Point(200, 104);
			this.btnOpenList.Name = "btnOpenList";
			this.btnOpenList.Size = new System.Drawing.Size(75, 23);
			this.btnOpenList.TabIndex = 3;
			this.btnOpenList.Text = "Browse...";
			this.btnOpenList.UseVisualStyleBackColor = true;
			this.btnOpenList.Click += new System.EventHandler(this.btnOpenList_Click);
			// 
			// MemoryConfiguration
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 171);
			this.Controls.Add(this.btnSkip);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cbLittleEndian);
			this.Controls.Add(this.btnOpenList);
			this.Controls.Add(this.tbListFile);
			this.Controls.Add(this.btnOpenBin);
			this.Controls.Add(this.tbBinFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MemoryConfiguration";
			this.Text = "Configuration";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBinFile;
        private System.Windows.Forms.Button btnOpenBin;
        private System.Windows.Forms.CheckBox cbLittleEndian;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSkip;
		private System.Windows.Forms.TextBox tbListFile;
		private System.Windows.Forms.Button btnOpenList;
    }
}