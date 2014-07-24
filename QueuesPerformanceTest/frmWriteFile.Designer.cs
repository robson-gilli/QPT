namespace QueuesPerformanceTest
{
    partial class frmWriteFile
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
            this.btnWriteSync = new System.Windows.Forms.Button();
            this.btnWriteTask = new System.Windows.Forms.Button();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtNrThreads = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbMessageSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWriteSync
            // 
            this.btnWriteSync.Location = new System.Drawing.Point(309, 9);
            this.btnWriteSync.Name = "btnWriteSync";
            this.btnWriteSync.Size = new System.Drawing.Size(75, 23);
            this.btnWriteSync.TabIndex = 13;
            this.btnWriteSync.Text = "Write Sync!";
            this.btnWriteSync.UseVisualStyleBackColor = true;
            this.btnWriteSync.Click += new System.EventHandler(this.btnWriteSync_Click);
            // 
            // btnWriteTask
            // 
            this.btnWriteTask.Location = new System.Drawing.Point(232, 9);
            this.btnWriteTask.Name = "btnWriteTask";
            this.btnWriteTask.Size = new System.Drawing.Size(75, 23);
            this.btnWriteTask.TabIndex = 12;
            this.btnWriteTask.Text = "Write Async!";
            this.btnWriteTask.UseVisualStyleBackColor = true;
            this.btnWriteTask.Click += new System.EventHandler(this.btnWriteTask_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(15, 308);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(0, 13);
            this.lblProcessing.TabIndex = 11;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 40);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(373, 240);
            this.txtResult.TabIndex = 10;
            // 
            // txtNrThreads
            // 
            this.txtNrThreads.Location = new System.Drawing.Point(33, 11);
            this.txtNrThreads.Name = "txtNrThreads";
            this.txtNrThreads.Size = new System.Drawing.Size(63, 20);
            this.txtNrThreads.TabIndex = 9;
            this.txtNrThreads.Text = "1000";
            this.txtNrThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "#";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(309, 296);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete Files!";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.cmbMessageSize.Location = new System.Drawing.Point(147, 10);
            this.cmbMessageSize.Name = "cmbMessageSize";
            this.cmbMessageSize.Size = new System.Drawing.Size(71, 21);
            this.cmbMessageSize.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Size";
            // 
            // frmWriteFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMessageSize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnWriteSync);
            this.Controls.Add(this.btnWriteTask);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtNrThreads);
            this.Controls.Add(this.label1);
            this.Name = "frmWriteFile";
            this.Text = "Write to File";
            this.Load += new System.EventHandler(this.frmWriteFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteSync;
        private System.Windows.Forms.Button btnWriteTask;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtNrThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbMessageSize;
        private System.Windows.Forms.Label label2;
    }
}