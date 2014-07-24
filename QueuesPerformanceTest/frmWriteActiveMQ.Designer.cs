namespace QueuesPerformanceTest
{
    partial class frmWriteActiveMQ
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMessageSize = new System.Windows.Forms.ComboBox();
            this.btnPurge = new System.Windows.Forms.Button();
            this.btnWriteSync = new System.Windows.Forms.Button();
            this.btnWriteTask = new System.Windows.Forms.Button();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtNrThreads = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPersist = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Size";
            // 
            // cmbMessageSize
            // 
            this.cmbMessageSize.FormattingEnabled = true;
            this.cmbMessageSize.Items.AddRange(new object[] {
            "5KB",
            "50KB",
            "100KB",
            "500KB",
            "1000KB"});
            this.cmbMessageSize.Location = new System.Drawing.Point(142, 12);
            this.cmbMessageSize.Name = "cmbMessageSize";
            this.cmbMessageSize.Size = new System.Drawing.Size(71, 21);
            this.cmbMessageSize.TabIndex = 26;
            // 
            // btnPurge
            // 
            this.btnPurge.Location = new System.Drawing.Point(290, 307);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(91, 23);
            this.btnPurge.TabIndex = 25;
            this.btnPurge.Text = "Purge && Clear";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnWriteSync
            // 
            this.btnWriteSync.Location = new System.Drawing.Point(306, 10);
            this.btnWriteSync.Name = "btnWriteSync";
            this.btnWriteSync.Size = new System.Drawing.Size(75, 23);
            this.btnWriteSync.TabIndex = 24;
            this.btnWriteSync.Text = "Write Sync!";
            this.btnWriteSync.UseVisualStyleBackColor = true;
            this.btnWriteSync.Click += new System.EventHandler(this.btnWriteSync_Click);
            // 
            // btnWriteTask
            // 
            this.btnWriteTask.Location = new System.Drawing.Point(229, 10);
            this.btnWriteTask.Name = "btnWriteTask";
            this.btnWriteTask.Size = new System.Drawing.Size(75, 23);
            this.btnWriteTask.TabIndex = 23;
            this.btnWriteTask.Text = "Write Async!";
            this.btnWriteTask.UseVisualStyleBackColor = true;
            this.btnWriteTask.Click += new System.EventHandler(this.btnWriteTask_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(12, 329);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(0, 13);
            this.lblProcessing.TabIndex = 22;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 61);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(373, 240);
            this.txtResult.TabIndex = 21;
            // 
            // txtNrThreads
            // 
            this.txtNrThreads.Location = new System.Drawing.Point(31, 12);
            this.txtNrThreads.Name = "txtNrThreads";
            this.txtNrThreads.Size = new System.Drawing.Size(63, 20);
            this.txtNrThreads.TabIndex = 20;
            this.txtNrThreads.Text = "1000";
            this.txtNrThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "#";
            // 
            // chkPersist
            // 
            this.chkPersist.AutoSize = true;
            this.chkPersist.Location = new System.Drawing.Point(324, 39);
            this.chkPersist.Name = "chkPersist";
            this.chkPersist.Size = new System.Drawing.Size(57, 17);
            this.chkPersist.TabIndex = 28;
            this.chkPersist.Text = "Persist";
            this.chkPersist.UseVisualStyleBackColor = true;
            // 
            // frmWriteActiveMQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 351);
            this.Controls.Add(this.chkPersist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMessageSize);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.btnWriteSync);
            this.Controls.Add(this.btnWriteTask);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtNrThreads);
            this.Controls.Add(this.label1);
            this.Name = "frmWriteActiveMQ";
            this.Text = "Write ActiveMQ";
            this.Load += new System.EventHandler(this.frmWriteActiveMQ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMessageSize;
        private System.Windows.Forms.Button btnPurge;
        private System.Windows.Forms.Button btnWriteSync;
        private System.Windows.Forms.Button btnWriteTask;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtNrThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPersist;
    }
}