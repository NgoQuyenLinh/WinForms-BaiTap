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
            KieuTim kieu = KieuTim.TheoLop;
            if (rdMaSV.Checked) kieu = KieuTim.TheoMSSV;
            else if (rdHoTen.Checked) kieu = KieuTim.TheoTen;

            KetQuaTimKiem = qlsv.TimKiem(txtTim.Text, kieu);
            DialogResult = DialogResult.OK;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}