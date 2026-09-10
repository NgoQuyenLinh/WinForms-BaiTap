namespace BaiThucHanhBuoi1
{
    partial class MainForm
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
            this.lblTen = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.lblSaoChep = new System.Windows.Forms.Label();
            this.tbSaoChep = new System.Windows.Forms.TextBox();
            this.btnSaoChep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(55, 34);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(96, 13);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Nhập tên của bạn:";
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(181, 31);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(197, 20);
            this.tbTen.TabIndex = 1;
            this.tbTen.TextChanged += new System.EventHandler(this.tbTen_TextChanged);
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(181, 71);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 23);
            this.btnNhap.TabIndex = 2;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // lblSaoChep
            // 
            this.lblSaoChep.AutoSize = true;
            this.lblSaoChep.Location = new System.Drawing.Point(66, 111);
            this.lblSaoChep.Name = "lblSaoChep";
            this.lblSaoChep.Size = new System.Drawing.Size(72, 13);
            this.lblSaoChep.TabIndex = 3;
            this.lblSaoChep.Text = "Bạn đã nhập:";
            // 
            // tbSaoChep
            // 
            this.tbSaoChep.Location = new System.Drawing.Point(181, 108);
            this.tbSaoChep.Name = "tbSaoChep";
            this.tbSaoChep.ReadOnly = true;
            this.tbSaoChep.Size = new System.Drawing.Size(195, 20);
            this.tbSaoChep.TabIndex = 4;
            this.tbSaoChep.TextChanged += new System.EventHandler(this.tbTen_TextChanged);
            // 
            // btnSaoChep
            // 
            this.btnSaoChep.Location = new System.Drawing.Point(301, 71);
            this.btnSaoChep.Name = "btnSaoChep";
            this.btnSaoChep.Size = new System.Drawing.Size(75, 23);
            this.btnSaoChep.TabIndex = 5;
            this.btnSaoChep.Text = "Sao chép";
            this.btnSaoChep.UseVisualStyleBackColor = true;
            this.btnSaoChep.Click += new System.EventHandler(this.tbSaoChep_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaoChep);
            this.Controls.Add(this.tbSaoChep);
            this.Controls.Add(this.lblSaoChep);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.lblTen);
            this.Name = "MainForm";
            this.Text = "Chương trình đầu tiên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Label lblSaoChep;
        private System.Windows.Forms.TextBox tbSaoChep;
        private System.Windows.Forms.Button btnSaoChep;
    }
}

