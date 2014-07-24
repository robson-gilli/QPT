namespace QueuesPerformanceTest
{
    partial class MDIParent
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.escreverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeMQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSMQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeMQToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSMQToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.escutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeMQToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escreverToolStripMenuItem,
            this.lerToolStripMenuItem,
            this.escutarToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(793, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // escreverToolStripMenuItem
            // 
            this.escreverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeMQToolStripMenuItem,
            this.arquivoToolStripMenuItem,
            this.mSMQToolStripMenuItem});
            this.escreverToolStripMenuItem.Name = "escreverToolStripMenuItem";
            this.escreverToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.escreverToolStripMenuItem.Text = "Escrever";
            // 
            // activeMQToolStripMenuItem
            // 
            this.activeMQToolStripMenuItem.Name = "activeMQToolStripMenuItem";
            this.activeMQToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.activeMQToolStripMenuItem.Text = "ActiveMQ";
            this.activeMQToolStripMenuItem.Click += new System.EventHandler(this.activeMQToolStripMenuItem_Click);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            this.arquivoToolStripMenuItem.Click += new System.EventHandler(this.arquivoToolStripMenuItem_Click);
            // 
            // mSMQToolStripMenuItem
            // 
            this.mSMQToolStripMenuItem.Name = "mSMQToolStripMenuItem";
            this.mSMQToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.mSMQToolStripMenuItem.Text = "MSMQ";
            this.mSMQToolStripMenuItem.Click += new System.EventHandler(this.mSMQToolStripMenuItem_Click);
            // 
            // lerToolStripMenuItem
            // 
            this.lerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeMQToolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.mSMQToolStripMenuItem1});
            this.lerToolStripMenuItem.Name = "lerToolStripMenuItem";
            this.lerToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.lerToolStripMenuItem.Text = "Ler";
            // 
            // activeMQToolStripMenuItem1
            // 
            this.activeMQToolStripMenuItem1.Name = "activeMQToolStripMenuItem1";
            this.activeMQToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.activeMQToolStripMenuItem1.Text = "ActiveMQ";
            this.activeMQToolStripMenuItem1.Click += new System.EventHandler(this.activeMQToolStripMenuItem1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // mSMQToolStripMenuItem1
            // 
            this.mSMQToolStripMenuItem1.Name = "mSMQToolStripMenuItem1";
            this.mSMQToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.mSMQToolStripMenuItem1.Text = "MSMQ";
            this.mSMQToolStripMenuItem1.Click += new System.EventHandler(this.mSMQToolStripMenuItem1_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(793, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // escutarToolStripMenuItem
            // 
            this.escutarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeMQToolStripMenuItem2});
            this.escutarToolStripMenuItem.Name = "escutarToolStripMenuItem";
            this.escutarToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.escutarToolStripMenuItem.Text = "Escutar";
            // 
            // activeMQToolStripMenuItem2
            // 
            this.activeMQToolStripMenuItem2.Name = "activeMQToolStripMenuItem2";
            this.activeMQToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.activeMQToolStripMenuItem2.Text = "ActiveMQ";
            this.activeMQToolStripMenuItem2.Click += new System.EventHandler(this.activeMQToolStripMenuItem2_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIParent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem escreverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSMQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSMQToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeMQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeMQToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem escutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeMQToolStripMenuItem2;
    }
}



