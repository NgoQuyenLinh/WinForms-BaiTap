using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanhBuoi1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            var tenDaNhap = tbTen.Text;
            MessageBox.Show($"Xin chào bạn {tenDaNhap}, rất vui được gặp bạn");
        }


        private void tbSaoChep_Click(object sender, EventArgs e)
        {
            tbSaoChep.Text = tbTen.Text;
        }

        private void tbSaoChep_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbTen_TextChanged(object sender, EventArgs e)
        {
            tbSaoChep.Text = tbTen.Text;
        }
    }
}
 