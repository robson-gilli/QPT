namespace QueuesPerformanceTest
{
    partial class frmReadActiveMQ
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnPeek = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnReadAll = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnListQueue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 16;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(535, 10);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 15;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnPeek
            // 
            this.btnPeek.Location = new System.Drawing.Point(457, 10);
            this.btnPeek.Name = "btnPeek";
            this.btnPeek.Size = new System.Drawing.Size(75, 23);
            this.btnPeek.TabIndex = 14;
            this.btnPeek.Text = "Peek";
            this.btnPeek.UseVisualStyleBackColor = true;
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(222, 11);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(231, 20);
            this.txtId.TabIndex = 13;
            // 
            // btnReadAll
            // 
            this.btnReadAll.Location = new System.Drawing.Point(89, 10);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(75, 23);
            this.btnReadAll.TabIndex = 12;
            this.btnReadAll.Text = "Read All";
            this.btnReadAll.UseVisualStyleBackColor = true;
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(13, 40);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(597, 357);
            this.txtResult.TabIndex = 11;
            // 
            // btnListQueue
            // 
            this.btnListQueue.Location = new System.Drawing.Point(13, 10);
            this.btnListQueue.Name = "btnListQueue";
            this.btnListQueue.Size = new System.Drawing.Size(75, 23);
            this.btnListQueue.TabIndex = 10;
            this.btnListQueue.Text = "List";
            this.btnListQueue.UseVisualStyleBackColor = true;
            this.btnListQueue.Click += new System.EventHandler(this.btnListQueue_Click);
            // 
            // frmReadActiveMQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnPeek);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnReadAll);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnListQueue);
            this.Name = "frmReadActiveMQ";
            this.Text = "Read ActiveMQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnPeek;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnReadAll;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnListQueue;
    }
}