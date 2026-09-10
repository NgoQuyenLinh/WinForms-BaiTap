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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void frmBai2_Load(object sender, EventArgs e)
        {

        }

        private void lblHangHoaDaMua_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soTien = 0;
            foreach(var hang in lbHangDaMua.Items)
            {
                switch (hang)
                {
                    case "Chuột":
                        soTien += 100000;
                        break;
                    case "Bàn phím":
                        soTien += 150000;
                        break;
                    case "Máy in":
                        soTien += 2000000;
                        break;
                    case "USB Kingmax":
                        soTien += 200000;
                        break;
                }
            }
            lblThanhTien.Text = soTien.ToString() + " đồng";
        }

        private void btnChonHang_Click(object sender, EventArgs e)
        {
            var item = lbHangHoa.SelectedItem;
            lbHangDaMua.Items.Add(item);
        }

        private void lblTongTienThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            lbHangDaMua.Items.Remove(lbHangHoa.SelectedItem);
        }

        private void lblThanhTien_Click(object sender, EventArgs e)
        {

        }
    }
}
