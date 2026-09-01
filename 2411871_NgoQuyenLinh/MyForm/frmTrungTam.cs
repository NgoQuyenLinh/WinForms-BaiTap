using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyForm
{
    public partial class frmTrungTam : Form
    {
        public frmTrungTam()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Reset()
        {
            this.cboMaHV.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgayDangKy.Value = DateTime.Now; this.rdNam.Checked = true;
            this.chkTiengAnhA.Checked = false;
            this.chkTiengAnhB.Checked = false;
            this.chkTinHocA.Checked = false;
            this.chkTinHocB.Checked = false;
            this.txtTongTien.Text = "";
        }

            

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void chkTinHocB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTinHocA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTiengAnhA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTiengAnhB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (chkTinHocA.Checked)
                s += int.Parse(lblTienTHA.Text.Split('.')[0]);
            if (chkTinHocB.Checked)
                s += int.Parse(lblTienTHB.Text.Split('.')[0]);
            if (chkTiengAnhA.Checked)
                s += int.Parse(lblTienTAB.Text.Split('.')[0]);
            if (chkTiengAnhB.Checked)
                s += int.Parse(lblTienTAB.Text.Split('.')[0]);
            this.txtTongTien.Text = s + ".000 đồng";
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
