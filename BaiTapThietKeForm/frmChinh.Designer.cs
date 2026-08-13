namespace BaiTapThietKeForm
{
    partial class frmChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmibai1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmibai2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmibai3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bai4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmibai1,
            this.tsmibai2,
            this.tsmibai3,
            this.bai4ToolStripMenuItem});
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.nToolStripMenuItem.Text = "Ngô Quyền Linh";
            this.nToolStripMenuItem.Click += new System.EventHandler(this.nToolStripMenuItem_Click);
            // 
            // tsmibai1
            // 
            this.tsmibai1.Image = ((System.Drawing.Image)(resources.GetObject("tsmibai1.Image")));
            this.tsmibai1.Name = "tsmibai1";
            this.tsmibai1.Size = new System.Drawing.Size(224, 26);
            this.tsmibai1.Text = "Bài 1";
            this.tsmibai1.Click += new System.EventHandler(this.tsmibai1_Click);
            // 
            // tsmibai2
            // 
            this.tsmibai2.Image = ((System.Drawing.Image)(resources.GetObject("tsmibai2.Image")));
            this.tsmibai2.Name = "tsmibai2";
            this.tsmibai2.Size = new System.Drawing.Size(224, 26);
            this.tsmibai2.Text = "Bài 2";
            this.tsmibai2.Click += new System.EventHandler(this.tsmibai2_Click);
            // 
            // tsmibai3
            // 
            this.tsmibai3.Image = ((System.Drawing.Image)(resources.GetObject("tsmibai3.Image")));
            this.tsmibai3.Name = "tsmibai3";
            this.tsmibai3.Size = new System.Drawing.Size(224, 26);
            this.tsmibai3.Text = "Bài 3";
            this.tsmibai3.Click += new System.EventHandler(this.tsmibai3_Click);
            // 
            // bai4ToolStripMenuItem
            // 
            this.bai4ToolStripMenuItem.Name = "bai4ToolStripMenuItem";
            this.bai4ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.bai4ToolStripMenuItem.Text = "Bài 4";
            this.bai4ToolStripMenuItem.Click += new System.EventHandler(this.bai4ToolStripMenuItem_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmChinh";
            this.Text = "Chương trình chính";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmibai1;
        private System.Windows.Forms.ToolStripMenuItem tsmibai2;
        private System.Windows.Forms.ToolStripMenuItem tsmibai3;
        private System.Windows.Forms.ToolStripMenuItem bai4ToolStripMenuItem;
    }
}

