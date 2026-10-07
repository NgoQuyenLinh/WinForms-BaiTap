using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace QuanLySinhVien
{
    public class QuanLySinhVien
    {
        private List<SinhVien> ds;

        public QuanLySinhVien()
        {
            ds = new List<SinhVien>();
        }

        public List<SinhVien> DanhSach
        {
            get { return ds; }
        }

        public SinhVien this[int index]
        {
            get { return ds[index]; }
            set { ds[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            this.ds.Add(sv);
        }

        public void DocTuFile(string filename)
        {
            ds.Clear();
            ds.AddRange(new DocFileSinhVien().Doc(filename));
        }

        public void LuuRaFile(string filename)
        {
            new GhiFileSinhVien().Ghi(filename, ds);
        }

        public SinhVien TimKiemTheoMSSV(string mssv)
        {
            return ds.FirstOrDefault(x => x.MSSV == mssv);
        }

        public List<SinhVien> TimKiem(string tuKhoa, KieuTim kieu)
        {
            tuKhoa = tuKhoa.Trim().ToLower();
            if (string.IsNullOrEmpty(tuKhoa)) return ds;

            switch (kieu)
            {
                case KieuTim.TheoMSSV:
                    // LINQ: Lọc sinh viên có MSSV chứa từ khóa
                    return ds.Where(sv => sv.MSSV.ToLower().Contains(tuKhoa)).ToList();

                case KieuTim.TheoTen:
                    // LINQ: Lọc sinh viên có Tên HOẶC Họ lót chứa từ khóa
                    return ds.Where(sv => sv.Ten.ToLower().Contains(tuKhoa) || sv.HoLot.ToLower().Contains(tuKhoa)).ToList();

                case KieuTim.TheoLop:
                    // LINQ: Lọc sinh viên thuộc Lớp chứa từ khóa
                    return ds.Where(sv => sv.Lop.ToLower().Contains(tuKhoa)).ToList();

                default:
                    return ds;
            }
        }

        // Xóa nhiều sinh viên
        public void XoaNhieu(List<string> dsMSSVCanXoa)
        {
            ds.RemoveAll(sv => dsMSSVCanXoa.Contains(sv.MSSV));
        }

        public bool CapNhat(SinhVien svMoi)
        {
            SinhVien svCu = ds.FirstOrDefault(x => x.MSSV == svMoi.MSSV);
            if (svCu != null)
            {
                svCu.HoLot = svMoi.HoLot;
                svCu.Ten = svMoi.Ten;
                svCu.NgaySinh = svMoi.NgaySinh;
                svCu.CMND = svMoi.CMND;
                svCu.DiaChi = svMoi.DiaChi;
                svCu.GioiTinh = svMoi.GioiTinh;
                svCu.Lop = svMoi.Lop;
                svCu.SoDT = svMoi.SoDT;
                svCu.MonHoc = svMoi.MonHoc;
                return true;
            }
            return false;
        }
    }
}