namespace Lettuce
{
    partial class KeyboardConfiguration
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
            System.Windows.Forms.Label lbl0;
            System.Windows.Forms.Label lbl1;
            System.Windows.Forms.Label lbl2;
            System.Windows.Forms.Label lbl3;
            this.txtStepInto = new System.Windows.Forms.TextBox();
            this.txtStepOver = new System.Windows.Forms.TextBox();
            this.txtChangeRunning = new System.Windows.Forms.TextBox();
            this.txtGotoAddr = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            lbl0 = new System.Windows.Forms.Label();
            lbl1 = new System.Windows.Forms.Label();
            lbl2 = new System.Windows.Forms.Label();
            lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl0
            // 
            lbl0.AutoSize = true;
            lbl0.Location = new System.Drawing.Point(12, 15);
            lbl0.Name = "lbl0";
            lbl0.Size = new System.Drawing.Size(52, 13);
            lbl0.TabIndex = 0;
            lbl0.Text = "Step into:";
            // 
            // txtStepInto
            // 
            this.txtStepInto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStepInto.Location = new System.Drawing.Point(128, 12);
            this.txtStepInto.Name = "txtStepInto";
            this.txtStepInto.ReadOnly = true;
            this.txtStepInto.Size = new System.Drawing.Size(70, 20);
            this.txtStepInto.TabIndex = 1;
            // 
            // txtStepOver
            // 
            this.txtStepOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStepOver.Location = new System.Drawing.Point(128, 38);
            this.txtStepOver.Name = "txtStepOver";
            this.txtStepOver.ReadOnly = true;
            this.txtStepOver.Size = new System.Drawing.Size(70, 20);
            this.txtStepOver.TabIndex = 3;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new System.Drawing.Point(12, 41);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size(56, 13);
            lbl1.TabIndex = 2;
            lbl1.Text = "Step over:";
            // 
            // txtChangeRunning
            // 
            this.txtChangeRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChangeRunning.Location = new System.Drawing.Point(128, 64);
            this.txtChangeRunning.Name = "txtChangeRunning";
            this.txtChangeRunning.ReadOnly = true;
            this.txtChangeRunning.Size = new System.Drawing.Size(70, 20);
            this.txtChangeRunning.TabIndex = 5;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new System.Drawing.Point(12, 67);
            lbl2.Name = "lbl2";
            lbl2.Size = new System.Drawing.Size(111, 13);
            lbl2.TabIndex = 4;
            lbl2.Text = "Change running-state:";
            // 
            // txtGotoAddr
            // 
            this.txtGotoAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGotoAddr.Location = new System.Drawing.Point(128, 90);
            this.txtGotoAddr.Name = "txtGotoAddr";
            this.txtGotoAddr.ReadOnly = true;
            this.txtGotoAddr.Size = new System.Drawing.Size(70, 20);
            this.txtGotoAddr.TabIndex = 7;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new System.Drawing.Point(12, 93);
            lbl3.Name = "lbl3";
            lbl3.Size = new System.Drawing.Size(73, 13);
            lbl3.TabIndex = 6;
            lbl3.Text = "Goto address:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(12, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // KeyboardConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 157);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGotoAddr);
            this.Controls.Add(lbl3);
            this.Controls.Add(this.txtChangeRunning);
            this.Controls.Add(lbl2);
            this.Controls.Add(this.txtStepOver);
            this.Controls.Add(lbl1);
            this.Controls.Add(this.txtStepInto);
            this.Controls.Add(lbl0);
            this.Name = "KeyboardConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStepInto;
        private System.Windows.Forms.TextBox txtStepOver;
        private System.Windows.Forms.TextBox txtChangeRunning;
        private System.Windows.Forms.TextBox txtGotoAddr;
        private System.Windows.Forms.Button btnSave;

    }
}