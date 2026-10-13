using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmTimKiem : Form
    {
        private QuanLySinhVien qlsv;
        public List<SinhVien> KetQuaTimKiem { get; private set; }

        public frmTimKiem(QuanLySinhVien ql)
        {
            InitializeComponent();
            qlsv = ql;
        }

     

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Đọc dữ liệu từ 3 textbox mà bạn sẽ thêm vào form
            string mssv = txtMaSV.Text;
            string ten = txtHoTen.Text;
            string lop = cboLop.Text;

            KetQuaTimKiem = qlsv.TimKiem(mssv, ten, lop);
            if (KetQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào phù hợp với điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}