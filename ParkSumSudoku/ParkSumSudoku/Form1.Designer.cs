namespace ParkSumSudoku
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.diffselectCombo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.diffButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.richtest = new System.Windows.Forms.RichTextBox();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelselectCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.blockerPanel = new System.Windows.Forms.Panel();
            this.WinPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentVerticals = new System.Windows.Forms.Panel();
            this.currentHorizontals = new System.Windows.Forms.Panel();
            this.BRcurrent = new System.Windows.Forms.Panel();
            this.TRSolved = new System.Windows.Forms.Panel();
            this.horizontalSolved = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BRSolved = new System.Windows.Forms.Panel();
            this.verticalSolved = new System.Windows.Forms.Panel();
            this.TRcurrent = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.visTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.blockerPanel.SuspendLayout();
            this.WinPanel.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // diffselectCombo
            // 
            this.diffselectCombo.Cursor = System.Windows.Forms.Cursors.Default;
            this.diffselectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diffselectCombo.FormattingEnabled = true;
            resources.ApplyResources(this.diffselectCombo, "diffselectCombo");
            this.diffselectCombo.Name = "diffselectCombo";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // diffButton
            // 
            this.diffButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.diffButton, "diffButton");
            this.diffButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.diffButton.Name = "diffButton";
            this.diffButton.UseVisualStyleBackColor = false;
            this.diffButton.Click += new System.EventHandler(this.diffButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.solveButton, "solveButton");
            this.solveButton.ForeColor = System.Drawing.Color.Red;
            this.solveButton.Name = "solveButton";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click_1);
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.checkButton, "checkButton");
            this.checkButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkButton.Name = "checkButton";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pauseButton, "pauseButton");
            this.pauseButton.ForeColor = System.Drawing.Color.Blue;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // richtest
            // 
            resources.ApplyResources(this.richtest, "richtest");
            this.richtest.Name = "richtest";
            this.richtest.ReadOnly = true;
            // 
            // boardPanel
            // 
            resources.ApplyResources(this.boardPanel, "boardPanel");
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPanel_Paint_1);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.levelselectCombo);
            this.groupBox1.Controls.Add(this.diffButton);
            this.groupBox1.Controls.Add(this.diffselectCombo);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // levelselectCombo
            // 
            this.levelselectCombo.Cursor = System.Windows.Forms.Cursors.Default;
            this.levelselectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelselectCombo.FormattingEnabled = true;
            resources.ApplyResources(this.levelselectCombo, "levelselectCombo");
            this.levelselectCombo.Name = "levelselectCombo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.pauseButton);
            this.groupBox2.Controls.Add(this.solveButton);
            this.groupBox2.Controls.Add(this.checkButton);
            this.groupBox2.Controls.Add(this.resetButton);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // timerLabel
            // 
            resources.ApplyResources(this.timerLabel, "timerLabel");
            this.timerLabel.Name = "timerLabel";
            // 
            // blockerPanel
            // 
            this.blockerPanel.Controls.Add(this.WinPanel);
            this.blockerPanel.Controls.Add(this.label2);
            resources.ApplyResources(this.blockerPanel, "blockerPanel");
            this.blockerPanel.Name = "blockerPanel";
            this.blockerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.blockerPanel_Paint);
            // 
            // WinPanel
            // 
            this.WinPanel.Controls.Add(this.label3);
            resources.ApplyResources(this.WinPanel, "WinPanel");
            this.WinPanel.ForeColor = System.Drawing.Color.Green;
            this.WinPanel.Name = "WinPanel";
            this.WinPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WinPanel_Paint);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Name = "label2";
            // 
            // currentVerticals
            // 
            resources.ApplyResources(this.currentVerticals, "currentVerticals");
            this.currentVerticals.Name = "currentVerticals";
            // 
            // currentHorizontals
            // 
            resources.ApplyResources(this.currentHorizontals, "currentHorizontals");
            this.currentHorizontals.Name = "currentHorizontals";
            // 
            // BRcurrent
            // 
            resources.ApplyResources(this.BRcurrent, "BRcurrent");
            this.BRcurrent.Name = "BRcurrent";
            // 
            // TRSolved
            // 
            resources.ApplyResources(this.TRSolved, "TRSolved");
            this.TRSolved.Name = "TRSolved";
            // 
            // horizontalSolved
            // 
            resources.ApplyResources(this.horizontalSolved, "horizontalSolved");
            this.horizontalSolved.Name = "horizontalSolved";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.horizontalSolved);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // BRSolved
            // 
            resources.ApplyResources(this.BRSolved, "BRSolved");
            this.BRSolved.Name = "BRSolved";
            // 
            // verticalSolved
            // 
            resources.ApplyResources(this.verticalSolved, "verticalSolved");
            this.verticalSolved.Name = "verticalSolved";
            // 
            // TRcurrent
            // 
            resources.ApplyResources(this.TRcurrent, "TRcurrent");
            this.TRcurrent.Name = "TRcurrent";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TRSolved);
            this.groupBox3.Controls.Add(this.BRSolved);
            this.groupBox3.Controls.Add(this.verticalSolved);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BRcurrent);
            this.groupBox4.Controls.Add(this.TRcurrent);
            this.groupBox4.Controls.Add(this.currentVerticals);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.currentHorizontals);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // visTimer
            // 
            this.visTimer.Tick += new System.EventHandler(this.visTimer_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.timerLabel);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richtest);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.blockerPanel);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.blockerPanel.ResumeLayout(false);
            this.blockerPanel.PerformLayout();
            this.WinPanel.ResumeLayout(false);
            this.WinPanel.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox diffselectCombo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button diffButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.RichTextBox richtest;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox levelselectCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel blockerPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel currentVerticals;
        private System.Windows.Forms.Panel currentHorizontals;
        private System.Windows.Forms.Panel BRcurrent;
        private System.Windows.Forms.Panel TRSolved;
        private System.Windows.Forms.Panel horizontalSolved;
        private System.Windows.Forms.Panel BRSolved;
        private System.Windows.Forms.Panel verticalSolved;
        private System.Windows.Forms.Panel TRcurrent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer visTimer;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel WinPanel;
        private System.Windows.Forms.Label label3;
    }
}

