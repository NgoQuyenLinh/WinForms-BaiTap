using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CTQLGV
{
    public partial class frmGiangVien : Form
    {
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            string lienHe = "https://cntt.dlu.edu.vn/";

            this.linklblLienHe.Links.Add(0, lienHe.Length, lienHe);

            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachHP.SelectedItems.Count - 1;

            while (i >= 0)
            {
                this.lbHocPhanDay.Items.Add(
                    this.lbDanhSachHP.SelectedItems[i]);

                this.lbDanhSachHP.Items.Remove(
                    this.lbDanhSachHP.SelectedItems[i]);

                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbHocPhanDay.SelectedItems.Count - 1;

            while (i >= 0)
            {
                this.lbDanhSachHP.Items.Add(
                    this.lbHocPhanDay.SelectedItems[i]);

                this.lbHocPhanDay.Items.Remove(
                    this.lbHocPhanDay.SelectedItems[i]);

                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;

            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);
            }

            foreach (object hp in lbHocPhanDay.Items)
            {
                this.lbDanhSachHP.Items.Add(hp);
            }

            this.lbHocPhanDay.Items.Clear();
        }
        // Lấy thông tin của giảng viên được nhập trên form
        private GiangVien GetGiangVien()
        {
            string gt = "Nam";

            if (rdNu.Checked)
                gt = "Nữ";

            GiangVien gv = new GiangVien();

            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;

            string ngoaiNgu = "";

            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
            {
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaiNgu += chklbNgoaiNgu.Items[i] + ";";
            }

            gv.NgoaiNgu = ngoaiNgu.Split(';');

            DanhMucHocPhan dshp = new DanhMucHocPhan();

            foreach (object hp in lbHocPhanDay.Items)
            {
                dshp.Them(new HocPhan(hp.ToString()));
            }

            gv.dsHocPhan = dshp;

            return gv;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            GiangVien gv = GetGiangVien();
            using (frmTBGiangVien frm = new frmTBGiangVien())
            {
                frm.SetText(gv.ToString());
                frm.ShowDialog(this);
            }
        }

        private void linklblLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strlink = e.Link.LinkData.ToString();
            Process.Start(new ProcessStartInfo
            {
                FileName = strlink,
                UseShellExecute = true
            });
        }
    }
}
