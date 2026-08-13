namespace BaiTapThietKeForm
{
    partial class frmBai2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonHang = new System.Windows.Forms.Button();
            this.lbHangHoa = new System.Windows.Forms.ListBox();
            this.lblHangHoa = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblTongTienThanhToan = new System.Windows.Forms.Label();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnTraHang = new System.Windows.Forms.Button();
            this.lbHangDaMua = new System.Windows.Forms.ListBox();
            this.lblHangDaMua = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChonHang);
            this.panel1.Controls.Add(this.lbHangHoa);
            this.panel1.Controls.Add(this.lblHangHoa);
            this.panel1.Location = new System.Drawing.Point(26, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 401);
            this.panel1.TabIndex = 0;
            // 
            // btnChonHang
            // 
            this.btnChonHang.Location = new System.Drawing.Point(221, 189);
            this.btnChonHang.Name = "btnChonHang";
            this.btnChonHang.Size = new System.Drawing.Size(118, 23);
            this.btnChonHang.TabIndex = 2;
            this.btnChonHang.Text = "Chọn hàng >";
            this.btnChonHang.UseVisualStyleBackColor = true;
            this.btnChonHang.Click += new System.EventHandler(this.btnChonHang_Click);
            // 
            // lbHangHoa
            // 
            this.lbHangHoa.FormattingEnabled = true;
            this.lbHangHoa.ItemHeight = 16;
            this.lbHangHoa.Items.AddRange(new object[] {
            "Chuột",
            "Bàn phím",
            "Máy in",
            "USB Kingmax"});
            this.lbHangHoa.Location = new System.Drawing.Point(16, 97);
            this.lbHangHoa.Name = "lbHangHoa";
            this.lbHangHoa.Size = new System.Drawing.Size(183, 228);
            this.lbHangHoa.TabIndex = 1;
            // 
            // lblHangHoa
            // 
            this.lblHangHoa.AutoSize = true;
            this.lblHangHoa.Location = new System.Drawing.Point(42, 56);
            this.lblHangHoa.Name = "lblHangHoa";
            this.lblHangHoa.Size = new System.Drawing.Size(130, 16);
            this.lblHangHoa.TabIndex = 0;
            this.lblHangHoa.Text = "Danh sách hàng hóa";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblThanhTien);
            this.panel2.Controls.Add(this.lblTongTienThanhToan);
            this.panel2.Controls.Add(this.btnTinhTien);
            this.panel2.Controls.Add(this.btnTraHang);
            this.panel2.Controls.Add(this.lbHangDaMua);
            this.panel2.Controls.Add(this.lblHangDaMua);
            this.panel2.Location = new System.Drawing.Point(387, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 401);
            this.panel2.TabIndex = 3;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThanhTien.Location = new System.Drawing.Point(247, 372);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(17, 18);
            this.lblThanhTien.TabIndex = 13;
            this.lblThanhTien.Text = "0";
            this.lblThanhTien.Click += new System.EventHandler(this.lblThanhTien_Click);
            // 
            // lblTongTienThanhToan
            // 
            this.lblTongTienThanhToan.AutoSize = true;
            this.lblTongTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTienThanhToan.Location = new System.Drawing.Point(26, 371);
            this.lblTongTienThanhToan.Name = "lblTongTienThanhToan";
            this.lblTongTienThanhToan.Size = new System.Drawing.Size(191, 18);
            this.lblTongTienThanhToan.TabIndex = 11;
            this.lblTongTienThanhToan.Text = "Tổng số tiền thanh toán:";
            this.lblTongTienThanhToan.Click += new System.EventHandler(this.lblTongTienThanhToan_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(219, 340);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(75, 23);
            this.btnTinhTien.TabIndex = 3;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTraHang
            // 
            this.btnTraHang.Location = new System.Drawing.Point(20, 189);
            this.btnTraHang.Name = "btnTraHang";
            this.btnTraHang.Size = new System.Drawing.Size(104, 23);
            this.btnTraHang.TabIndex = 2;
            this.btnTraHang.Text = "< Trả hàng";
            this.btnTraHang.UseVisualStyleBackColor = true;
            this.btnTraHang.Click += new System.EventHandler(this.btnTraHang_Click);
            // 
            // lbHangDaMua
            // 
            this.lbHangDaMua.FormattingEnabled = true;
            this.lbHangDaMua.ItemHeight = 16;
            this.lbHangDaMua.Location = new System.Drawing.Point(150, 97);
            this.lbHangDaMua.Name = "lbHangDaMua";
            this.lbHangDaMua.Size = new System.Drawing.Size(183, 228);
            this.lbHangDaMua.TabIndex = 1;
            // 
            // lblHangDaMua
            // 
            this.lblHangDaMua.AutoSize = true;
            this.lblHangDaMua.Location = new System.Drawing.Point(147, 56);
            this.lblHangDaMua.Name = "lblHangDaMua";
            this.lblHangDaMua.Size = new System.Drawing.Size(179, 16);
            this.lblHangDaMua.TabIndex = 0;
            this.lblHangDaMua.Text = "Các mặt hàng khách đã mua:";
            this.lblHangDaMua.Click += new System.EventHandler(this.lblHangHoaDaMua_Click);
            // 
            // frmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBai2";
            this.Text = "frmBai2";
            this.Load += new System.EventHandler(this.frmBai2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChonHang;
        private System.Windows.Forms.ListBox lbHangHoa;
        private System.Windows.Forms.Label lblHangHoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTraHang;
        private System.Windows.Forms.ListBox lbHangDaMua;
        private System.Windows.Forms.Label lblHangDaMua;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblTongTienThanhToan;
    }
}