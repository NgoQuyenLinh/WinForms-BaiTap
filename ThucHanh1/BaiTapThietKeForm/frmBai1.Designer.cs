namespace BaiTapThietKeForm
{
    partial class frmBai1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBai1));
            this.pbXe = new System.Windows.Forms.PictureBox();
            this.gbMauXe = new System.Windows.Forms.GroupBox();
            this.rdTrang = new System.Windows.Forms.RadioButton();
            this.rdDo = new System.Windows.Forms.RadioButton();
            this.rdXanh = new System.Windows.Forms.RadioButton();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.tbDonGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnThanhTien = new System.Windows.Forms.Button();
            this.lblTongTienThanhToan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.nbSoLuong = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbXe)).BeginInit();
            this.gbMauXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // pbXe
            // 
            this.pbXe.Image = ((System.Drawing.Image)(resources.GetObject("pbXe.Image")));
            this.pbXe.Location = new System.Drawing.Point(185, 96);
            this.pbXe.Name = "pbXe";
            this.pbXe.Size = new System.Drawing.Size(300, 256);
            this.pbXe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbXe.TabIndex = 0;
            this.pbXe.TabStop = false;
            // 
            // gbMauXe
            // 
            this.gbMauXe.Controls.Add(this.rdTrang);
            this.gbMauXe.Controls.Add(this.rdDo);
            this.gbMauXe.Controls.Add(this.rdXanh);
            this.gbMauXe.Location = new System.Drawing.Point(559, 133);
            this.gbMauXe.Name = "gbMauXe";
            this.gbMauXe.Size = new System.Drawing.Size(200, 100);
            this.gbMauXe.TabIndex = 1;
            this.gbMauXe.TabStop = false;
            this.gbMauXe.Text = "Chọn màu xe";
            // 
            // rdTrang
            // 
            this.rdTrang.AutoSize = true;
            this.rdTrang.Location = new System.Drawing.Point(7, 74);
            this.rdTrang.Name = "rdTrang";
            this.rdTrang.Size = new System.Drawing.Size(64, 20);
            this.rdTrang.TabIndex = 2;
            this.rdTrang.TabStop = true;
            this.rdTrang.Text = "Trắng";
            this.rdTrang.UseVisualStyleBackColor = true;
            this.rdTrang.CheckedChanged += new System.EventHandler(this.rdTrang_CheckedChanged);
            // 
            // rdDo
            // 
            this.rdDo.AutoSize = true;
            this.rdDo.Location = new System.Drawing.Point(7, 49);
            this.rdDo.Name = "rdDo";
            this.rdDo.Size = new System.Drawing.Size(45, 20);
            this.rdDo.TabIndex = 1;
            this.rdDo.TabStop = true;
            this.rdDo.Text = "Đỏ";
            this.rdDo.UseVisualStyleBackColor = true;
            this.rdDo.CheckedChanged += new System.EventHandler(this.rdDo_CheckedChanged);
            // 
            // rdXanh
            // 
            this.rdXanh.AutoSize = true;
            this.rdXanh.Location = new System.Drawing.Point(7, 22);
            this.rdXanh.Name = "rdXanh";
            this.rdXanh.Size = new System.Drawing.Size(58, 20);
            this.rdXanh.TabIndex = 0;
            this.rdXanh.TabStop = true;
            this.rdXanh.Text = "Xanh";
            this.rdXanh.UseVisualStyleBackColor = true;
            this.rdXanh.CheckedChanged += new System.EventHandler(this.rdXanh_CheckedChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(548, 263);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(56, 16);
            this.lblDonGia.TabIndex = 2;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // tbDonGia
            // 
            this.tbDonGia.Location = new System.Drawing.Point(611, 260);
            this.tbDonGia.Name = "tbDonGia";
            this.tbDonGia.Size = new System.Drawing.Size(130, 22);
            this.tbDonGia.TabIndex = 3;
            this.tbDonGia.TextChanged += new System.EventHandler(this.tbDonGia_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "$";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(548, 298);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(63, 16);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // btnThanhTien
            // 
            this.btnThanhTien.Location = new System.Drawing.Point(615, 340);
            this.btnThanhTien.Name = "btnThanhTien";
            this.btnThanhTien.Size = new System.Drawing.Size(106, 23);
            this.btnThanhTien.TabIndex = 7;
            this.btnThanhTien.Text = "Tính tiền";
            this.btnThanhTien.UseVisualStyleBackColor = true;
            this.btnThanhTien.Click += new System.EventHandler(this.btnThanhTien_Click);
            // 
            // lblTongTienThanhToan
            // 
            this.lblTongTienThanhToan.AutoSize = true;
            this.lblTongTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTienThanhToan.Location = new System.Drawing.Point(401, 408);
            this.lblTongTienThanhToan.Name = "lblTongTienThanhToan";
            this.lblTongTienThanhToan.Size = new System.Drawing.Size(229, 22);
            this.lblTongTienThanhToan.TabIndex = 8;
            this.lblTongTienThanhToan.Text = "Tổng số tiền thanh toán:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(767, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "$";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThanhTien.Location = new System.Drawing.Point(659, 408);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(21, 22);
            this.lblThanhTien.TabIndex = 10;
            this.lblThanhTien.Text = "0";
            // 
            // nbSoLuong
            // 
            this.nbSoLuong.Location = new System.Drawing.Point(618, 298);
            this.nbSoLuong.Name = "nbSoLuong";
            this.nbSoLuong.Size = new System.Drawing.Size(120, 22);
            this.nbSoLuong.TabIndex = 11;
            this.nbSoLuong.ValueChanged += new System.EventHandler(this.nbSoLuong_ValueChanged);
            // 
            // frmBai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nbSoLuong);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTongTienThanhToan);
            this.Controls.Add(this.btnThanhTien);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDonGia);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.gbMauXe);
            this.Controls.Add(this.pbXe);
            this.Name = "frmBai1";
            this.Text = "frmBai1";
            ((System.ComponentModel.ISupportInitialize)(this.pbXe)).EndInit();
            this.gbMauXe.ResumeLayout(false);
            this.gbMauXe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbXe;
        private System.Windows.Forms.GroupBox gbMauXe;
        private System.Windows.Forms.RadioButton rdTrang;
        private System.Windows.Forms.RadioButton rdDo;
        private System.Windows.Forms.RadioButton rdXanh;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox tbDonGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnThanhTien;
        private System.Windows.Forms.Label lblTongTienThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.NumericUpDown nbSoLuong;
    }
}