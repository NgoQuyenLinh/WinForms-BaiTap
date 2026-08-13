using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm
{
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbDonGia_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void rdXanh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdXanh.Checked)
                tbDonGia.Text = "22000";
        }

        private void rdDo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDo.Checked)
                tbDonGia.Text = "21000";
        }

        private void rdTrang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTrang.Checked)
                tbDonGia.Text = "20000";
        }

        private void btnThanhTien_Click(object sender, EventArgs e)
        {
            if (nbSoLuong.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo!");
                return;
            }
            int soTien=int.Parse(tbDonGia.Text);
            int thanhTien = (int)(soTien * nbSoLuong.Value);
            lblThanhTien.Text = thanhTien.ToString();
        }

        private void nbSoLuong_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
