using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQLTTSV
{
    public partial class frmTuyChon : Form
    {
        private QuanLySinhVien qlsv;
        public List<SinhVien> KetQuaTimKiem { get; private set; }

        public frmTuyChon(QuanLySinhVien ds)
        {
            InitializeComponent();

            this.qlsv = ds;
        }


        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;

            return obj1.ToString().CompareTo(sv.MaSo);
        }

        private int SoSanhTheoHoTen(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;

            return obj1.ToString().CompareTo(sv.HoTen);
        }

        private int SoSanhTheoNgaySinh(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;

            DateTime ngayTim;

            if (!DateTime.TryParse(
                    obj1.ToString(),
                    out ngayTim))
            {
                return -1;
            }

            return ngayTim.CompareTo(sv.NgaySinh);
        }

        enum TuyChon
        {
            MaSV,
            HoTen,
            NgaySinh
        }
        private void HoanVi(
            List<SinhVien> ds,
            int a,
            int b)
        {
            SinhVien temp = ds[a];

            ds[a] = ds[b];

            ds[b] = temp;
        }
        private void SapXep(List<SinhVien> ds,TuyChon tieuChi)
        {
            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i + 1; j < ds.Count; j++)
                {
                    bool doiCho = false;

                    switch (tieuChi)
                    {
                        case TuyChon.MaSV:

                            doiCho =
                                ds[i].MaSo.CompareTo(
                                    ds[j].MaSo) > 0;

                            break;

                        case TuyChon.HoTen:

                            doiCho =
                                ds[i].HoTen.CompareTo(
                                    ds[j].HoTen) > 0;

                            break;

                        case TuyChon.NgaySinh:

                            doiCho =
                                ds[i].NgaySinh >
                                ds[j].NgaySinh;

                            break;
                    }

                    if (doiCho)
                    {
                        HoanVi(ds, i, j);
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(
                    "Hãy nhập thông tin tìm!",
                    "Lỗi nhập thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            List<SinhVien> ketQua = new List<SinhVien>();

            if (rdMaSV.Checked)
            {
                SinhVien sv = qlsv.Tim(txtTim.Text, SoSanhTheoMa);

                if (sv != null)
                    ketQua.Add(sv);
            }
            else if (rdHoTen.Checked)
            {
                ketQua = qlsv.TimCacSV(txtTim.Text,SoSanhTheoHoTen);
            }
            else if (rdNgaySinh.Checked)
            {
                ketQua = qlsv.TimCacSV(txtTim.Text, SoSanhTheoNgaySinh);
            }

            if (ketQua.Count > 0)
            {
                MessageBox.Show(
                    "Tìm thấy sinh viên!\nSố sinh viên tìm thấy: " + ketQua.Count,
                    "Kết quả tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Đóng form và trả danh sách kết quả
                this.KetQuaTimKiem = ketQua;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Không tìm thấy sinh viên!\nSố sinh viên tìm thấy: 0",
                    "Kết quả tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnSapXep_Click(
            object sender,
            EventArgs e)
        {
            TuyChon tieuChi;

            if (rdMaSV.Checked)
            {
                tieuChi = TuyChon.MaSV;
            }
            else if (rdHoTen.Checked)
            {
                tieuChi = TuyChon.HoTen;
            }
            else
            {
                tieuChi = TuyChon.NgaySinh;
            }

            if (qlsv == null)
            {
                MessageBox.Show(
                    "Chưa có danh sách sinh viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            SapXep(
                qlsv.dsSinhVien,
                tieuChi);

            MessageBox.Show(
                "Sắp xếp thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            rdMaSV.Checked = true;
        }
    }
}