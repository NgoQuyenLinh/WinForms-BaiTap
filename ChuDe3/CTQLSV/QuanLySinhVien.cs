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
            if (!File.Exists(filename)) return;

            string t;
            string[] s;
            SinhVien sv;

            using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split(';');
                    if (s.Length >= 9)
                    {
                        sv = new SinhVien();
                        sv.MSSV = s[0].Trim();
                        sv.HoLot = s[1].Trim();
                        sv.Ten = s[2].Trim();
                        sv.NgaySinh = DateTime.ParseExact(s[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        sv.CMND = s[4].Trim();
                        sv.DiaChi = s[5].Trim();
                        sv.GioiTinh = (s[6].Trim() == "1");
                        sv.Lop = s[7].Trim();
                        sv.SoDT = s[8].Trim();

                        if (s.Length > 9 && !string.IsNullOrWhiteSpace(s[9]))
                        {
                            string[] monHoc = s[9].Split(',');
                            foreach (var item in monHoc)
                            {
                                sv.MonHoc.Add(item.Trim());
                            }
                        }

                        this.Them(sv);
                    }
                }
            }
        }

        public void LuuRaFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (SinhVien sv in this.ds)
                {
                    string monHoc = String.Join(",", sv.MonHoc);
                    string line = $"{sv.MSSV};{sv.HoLot};{sv.Ten};{sv.NgaySinh:dd/MM/yyyy};{sv.CMND};{sv.DiaChi};{(sv.GioiTinh ? "1" : "0")};{sv.Lop};{sv.SoDT}; {monHoc}";
                    sw.WriteLine(line);
                }
            }
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
                    return ds.Where(sv => sv.MSSV.ToLower().Contains(tuKhoa)).ToList();

                case KieuTim.TheoTen:
                    return ds.Where(sv => sv.Ten.ToLower().Contains(tuKhoa) || sv.HoLot.ToLower().Contains(tuKhoa)).ToList();

                case KieuTim.TheoLop:
                    return ds.Where(sv => sv.Lop.ToLower().Contains(tuKhoa)).ToList();

                default:
                    return ds;
            }
        }

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