using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQLSVCNTT
{
    public partial class frmQuanLySinhVienCNTT : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        bool daThayDoi = false;
        public frmQuanLySinhVienCNTT()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {

            if (openFileDialogHinh.ShowDialog() == DialogResult.OK)
            {
                this.txtHinh.Text = openFileDialogHinh.FileName;
                this.pbHinh.ImageLocation = openFileDialogHinh.FileName;
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            string mssv = lvSinhVien.SelectedItems[0].Text;
            SinhVien sv = qlsv.TimTheoMSSV(mssv);
            if (sv != null) HienThiSinhVien(sv);
        }

        private void gbThongTinSinhVIen_Enter(object sender, EventArgs e)
        {

        }
        private SinhVien LayThongTinTuForm()
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = mtxtMSSV.Text.Trim();
            sv.Ten = txtTen.Text.Trim();
            sv.Email = txtEmail.Text.Trim();
            sv.DiaChi = txtDiaChi.Text.Trim();
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Phai = rdNam.Checked ? "Nam" : "Nữ";
            sv.Lop = cbLop.Text;
            sv.SoDT = mtxtSoDT.Text.Trim();
            sv.Hinh = txtHinh.Text.Trim();
            return sv;
        }
        private void HienThiSinhVien(SinhVien sv)
        {
            mtxtMSSV.Text = sv.MSSV;
            txtTen.Text = sv.Ten;
            txtEmail.Text = sv.Email;
            txtDiaChi.Text = sv.DiaChi;
            dtpNgaySinh.Value = sv.NgaySinh;

            if (sv.Phai == "Nam") rdNam.Checked = true;
            else rdNu.Checked = true;

            cbLop.Text = sv.Lop;
            mtxtSoDT.Text = sv.SoDT;
            txtHinh.Text = sv.Hinh;

            // Load hình nếu file tồn tại
            if (!string.IsNullOrEmpty(sv.Hinh) && File.Exists(sv.Hinh))
                pbHinh.ImageLocation = sv.Hinh;
            else
                pbHinh.ImageLocation = "";
        }

        private void ThemVaoListView(SinhVien sv)
        {
            ListViewItem item = new ListViewItem(sv.MSSV);
            item.SubItems.Add(sv.Ten);
            item.SubItems.Add(sv.Phai);
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.SoDT);
            item.SubItems.Add(sv.Email);
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.Hinh);
            lvSinhVien.Items.Add(item);
        }
        private void NapDanhSachVaoListView()
        {
            lvSinhVien.Items.Clear();
            foreach (object o in qlsv.DanhSach)
                ThemVaoListView((SinhVien)o);
        }
        private void CapNhatListView(SinhVien sv)
        {
            foreach (ListViewItem item in lvSinhVien.Items)
            {
                if (item.Text == sv.MSSV)
                {
                    item.SubItems[1].Text = sv.Ten;
                    item.SubItems[2].Text = sv.Phai;
                    item.SubItems[3].Text = sv.NgaySinh.ToString("dd/MM/yyyy");
                    item.SubItems[4].Text = sv.Lop;
                    item.SubItems[5].Text = sv.SoDT;
                    item.SubItems[6].Text = sv.Email;
                    item.SubItems[7].Text = sv.DiaChi;
                    item.SubItems[8].Text = sv.Hinh;
                    break;
                }
            }
        }

        private void frmQuanLySinhVienCNTT_Load(object sender, EventArgs e)
        {
            qlsv.DocFile();
            NapDanhSachVaoListView();
            daThayDoi = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (mtxtMSSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập MSSV!");
                return;
            }

            SinhVien sv = LayThongTinTuForm();
            bool laCapNhat = qlsv.ThemHoacCapNhat(sv);

            if (laCapNhat)
                CapNhatListView(sv);
            else
                ThemVaoListView(sv);

            daThayDoi = true;
            MessageBox.Show(laCapNhat ? "Đã cập nhật!" : "Đã thêm mới!");
        }
        private void XoaTrang()
        {
            mtxtMSSV.Text = "";
            txtTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtHinh.Text = "";
            mtxtSoDT.Text = "";
            pbHinh.ImageLocation = "";
            if (cbLop.Items.Count > 0) cbLop.SelectedIndex = 0;
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            mtxtMSSV.Focus();
        }
   


        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            if (MessageBox.Show("Xóa sinh viên đã chọn?", "Xác nhận",
                MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            // lặp ngược để tránh lỗi index
            for (int i = lvSinhVien.SelectedItems.Count - 1; i >= 0; i--)
            {
                string mssv = lvSinhVien.SelectedItems[i].Text;
                qlsv.Xoa(mssv);
                lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[i]);
            }

            daThayDoi = true;
            XoaTrang();
        }

        private void mnuTaiLai_Click(object sender, EventArgs e)
        {
            if (daThayDoi)
            {
                if (MessageBox.Show(
                    "Có thay đổi chưa lưu. Tải lại sẽ mất các thay đổi này. Tiếp tục?",
                    "Cảnh báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
            }

            // Đọc lại từ file
            qlsv.DocFile();
            NapDanhSachVaoListView();
            XoaTrang();

            daThayDoi = false;   // reset cờ
            MessageBox.Show("Đã tải lại danh sách!");
        }

        private void frmQuanLySinhVienCNTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daThayDoi) return;

            DialogResult kq = MessageBox.Show(
                "Danh sách đã thay đổi. Bạn có muốn lưu không?",
                "Xác nhận",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (kq == DialogResult.OK)
                qlsv.GhiFile();   // lưu vào DSNV.txt
        }

        private void lvSinhVien_MouseDown(object sender, MouseEventArgs e)
        {
               if (e.Button == MouseButtons.Right)
    {
        ListViewItem item = lvSinhVien.GetItemAt(e.X, e.Y);
        if (item != null && !item.Selected)
        {
            lvSinhVien.SelectedItems.Clear();
            item.Selected = true;
        }
    }
        }
    }
}
