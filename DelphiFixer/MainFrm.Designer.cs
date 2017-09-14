namespace DelphiFixer {
    partial class MainFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.FixerEnabledCheckBx = new System.Windows.Forms.CheckBox();
            this.IntervalTextBx = new System.Windows.Forms.TextBox();
            this.SaveIntervalBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HiderTmr = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(774, 176);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // FixerEnabledCheckBx
            // 
            this.FixerEnabledCheckBx.AutoSize = true;
            this.FixerEnabledCheckBx.Location = new System.Drawing.Point(12, 12);
            this.FixerEnabledCheckBx.Name = "FixerEnabledCheckBx";
            this.FixerEnabledCheckBx.Size = new System.Drawing.Size(93, 17);
            this.FixerEnabledCheckBx.TabIndex = 2;
            this.FixerEnabledCheckBx.Text = "Hider Enabled";
            this.FixerEnabledCheckBx.UseVisualStyleBackColor = true;
            this.FixerEnabledCheckBx.CheckedChanged += new System.EventHandler(this.FixerEnabledCheckBx_CheckedChanged);
            // 
            // IntervalTextBx
            // 
            this.IntervalTextBx.Location = new System.Drawing.Point(517, 10);
            this.IntervalTextBx.Name = "IntervalTextBx";
            this.IntervalTextBx.Size = new System.Drawing.Size(100, 20);
            this.IntervalTextBx.TabIndex = 3;
            // 
            // SaveIntervalBtn
            // 
            this.SaveIntervalBtn.Location = new System.Drawing.Point(699, 8);
            this.SaveIntervalBtn.Name = "SaveIntervalBtn";
            this.SaveIntervalBtn.Size = new System.Drawing.Size(87, 23);
            this.SaveIntervalBtn.TabIndex = 4;
            this.SaveIntervalBtn.Text = "Save Interval";
            this.SaveIntervalBtn.UseVisualStyleBackColor = true;
            this.SaveIntervalBtn.Click += new System.EventHandler(this.SaveIntervalBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Check every";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "milliseconds";
            // 
            // HiderTmr
            // 
            this.HiderTmr.Tick += new System.EventHandler(this.HiderTmr_Tick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 225);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveIntervalBtn);
            this.Controls.Add(this.IntervalTextBx);
            this.Controls.Add(this.FixerEnabledCheckBx);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "Delphi SyncEdit Button Hider";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox FixerEnabledCheckBx;
        private System.Windows.Forms.TextBox IntervalTextBx;
        private System.Windows.Forms.Button SaveIntervalBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer HiderTmr;
    }
}

