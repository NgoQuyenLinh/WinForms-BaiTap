namespace QuanLySinhVien
{
    partial class frmTimKiem
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
            this.gbNhapThongTin = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTuyChon = new System.Windows.Forms.GroupBox();
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.rdHoTen = new System.Windows.Forms.RadioButton();
            this.rdMaSV = new System.Windows.Forms.RadioButton();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbNhapThongTin.SuspendLayout();
            this.gbTuyChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNhapThongTin
            // 
            this.gbNhapThongTin.Controls.Add(this.btnTim);
            this.gbNhapThongTin.Controls.Add(this.txtTim);
            this.gbNhapThongTin.Controls.Add(this.label1);
            this.gbNhapThongTin.Location = new System.Drawing.Point(29, 94);
            this.gbNhapThongTin.Name = "gbNhapThongTin";
            this.gbNhapThongTin.Size = new System.Drawing.Size(335, 46);
            this.gbNhapThongTin.TabIndex = 8;
            this.gbNhapThongTin.TabStop = false;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.Blue;
            this.btnTim.Location = new System.Drawing.Point(260, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(69, 26);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(96, 14);
            this.txtTim.Multiline = true;
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(158, 25);
            this.txtTim.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin";
            // 
            // gbTuyChon
            // 
            this.gbTuyChon.Controls.Add(this.rdLop);
            this.gbTuyChon.Controls.Add(this.rdHoTen);
            this.gbTuyChon.Controls.Add(this.rdMaSV);
            this.gbTuyChon.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTuyChon.Location = new System.Drawing.Point(29, 17);
            this.gbTuyChon.Name = "gbTuyChon";
            this.gbTuyChon.Size = new System.Drawing.Size(335, 70);
            this.gbTuyChon.TabIndex = 7;
            this.gbTuyChon.TabStop = false;
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLop.ForeColor = System.Drawing.Color.Blue;
            this.rdLop.Location = new System.Drawing.Point(231, 29);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(54, 23);
            this.rdLop.TabIndex = 2;
            this.rdLop.Text = "Lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            // 
            // rdHoTen
            // 
            this.rdHoTen.AutoSize = true;
            this.rdHoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdHoTen.ForeColor = System.Drawing.Color.Blue;
            this.rdHoTen.Location = new System.Drawing.Point(121, 29);
            this.rdHoTen.Name = "rdHoTen";
            this.rdHoTen.Size = new System.Drawing.Size(77, 23);
            this.rdHoTen.TabIndex = 1;
            this.rdHoTen.Text = "Họ Tên";
            this.rdHoTen.UseVisualStyleBackColor = true;
            // 
            // rdMaSV
            // 
            this.rdMaSV.AutoSize = true;
            this.rdMaSV.Checked = true;
            this.rdMaSV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMaSV.ForeColor = System.Drawing.Color.Blue;
            this.rdMaSV.Location = new System.Drawing.Point(7, 29);
            this.rdMaSV.Name = "rdMaSV";
            this.rdMaSV.Size = new System.Drawing.Size(75, 23);
            this.rdMaSV.TabIndex = 0;
            this.rdMaSV.TabStop = true;
            this.rdMaSV.Text = "Mã SV";
            this.rdMaSV.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Blue;
            this.btnThoat.Location = new System.Drawing.Point(158, 146);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(69, 26);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 180);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbNhapThongTin);
            this.Controls.Add(this.gbTuyChon);
            this.Name = "frmTimKiem";
            this.Text = "frmTimKiem";
            this.gbNhapThongTin.ResumeLayout(false);
            this.gbNhapThongTin.PerformLayout();
            this.gbTuyChon.ResumeLayout(false);
            this.gbTuyChon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNhapThongTin;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTuyChon;
        private System.Windows.Forms.RadioButton rdLop;
        private System.Windows.Forms.RadioButton rdHoTen;
        private System.Windows.Forms.RadioButton rdMaSV;
        private System.Windows.Forms.Button btnThoat;
    }
}