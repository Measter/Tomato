namespace Lettuce
{
    partial class Debugger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Debugger));
			this.cycleCountLabel = new System.Windows.Forms.Label();
			this.checkBoxOnFire = new System.Windows.Forms.CheckBox();
			this.labelQueuedInterrupts = new System.Windows.Forms.Label();
			this.buttonStepOver = new System.Windows.Forms.Button();
			this.buttonStepInto = new System.Windows.Forms.Button();
			this.checkBoxInterruptQueue = new System.Windows.Forms.CheckBox();
			this.textBoxRegisterPC = new System.Windows.Forms.TextBox();
			this.textBoxRegisterIA = new System.Windows.Forms.TextBox();
			this.textBoxRegisterEX = new System.Windows.Forms.TextBox();
			this.textBoxRegisterSP = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxRegisterJ = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxRegisterI = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxRegisterZ = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxRegisterC = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxRegisterY = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxRegisterB = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxRegisterX = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxRegisterA = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxRunning = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.emulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.breakOnInvalidInstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disassemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.memoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.hardwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.watchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.warningLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// cycleCountLabel
			// 
			this.cycleCountLabel.AutoSize = true;
			this.cycleCountLabel.Location = new System.Drawing.Point(75, 28);
			this.cycleCountLabel.Name = "cycleCountLabel";
			this.cycleCountLabel.Size = new System.Drawing.Size(50, 13);
			this.cycleCountLabel.TabIndex = 31;
			this.cycleCountLabel.Text = "Cycles: 0";
			// 
			// checkBoxOnFire
			// 
			this.checkBoxOnFire.AutoSize = true;
			this.checkBoxOnFire.Location = new System.Drawing.Point(12, 237);
			this.checkBoxOnFire.Name = "checkBoxOnFire";
			this.checkBoxOnFire.Size = new System.Drawing.Size(60, 17);
			this.checkBoxOnFire.TabIndex = 30;
			this.checkBoxOnFire.Text = "On Fire";
			this.checkBoxOnFire.UseVisualStyleBackColor = true;
			this.checkBoxOnFire.CheckedChanged += new System.EventHandler(this.checkBoxOnFire_CheckedChanged);
			// 
			// labelQueuedInterrupts
			// 
			this.labelQueuedInterrupts.AutoSize = true;
			this.labelQueuedInterrupts.Location = new System.Drawing.Point(12, 221);
			this.labelQueuedInterrupts.Name = "labelQueuedInterrupts";
			this.labelQueuedInterrupts.Size = new System.Drawing.Size(104, 13);
			this.labelQueuedInterrupts.TabIndex = 29;
			this.labelQueuedInterrupts.Text = "Queued Interrupts: 0";
			// 
			// buttonStepOver
			// 
			this.buttonStepOver.Location = new System.Drawing.Point(92, 255);
			this.buttonStepOver.Name = "buttonStepOver";
			this.buttonStepOver.Size = new System.Drawing.Size(75, 23);
			this.buttonStepOver.TabIndex = 28;
			this.buttonStepOver.Text = "Step Over";
			this.buttonStepOver.UseVisualStyleBackColor = true;
			this.buttonStepOver.Click += new System.EventHandler(this.buttonStepOver_Click);
			// 
			// buttonStepInto
			// 
			this.buttonStepInto.Location = new System.Drawing.Point(9, 255);
			this.buttonStepInto.Name = "buttonStepInto";
			this.buttonStepInto.Size = new System.Drawing.Size(75, 23);
			this.buttonStepInto.TabIndex = 27;
			this.buttonStepInto.Text = "Step Into";
			this.buttonStepInto.UseVisualStyleBackColor = true;
			this.buttonStepInto.Click += new System.EventHandler(this.buttonStepInto_Click);
			// 
			// checkBoxInterruptQueue
			// 
			this.checkBoxInterruptQueue.AutoSize = true;
			this.checkBoxInterruptQueue.Location = new System.Drawing.Point(12, 201);
			this.checkBoxInterruptQueue.Name = "checkBoxInterruptQueue";
			this.checkBoxInterruptQueue.Size = new System.Drawing.Size(100, 17);
			this.checkBoxInterruptQueue.TabIndex = 26;
			this.checkBoxInterruptQueue.Text = "Interrupt Queue";
			this.checkBoxInterruptQueue.UseVisualStyleBackColor = true;
			this.checkBoxInterruptQueue.CheckedChanged += new System.EventHandler(this.checkBoxInterruptQueue_CheckedChanged);
			// 
			// textBoxRegisterPC
			// 
			this.textBoxRegisterPC.Location = new System.Drawing.Point(30, 138);
			this.textBoxRegisterPC.MaxLength = 4;
			this.textBoxRegisterPC.Name = "textBoxRegisterPC";
			this.textBoxRegisterPC.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterPC.TabIndex = 19;
			this.textBoxRegisterPC.Text = "0000";
			this.textBoxRegisterPC.TextChanged += new System.EventHandler(this.textBoxRegisterPC_TextChanged);
			this.textBoxRegisterPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// textBoxRegisterIA
			// 
			this.textBoxRegisterIA.Location = new System.Drawing.Point(110, 164);
			this.textBoxRegisterIA.MaxLength = 4;
			this.textBoxRegisterIA.Name = "textBoxRegisterIA";
			this.textBoxRegisterIA.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterIA.TabIndex = 25;
			this.textBoxRegisterIA.Text = "0000";
			this.textBoxRegisterIA.TextChanged += new System.EventHandler(this.textBoxRegisterIA_TextChanged);
			this.textBoxRegisterIA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// textBoxRegisterEX
			// 
			this.textBoxRegisterEX.Location = new System.Drawing.Point(110, 138);
			this.textBoxRegisterEX.MaxLength = 4;
			this.textBoxRegisterEX.Name = "textBoxRegisterEX";
			this.textBoxRegisterEX.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterEX.TabIndex = 23;
			this.textBoxRegisterEX.Text = "0000";
			this.textBoxRegisterEX.TextChanged += new System.EventHandler(this.textBoxRegisterEX_TextChanged);
			this.textBoxRegisterEX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// textBoxRegisterSP
			// 
			this.textBoxRegisterSP.Location = new System.Drawing.Point(30, 164);
			this.textBoxRegisterSP.MaxLength = 4;
			this.textBoxRegisterSP.Name = "textBoxRegisterSP";
			this.textBoxRegisterSP.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterSP.TabIndex = 21;
			this.textBoxRegisterSP.Text = "0000";
			this.textBoxRegisterSP.TextChanged += new System.EventHandler(this.textBoxRegisterSP_TextChanged);
			this.textBoxRegisterSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(89, 167);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(23, 17);
			this.label15.TabIndex = 24;
			this.label15.Text = "IA: ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(86, 141);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(36, 17);
			this.label14.TabIndex = 22;
			this.label14.Text = "EX: ";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 167);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(26, 17);
			this.label13.TabIndex = 20;
			this.label13.Text = "SP: ";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 141);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(39, 17);
			this.label12.TabIndex = 18;
			this.label12.Text = "PC: ";
			// 
			// textBoxRegisterJ
			// 
			this.textBoxRegisterJ.Location = new System.Drawing.Point(110, 86);
			this.textBoxRegisterJ.MaxLength = 4;
			this.textBoxRegisterJ.Name = "textBoxRegisterJ";
			this.textBoxRegisterJ.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterJ.TabIndex = 17;
			this.textBoxRegisterJ.Text = "0000";
			this.textBoxRegisterJ.TextChanged += new System.EventHandler(this.textBoxRegisterJ_TextChanged);
			this.textBoxRegisterJ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(92, 89);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 17);
			this.label11.TabIndex = 16;
			this.label11.Text = "J: ";
			// 
			// textBoxRegisterI
			// 
			this.textBoxRegisterI.Location = new System.Drawing.Point(30, 86);
			this.textBoxRegisterI.MaxLength = 4;
			this.textBoxRegisterI.Name = "textBoxRegisterI";
			this.textBoxRegisterI.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterI.TabIndex = 15;
			this.textBoxRegisterI.Text = "0000";
			this.textBoxRegisterI.TextChanged += new System.EventHandler(this.textBoxRegisterI_TextChanged);
			this.textBoxRegisterI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(12, 89);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(20, 17);
			this.label10.TabIndex = 14;
			this.label10.Text = "I: ";
			// 
			// textBoxRegisterZ
			// 
			this.textBoxRegisterZ.Location = new System.Drawing.Point(191, 112);
			this.textBoxRegisterZ.MaxLength = 4;
			this.textBoxRegisterZ.Name = "textBoxRegisterZ";
			this.textBoxRegisterZ.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterZ.TabIndex = 13;
			this.textBoxRegisterZ.Text = "0000";
			this.textBoxRegisterZ.TextChanged += new System.EventHandler(this.textBoxRegisterZ_TextChanged);
			this.textBoxRegisterZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(173, 115);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(20, 17);
			this.label9.TabIndex = 12;
			this.label9.Text = "Z: ";
			// 
			// textBoxRegisterC
			// 
			this.textBoxRegisterC.Location = new System.Drawing.Point(192, 60);
			this.textBoxRegisterC.MaxLength = 4;
			this.textBoxRegisterC.Name = "textBoxRegisterC";
			this.textBoxRegisterC.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterC.TabIndex = 11;
			this.textBoxRegisterC.Text = "0000";
			this.textBoxRegisterC.TextChanged += new System.EventHandler(this.textBoxRegisterC_TextChanged);
			this.textBoxRegisterC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(174, 63);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(20, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "C: ";
			// 
			// textBoxRegisterY
			// 
			this.textBoxRegisterY.Location = new System.Drawing.Point(110, 112);
			this.textBoxRegisterY.MaxLength = 4;
			this.textBoxRegisterY.Name = "textBoxRegisterY";
			this.textBoxRegisterY.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterY.TabIndex = 9;
			this.textBoxRegisterY.Text = "0000";
			this.textBoxRegisterY.TextChanged += new System.EventHandler(this.textBoxRegisterY_TextChanged);
			this.textBoxRegisterY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(92, 115);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(20, 17);
			this.label7.TabIndex = 8;
			this.label7.Text = "Y: ";
			// 
			// textBoxRegisterB
			// 
			this.textBoxRegisterB.Location = new System.Drawing.Point(111, 60);
			this.textBoxRegisterB.MaxLength = 4;
			this.textBoxRegisterB.Name = "textBoxRegisterB";
			this.textBoxRegisterB.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterB.TabIndex = 7;
			this.textBoxRegisterB.Text = "0000";
			this.textBoxRegisterB.TextChanged += new System.EventHandler(this.textBoxRegisterB_TextChanged);
			this.textBoxRegisterB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(93, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 17);
			this.label6.TabIndex = 6;
			this.label6.Text = "B: ";
			// 
			// textBoxRegisterX
			// 
			this.textBoxRegisterX.Location = new System.Drawing.Point(30, 112);
			this.textBoxRegisterX.MaxLength = 4;
			this.textBoxRegisterX.Name = "textBoxRegisterX";
			this.textBoxRegisterX.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterX.TabIndex = 5;
			this.textBoxRegisterX.Text = "0000";
			this.textBoxRegisterX.TextChanged += new System.EventHandler(this.textBoxRegisterX_TextChanged);
			this.textBoxRegisterX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "X: ";
			// 
			// textBoxRegisterA
			// 
			this.textBoxRegisterA.Location = new System.Drawing.Point(30, 60);
			this.textBoxRegisterA.MaxLength = 4;
			this.textBoxRegisterA.Name = "textBoxRegisterA";
			this.textBoxRegisterA.Size = new System.Drawing.Size(57, 20);
			this.textBoxRegisterA.TabIndex = 3;
			this.textBoxRegisterA.Text = "0000";
			this.textBoxRegisterA.TextChanged += new System.EventHandler(this.textBoxRegisterA_TextChanged);
			this.textBoxRegisterA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegisterX_KeyDown);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "A: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Registers";
			// 
			// checkBoxRunning
			// 
			this.checkBoxRunning.AutoSize = true;
			this.checkBoxRunning.Location = new System.Drawing.Point(12, 27);
			this.checkBoxRunning.Name = "checkBoxRunning";
			this.checkBoxRunning.Size = new System.Drawing.Size(66, 17);
			this.checkBoxRunning.TabIndex = 0;
			this.checkBoxRunning.Text = "Running";
			this.checkBoxRunning.UseVisualStyleBackColor = true;
			this.checkBoxRunning.CheckedChanged += new System.EventHandler(this.checkBoxRunning_CheckedChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.windowsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(262, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// emulationToolStripMenuItem
			// 
			this.emulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.speedToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.emulationToolStripMenuItem.Name = "emulationToolStripMenuItem";
			this.emulationToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.emulationToolStripMenuItem.Text = "Emulation";
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeyDisplayString = "F5";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.checkBoxRunning_CheckedChanged);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// speedToolStripMenuItem
			// 
			this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.customToolStripMenuItem});
			this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
			this.speedToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.speedToolStripMenuItem.Text = "Speed";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
			this.toolStripMenuItem2.Text = "50%";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Checked = true;
			this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
			this.toolStripMenuItem3.Text = "100%";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
			this.toolStripMenuItem4.Text = "200%";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(116, 22);
			this.toolStripMenuItem5.Text = "1000%";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
			// 
			// customToolStripMenuItem
			// 
			this.customToolStripMenuItem.Name = "customToolStripMenuItem";
			this.customToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.customToolStripMenuItem.Text = "Custom";
			this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.breakOnInvalidInstructionToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// breakOnInvalidInstructionToolStripMenuItem
			// 
			this.breakOnInvalidInstructionToolStripMenuItem.Name = "breakOnInvalidInstructionToolStripMenuItem";
			this.breakOnInvalidInstructionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.breakOnInvalidInstructionToolStripMenuItem.Text = "Break on Invalid Instruction";
			this.breakOnInvalidInstructionToolStripMenuItem.Click += new System.EventHandler(this.breakOnInvalidInstructionToolStripMenuItem_Click);
			
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// keyboardToolStripMenuItem
			// 
			this.keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
			this.keyboardToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.keyboardToolStripMenuItem.Text = "Keyboard";
			this.keyboardToolStripMenuItem.Click += new System.EventHandler(this.keyboardToolStripMenuItem_Click);
			// 
			// windowsToolStripMenuItem
			// 
			this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disassemblyToolStripMenuItem,
            this.memoryToolStripMenuItem1,
            this.hardwareToolStripMenuItem,
            this.watchesToolStripMenuItem});
			this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
			this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.windowsToolStripMenuItem.Text = "Windows";
			// 
			// disassemblyToolStripMenuItem
			// 
			this.disassemblyToolStripMenuItem.Name = "disassemblyToolStripMenuItem";
			this.disassemblyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.disassemblyToolStripMenuItem.Text = "Disassembly";
			this.disassemblyToolStripMenuItem.Click += new System.EventHandler(this.disassemblyToolStripMenuItem_Click);
			// 
			// memoryToolStripMenuItem1
			// 
			this.memoryToolStripMenuItem1.Name = "memoryToolStripMenuItem1";
			this.memoryToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.memoryToolStripMenuItem1.Text = "Memory";
			this.memoryToolStripMenuItem1.Click += new System.EventHandler(this.memoryToolStripMenuItem1_Click);
			// 
			// hardwareToolStripMenuItem
			// 
			this.hardwareToolStripMenuItem.Name = "hardwareToolStripMenuItem";
			this.hardwareToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.hardwareToolStripMenuItem.Text = "Hardware";
			this.hardwareToolStripMenuItem.Click += new System.EventHandler(this.hardwareToolStripMenuItem_Click);
			// 
			// watchesToolStripMenuItem
			// 
			this.watchesToolStripMenuItem.Name = "watchesToolStripMenuItem";
			this.watchesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.watchesToolStripMenuItem.Text = "Watches";
			this.watchesToolStripMenuItem.Click += new System.EventHandler(this.watchesToolStripMenuItem_Click);
			// 
			// warningLabel
			// 
			this.warningLabel.BackColor = System.Drawing.SystemColors.Control;
			this.warningLabel.Location = new System.Drawing.Point(9, 286);
			this.warningLabel.Name = "warningLabel";
			this.warningLabel.Size = new System.Drawing.Size(217, 19);
			this.warningLabel.TabIndex = 5;
			this.warningLabel.Text = "Invalid instruction!";
			this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.warningLabel.Visible = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
			this.pictureBox1.Image = global::Lettuce.Properties.Resources.warning;
			this.pictureBox1.Location = new System.Drawing.Point(232, 287);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// Debugger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 310);
			this.Controls.Add(this.cycleCountLabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkBoxOnFire);
			this.Controls.Add(this.warningLabel);
			this.Controls.Add(this.labelQueuedInterrupts);
			this.Controls.Add(this.buttonStepOver);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.buttonStepInto);
			this.Controls.Add(this.checkBoxRunning);
			this.Controls.Add(this.checkBoxInterruptQueue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxRegisterPC);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxRegisterIA);
			this.Controls.Add(this.textBoxRegisterA);
			this.Controls.Add(this.textBoxRegisterEX);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxRegisterSP);
			this.Controls.Add(this.textBoxRegisterX);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textBoxRegisterB);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBoxRegisterY);
			this.Controls.Add(this.textBoxRegisterJ);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxRegisterC);
			this.Controls.Add(this.textBoxRegisterI);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxRegisterZ);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(468, 1000);
			this.Name = "Debugger";
			this.Text = "Debugger";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Debugger_KeyDown);
			this.Resize += new System.EventHandler(this.Debugger_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label labelQueuedInterrupts;
        private System.Windows.Forms.Button buttonStepOver;
        private System.Windows.Forms.Button buttonStepInto;
        private System.Windows.Forms.CheckBox checkBoxInterruptQueue;
        private System.Windows.Forms.TextBox textBoxRegisterPC;
        private System.Windows.Forms.TextBox textBoxRegisterIA;
        private System.Windows.Forms.TextBox textBoxRegisterEX;
        private System.Windows.Forms.TextBox textBoxRegisterSP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxRegisterJ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxRegisterI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRegisterZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxRegisterC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRegisterY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRegisterB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRegisterX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRegisterA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBoxRunning;
        private System.Windows.Forms.CheckBox checkBoxOnFire;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakOnInvalidInstructionToolStripMenuItem;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem keyboardToolStripMenuItem;
        private System.Windows.Forms.Label cycleCountLabel;
		private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disassemblyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem memoryToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem hardwareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem watchesToolStripMenuItem;
    }
}
