namespace Lettuce
{
    partial class M35FDWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M35FDWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.imageNameLabel = new System.Windows.Forms.Label();
            this.insertDiskButton = new System.Windows.Forms.Button();
            this.ejectButton = new System.Windows.Forms.Button();
            this.writeProtectedCheckBox = new System.Windows.Forms.CheckBox();
            this.bigEndianCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveSelectedDiskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mackapar 3.5\" Floppy Drive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Disk Images:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(198, 160);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(16, 210);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(139, 210);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Image:";
            // 
            // imageNameLabel
            // 
            this.imageNameLabel.AutoSize = true;
            this.imageNameLabel.Location = new System.Drawing.Point(220, 105);
            this.imageNameLabel.Name = "imageNameLabel";
            this.imageNameLabel.Size = new System.Drawing.Size(74, 13);
            this.imageNameLabel.TabIndex = 6;
            this.imageNameLabel.Text = "[None loaded]";
            // 
            // insertDiskButton
            // 
            this.insertDiskButton.Enabled = false;
            this.insertDiskButton.Location = new System.Drawing.Point(220, 154);
            this.insertDiskButton.Name = "insertDiskButton";
            this.insertDiskButton.Size = new System.Drawing.Size(151, 23);
            this.insertDiskButton.TabIndex = 7;
            this.insertDiskButton.Text = "Insert Selected Disk";
            this.insertDiskButton.UseVisualStyleBackColor = true;
            this.insertDiskButton.Click += new System.EventHandler(this.insertDiskButton_Click);
            // 
            // ejectButton
            // 
            this.ejectButton.Enabled = false;
            this.ejectButton.Location = new System.Drawing.Point(220, 125);
            this.ejectButton.Name = "ejectButton";
            this.ejectButton.Size = new System.Drawing.Size(151, 23);
            this.ejectButton.TabIndex = 8;
            this.ejectButton.Text = "Eject";
            this.ejectButton.UseVisualStyleBackColor = true;
            this.ejectButton.Click += new System.EventHandler(this.ejectButton_Click);
            // 
            // writeProtectedCheckBox
            // 
            this.writeProtectedCheckBox.AutoSize = true;
            this.writeProtectedCheckBox.Enabled = false;
            this.writeProtectedCheckBox.Location = new System.Drawing.Point(220, 45);
            this.writeProtectedCheckBox.Name = "writeProtectedCheckBox";
            this.writeProtectedCheckBox.Size = new System.Drawing.Size(100, 17);
            this.writeProtectedCheckBox.TabIndex = 9;
            this.writeProtectedCheckBox.Text = "Write Protected";
            this.writeProtectedCheckBox.UseVisualStyleBackColor = true;
            this.writeProtectedCheckBox.CheckedChanged += new System.EventHandler(this.writeProtectedCheckBox_CheckedChanged);
            // 
            // bigEndianCheckBox
            // 
            this.bigEndianCheckBox.AutoSize = true;
            this.bigEndianCheckBox.Enabled = false;
            this.bigEndianCheckBox.Location = new System.Drawing.Point(220, 68);
            this.bigEndianCheckBox.Name = "bigEndianCheckBox";
            this.bigEndianCheckBox.Size = new System.Drawing.Size(77, 17);
            this.bigEndianCheckBox.TabIndex = 10;
            this.bigEndianCheckBox.Text = "Big Endian";
            this.bigEndianCheckBox.UseVisualStyleBackColor = true;
            this.bigEndianCheckBox.CheckedChanged += new System.EventHandler(this.bigEndianCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create Blank Disk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addBlankDisk_Click);
            // 
            // saveSelectedDiskButton
            // 
            this.saveSelectedDiskButton.Enabled = false;
            this.saveSelectedDiskButton.Location = new System.Drawing.Point(220, 210);
            this.saveSelectedDiskButton.Name = "saveSelectedDiskButton";
            this.saveSelectedDiskButton.Size = new System.Drawing.Size(151, 23);
            this.saveSelectedDiskButton.TabIndex = 12;
            this.saveSelectedDiskButton.Text = "Save Selected Disk";
            this.saveSelectedDiskButton.UseVisualStyleBackColor = true;
            this.saveSelectedDiskButton.Click += new System.EventHandler(this.saveSelectedDiskButton_Click);
            // 
            // M35FDWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 236);
            this.Controls.Add(this.saveSelectedDiskButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bigEndianCheckBox);
            this.Controls.Add(this.writeProtectedCheckBox);
            this.Controls.Add(this.ejectButton);
            this.Controls.Add(this.insertDiskButton);
            this.Controls.Add(this.imageNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "M35FDWindow";
            this.Text = "M35FDWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label imageNameLabel;
        private System.Windows.Forms.Button insertDiskButton;
        private System.Windows.Forms.Button ejectButton;
        private System.Windows.Forms.CheckBox writeProtectedCheckBox;
        private System.Windows.Forms.CheckBox bigEndianCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveSelectedDiskButton;
    }
}