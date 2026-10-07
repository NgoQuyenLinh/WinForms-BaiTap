using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
        private const string filePath = "dssv.txt";
        private QuanLySinhVien qlsv = new QuanLySinhVien();

        public frmSinhVien()
        {
            InitializeComponent();
        }


        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            lvSinhVien.View = View.Details;
            lvSinhVien.FullRowSelect = true;
            lvSinhVien.CheckBoxes = true;
            qlsv.DocTuFile(filePath);
            HienThiListView(qlsv.DanhSach);
        }

        private void HienThiListView(List<SinhVien> ds)
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in ds)
            {
                ListViewItem item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoLot);
                item.SubItems.Add(sv.Ten);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.CMND);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.DiaChi);
                item.Tag = sv; 
                lvSinhVien.Items.Add(item);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            SinhVien sv = (SinhVien)lvSinhVien.SelectedItems[0].Tag;

            mtxtMSSV.Text = sv.MSSV;
            txtHoTenLot.Text = sv.HoLot;
            txtTen.Text = sv.Ten;
            dtpNgaySinh.Value = sv.NgaySinh;
            mtxtCMND.Text = sv.CMND;
            txtDiaChiLienLac.Text = sv.DiaChi;
            rdNam.Checked = sv.GioiTinh;
            rdNu.Checked = !sv.GioiTinh;
            cboLop.Text = sv.Lop;
            mtxtSoDT.Text = sv.SoDT;

            for (int i = 0; i < chklbMonHoc.Items.Count; i++)
                chklbMonHoc.SetItemChecked(i, sv.MonHoc.Contains(chklbMonHoc.Items[i].ToString()));
        }


        private void LuuVaHienThi()
        {
            qlsv.LuuRaFile(filePath);
            HienThiListView(qlsv.DanhSach);
        }

        private bool KiemTraRangBuoc()
        {
            if (txtHoTenLot.Text.Trim() == "" || txtTen.Text.Trim() == "" ||
                txtDiaChiLienLac.Text.Trim() == "" || cboLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mtxtMSSV.MaskCompleted)
            {
                MessageBox.Show("MSSV phải đủ 7 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mtxtCMND.MaskCompleted)
            {
                MessageBox.Show("Số CMND phải đủ 9 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!mtxtSoDT.MaskCompleted)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private SinhVien LayThongTinTuForm()
        {
            return new SinhVien
            {
                MSSV = mtxtMSSV.Text,
                HoLot = txtHoTenLot.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                CMND = mtxtCMND.Text,
                DiaChi = txtDiaChiLienLac.Text.Trim(),
                GioiTinh = rdNam.Checked,
                Lop = cboLop.Text.Trim(),
                SoDT = mtxtSoDT.Text,
                MonHoc = chklbMonHoc.CheckedItems.Cast<string>().ToList()
            };
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraRangBuoc()) return;

            if (qlsv.TimKiemTheoMSSV(mtxtMSSV.Text) != null)
            {
                MessageBox.Show("Mã số sinh viên đã tồn tại!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            qlsv.Them(LayThongTinTuForm());
            LuuVaHienThi();
            MessageBox.Show("Thêm mới sinh viên thành công!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!KiemTraRangBuoc()) return;

            if (!qlsv.CapNhat(LayThongTinTuForm()))
            {
                MessageBox.Show("Không tìm thấy MSSV để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LuuVaHienThi();
            MessageBox.Show("Cập nhật thông tin thành công!");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem(qlsv);
            if (frm.ShowDialog() == DialogResult.OK)
                HienThiListView(frm.KetQuaTimKiem);
        }


        private void menuThemMon_Click(object sender, EventArgs e)
        {
            string mon = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học cần thêm:", "Thêm môn học", "").Trim();
            if (mon != "" && !chklbMonHoc.Items.Contains(mon))
                chklbMonHoc.Items.Add(mon, true);
        }

        private void chklbMonHoc_MouseDown(object sender, MouseEventArgs e)
        {
            // Nhấp chuột phải: chọn môn tại vị trí con trỏ để "Xóa môn" xóa đúng môn đó
            if (e.Button == MouseButtons.Right)
            {
                int index = chklbMonHoc.IndexFromPoint(e.Location);
                chklbMonHoc.SelectedIndex = index;   // -1 nếu click vào vùng trống
            }
        }

        private void menuXoaMon_Click(object sender, EventArgs e)
        {
            if (chklbMonHoc.SelectedIndex != -1)
                chklbMonHoc.Items.RemoveAt(chklbMonHoc.SelectedIndex);
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No) e.Cancel = true;
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> dsMSSVCanXoa = new List<string>();
            foreach (ListViewItem item in lvSinhVien.CheckedItems)
            {
                dsMSSVCanXoa.Add(item.Text);
            }
            if (dsMSSVCanXoa.Count == 0 && lvSinhVien.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                {
                    dsMSSVCanXoa.Add(item.Text);
                }
            }

            if (dsMSSVCanXoa.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn Checkbox hoặc bôi đen sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa {dsMSSVCanXoa.Count} sinh viên đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                qlsv.XoaNhieu(dsMSSVCanXoa);
                qlsv.LuuRaFile(filePath);
                HienThiListView(qlsv.DanhSach);

                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}