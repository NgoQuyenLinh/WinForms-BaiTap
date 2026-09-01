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

namespace CTQLTTSV
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien qlsv;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            try
            {
                qlsv.DocTuFile("DanhSachSV.txt");
                LoadListView();
                if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc dữ liệu sinh viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
                cn += s + ",";
            if (cn.Length > 0)
                cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            lvitem.Tag = sv;
            this.lvSinhVien.Items.Add(lvitem);
        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
                ThemSV(sv);
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cboLop.Text;
            sv.Hinh = this.txtHinh.Text;
            if (rdNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                if (clbChuyenNganh.GetItemChecked(i))
                    cn.Add(clbChuyenNganh.Items[i].ToString());
            sv.ChuyenNganh = cn;
            return sv;
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            if (lvitem.Tag is SinhVien saved)
                return saved;

            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            List<string> cn = new List<string>();
            string[] s = lvitem.SubItems[6].Text.Split(',');
            foreach (string t in s)
                cn.Add(t);
            sv.ChuyenNganh = cn;
            sv.Hinh = lvitem.SubItems[7].Text;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            string imagePath = Path.Combine(Application.StartupPath, sv.Hinh);
            this.pbHinh.ImageLocation = File.Exists(imagePath) ? imagePath : sv.Hinh;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;

            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);

            foreach (string s in sv.ChuyenNganh)
            {
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                    if (s.CompareTo(this.clbChuyenNganh.Items[i]) == 0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            if (openFileDialogHinh.ShowDialog() == DialogResult.OK)
            {
                this.txtHinh.Text = Path.GetFileName(openFileDialogHinh.FileName);
                this.pbHinh.ImageLocation = openFileDialogHinh.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            if (string.IsNullOrWhiteSpace(sv.MaSo) || string.IsNullOrWhiteSpace(sv.HoTen))
            {
                MessageBox.Show("Vui lòng nhập mã số và họ tên sinh viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qlsv.Tim(sv.MaSo, SoSanhTheoMa) != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            qlsv.Them(sv);
            LoadListView();
            btnMacDinh.PerformClick();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            if (this.cboLop.Items.Count > 0)
                this.cboLop.SelectedIndex = 0;
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;

            
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return obj1.ToString().CompareTo(sv.MaSo);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool hasChecked = this.lvSinhVien.Items.Cast<ListViewItem>().Any(x => x.Checked);
            if (!hasChecked)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa bằng ô kiểm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa các sinh viên đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kqsua)
            {
                this.LoadListView();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}