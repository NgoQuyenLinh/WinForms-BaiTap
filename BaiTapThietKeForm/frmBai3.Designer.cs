namespace BaiTapThietKeForm
{
    partial class frmBai3
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
            this.lblTuMoi = new System.Windows.Forms.Label();
            this.lblNghiaCuaTu = new System.Windows.Forms.Label();
            this.txtTuMoi = new System.Windows.Forms.TextBox();
            this.txtNghiaCuaTu = new System.Windows.Forms.TextBox();
            this.lblListDanhSach = new System.Windows.Forms.Label();
            this.lblDSNghiaCuaTu = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnThemTu = new System.Windows.Forms.Button();
            this.txtHienThiNghia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTuMoi
            // 
            this.lblTuMoi.AutoSize = true;
            this.lblTuMoi.Location = new System.Drawing.Point(110, 54);
            this.lblTuMoi.Name = "lblTuMoi";
            this.lblTuMoi.Size = new System.Drawing.Size(23, 16);
            this.lblTuMoi.TabIndex = 0;
            this.lblTuMoi.Text = "Từ";
            this.lblTuMoi.Click += new System.EventHandler(this.lblTuMoi_Click);
            // 
            // lblNghiaCuaTu
            // 
            this.lblNghiaCuaTu.AutoSize = true;
            this.lblNghiaCuaTu.Location = new System.Drawing.Point(110, 111);
            this.lblNghiaCuaTu.Name = "lblNghiaCuaTu";
            this.lblNghiaCuaTu.Size = new System.Drawing.Size(83, 16);
            this.lblNghiaCuaTu.TabIndex = 1;
            this.lblNghiaCuaTu.Text = "Nghĩa của từ";
            // 
            // txtTuMoi
            // 
            this.txtTuMoi.Location = new System.Drawing.Point(226, 51);
            this.txtTuMoi.Name = "txtTuMoi";
            this.txtTuMoi.Size = new System.Drawing.Size(295, 22);
            this.txtTuMoi.TabIndex = 2;
            this.txtTuMoi.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNghiaCuaTu
            // 
            this.txtNghiaCuaTu.Location = new System.Drawing.Point(226, 105);
            this.txtNghiaCuaTu.Name = "txtNghiaCuaTu";
            this.txtNghiaCuaTu.Size = new System.Drawing.Size(295, 22);
            this.txtNghiaCuaTu.TabIndex = 3;
            // 
            // lblListDanhSach
            // 
            this.lblListDanhSach.AutoSize = true;
            this.lblListDanhSach.Location = new System.Drawing.Point(148, 212);
            this.lblListDanhSach.Name = "lblListDanhSach";
            this.lblListDanhSach.Size = new System.Drawing.Size(135, 16);
            this.lblListDanhSach.TabIndex = 4;
            this.lblListDanhSach.Text = "DANH SÁCH TỪ MỚI";
            this.lblListDanhSach.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDSNghiaCuaTu
            // 
            this.lblDSNghiaCuaTu.AutoSize = true;
            this.lblDSNghiaCuaTu.Location = new System.Drawing.Point(524, 212);
            this.lblDSNghiaCuaTu.Name = "lblDSNghiaCuaTu";
            this.lblDSNghiaCuaTu.Size = new System.Drawing.Size(104, 16);
            this.lblDSNghiaCuaTu.TabIndex = 5;
            this.lblDSNghiaCuaTu.Text = "NGHĨA CỦA TỪ";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(48, 252);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(356, 184);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnThemTu
            // 
            this.btnThemTu.Location = new System.Drawing.Point(226, 154);
            this.btnThemTu.Name = "btnThemTu";
            this.btnThemTu.Size = new System.Drawing.Size(178, 23);
            this.btnThemTu.TabIndex = 8;
            this.btnThemTu.Text = "Thêm từ mới";
            this.btnThemTu.UseVisualStyleBackColor = true;
            this.btnThemTu.Click += new System.EventHandler(this.btnThemTu_Click);
            // 
            // txtHienThiNghia
            // 
            this.txtHienThiNghia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHienThiNghia.Location = new System.Drawing.Point(420, 252);
            this.txtHienThiNghia.Multiline = true;
            this.txtHienThiNghia.Name = "txtHienThiNghia";
            this.txtHienThiNghia.ReadOnly = true;
            this.txtHienThiNghia.Size = new System.Drawing.Size(349, 186);
            this.txtHienThiNghia.TabIndex = 9;
            this.txtHienThiNghia.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // frmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtHienThiNghia);
            this.Controls.Add(this.btnThemTu);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblDSNghiaCuaTu);
            this.Controls.Add(this.lblListDanhSach);
            this.Controls.Add(this.txtNghiaCuaTu);
            this.Controls.Add(this.txtTuMoi);
            this.Controls.Add(this.lblNghiaCuaTu);
            this.Controls.Add(this.lblTuMoi);
            this.Name = "frmBai3";
            this.Text = "frmBai3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTuMoi;
        private System.Windows.Forms.Label lblNghiaCuaTu;
        private System.Windows.Forms.TextBox txtTuMoi;
        private System.Windows.Forms.TextBox txtNghiaCuaTu;
        private System.Windows.Forms.Label lblListDanhSach;
        private System.Windows.Forms.Label lblDSNghiaCuaTu;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnThemTu;
        private System.Windows.Forms.TextBox txtHienThiNghia;
    }
}