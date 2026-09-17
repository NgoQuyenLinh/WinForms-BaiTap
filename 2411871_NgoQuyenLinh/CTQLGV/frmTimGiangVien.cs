using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQLGV
{
    public partial class frmTimGiangVien : Form
    {
        QuanLyGiangVien qlgv;
        public frmTimGiangVien(QuanLyGiangVien ds)
        {   
            InitializeComponent();
            this.qlgv = ds;
        }

        private void rdMaGV_CheckedChanged(object sender, EventArgs e)
        {
            if(rdMaGV.Checked)
            {
                lbTimKiem.Text = "Mã GV";
            }
        }

        private void rdHoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdHoTen.Checked)
            {
                lbTimKiem.Text = "Họ tên";
            }
        }

        private void rdSoDT_CheckedChanged(object sender, EventArgs e)
        {
            if(rdSoDT.Checked)
            {
                lbTimKiem.Text = "Số điện thoại";
            }    
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            GiangVien gv = null;

            if (rdMaGV.Checked)
            {
                gv = qlgv.Tim(txtTimKiem.Text, KieuTim.TheoMa);
            }
            else if (rdHoTen.Checked)
            {
                gv = qlgv.Tim(txtTimKiem.Text, KieuTim.TheoHoTen);
            }
            else
            {
                gv = qlgv.Tim(txtTimKiem.Text, KieuTim.TheoSDT);
            }
 

            if (gv != null)
            {
                using (frmTBGiangVien frm = new frmTBGiangVien())
                {
                    frm.SetText(gv.ToString());
                    frm.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy giảng viên!");
            }
        }

        private void frmTimGiangVien_Load(object sender, EventArgs e)
        {

        }
    }
}
