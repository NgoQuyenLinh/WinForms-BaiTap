using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
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

            // Chuẩn hóa tên môn trong CheckedListBox về dạng Unicode NFC
            // (Designer có thể lưu dạng tổ hợp NFD nên không khớp với dữ liệu từ file)
            for (int i = 0; i < chklbMonHoc.Items.Count; i++)
                chklbMonHoc.Items[i] = ChuanHoaMon(chklbMonHoc.Items[i].ToString());

            // Ưu tiên load từ txt (hoặc đổi sang DocTuXML/DocTuJSON tùy ý)
            qlsv.DocTuFile("students.txt");
            HienThiListView(qlsv.DanhSach);
        }

        // Chuẩn hóa chuỗi: bỏ khoảng trắng thừa + đưa về Unicode NFC để so sánh tiếng Việt chính xác
        private static string ChuanHoaMon(string s)
        {
            if (s == null) return "";
            return s.Normalize(NormalizationForm.FormC).Trim();
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

            SinhVien sv = lvSinhVien.SelectedItems[0].Tag as SinhVien;
            if (sv == null) return;

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
            {
                chklbMonHoc.SetItemChecked(i, false);
            }

            // Nếu sinh viên không có danh sách môn họcthì dừng lại
            if (sv.MonHoc == null || sv.MonHoc.Count == 0) return;

            // Duyệt qua từng môn học của sinh viên để đối chiếu và tick chọn
            foreach (string s in sv.MonHoc)
            {
                for (int i = 0; i < chklbMonHoc.Items.Count; i++)
                {
                    // So sánh chuỗi 
                    string monTrongDesigner = ChuanHoaMon(chklbMonHoc.Items[i].ToString());
                    string monCuaSinhVien = ChuanHoaMon(s);

                    if (string.Equals(monCuaSinhVien, monTrongDesigner, StringComparison.OrdinalIgnoreCase))
                    {
                        chklbMonHoc.SetItemChecked(i, true);
                        break; // Tìm thấy thì dừng vòng lặp trong, chuyển sang môn tiếp theo của sinh viên
                    }
                }
            }
        }

        private void LuuVaHienThi()
        {
            qlsv.LuuRaFile("students.txt");
            qlsv.LuuRaXML("students.xml");
            qlsv.LuuRaJSON("students.json");

            HienThiListView(qlsv.DanhSach);
        }

        private bool KiemTraRangBuoc()
        {
            if (txtHoTenLot.Text.Trim() == "" || txtTen.Text.Trim() == "" ||
                txtDiaChiLienLac.Text.Trim() == "" || cboLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mtxtCMND.MaskCompleted)
            {
                MessageBox.Show("Số CMND phải đủ 9 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mtxtSoDT.MaskCompleted)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // --- LOGIC KIỂM TRA ĐỊNH DẠNG MSSV AABBCCC ---
            string lop = cboLop.Text.Trim();
            // Tách riêng các ký tự số từ tên lớp (VD: CTK42 -> 42)
            string soKhoaStr = new string(lop.Where(char.IsDigit).ToArray());

            if (int.TryParse(soKhoaStr, out int khoa))
            {
                int namNhapHoc = 1980 + khoa;
                string aa = (namNhapHoc % 100).ToString("00"); // Lấy 2 số cuối năm
                string maBatDauBatBuoc = $"{aa}10"; // Ghép AA với BB=10

                if (mtxtMSSV.Text.Length != 7 || !mtxtMSSV.Text.StartsWith(maBatDauBatBuoc))
                {
                    MessageBox.Show($"MSSV không hợp lệ!\nSinh viên khóa {khoa} (Năm {namNhapHoc}) phải có MSSV gồm 7 số và bắt đầu bằng {maBatDauBatBuoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên Lớp có chứa Khóa học (VD: CTK42) để xác thực MSSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MonHoc = chklbMonHoc.CheckedItems.Cast<object>().Select(o => ChuanHoaMon(o.ToString())).ToList()
            };
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraRangBuoc()) return;

            if (qlsv.TimKiemTheoMSSV(mtxtMSSV.Text) != null)
            {
                MessageBox.Show("Mã số sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Không tìm thấy MSSV để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string mon = ChuanHoaMon(Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học cần thêm:", "Thêm môn học", ""));
            if (mon == "") return;

            bool daCo = chklbMonHoc.Items.Cast<object>()
                .Any(o => string.Equals(ChuanHoaMon(o.ToString()), mon, StringComparison.OrdinalIgnoreCase));
            if (!daCo)
                chklbMonHoc.Items.Add(mon, true);
        }

        private void chklbMonHoc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = chklbMonHoc.IndexFromPoint(e.Location);
                chklbMonHoc.SelectedIndex = index;
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
                LuuVaHienThi();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}