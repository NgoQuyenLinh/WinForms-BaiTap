using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuanLySinhVien
{
    public enum KieuTim
    {
        TheoTen,
        TheoMSSV,
        TheoLop
    }

    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }   // true = Nam, false = Nữ
        public string Lop { get; set; }
        public string SoDT { get; set; }
        public List<string> MonHoc { get; set; } = new List<string>();

        public string HoTen
        {
            get { return (HoLot + " " + Ten).Trim(); }
        }

        public override string ToString()
        {
            return $"{MSSV} - {HoTen}";
        }

        // Chuyển sinh viên thành 1 dòng văn bản để ghi file
        public string ToLine()
        {
            return $"{MSSV};{HoLot};{Ten};{NgaySinh:dd/MM/yyyy};{CMND};{DiaChi};{(GioiTinh ? "1" : "0")};{Lop};{SoDT};{string.Join(",", MonHoc)}";
        }

        // Tạo sinh viên từ 1 dòng văn bản; trả về null nếu dòng không hợp lệ
        public static SinhVien FromLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            string[] s = line.Split(';');
            if (s.Length < 9) return null;

            DateTime ngaySinh;
            if (!DateTime.TryParseExact(s[3].Trim(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                return null;

            SinhVien sv = new SinhVien();
            sv.MSSV = s[0].Trim();
            sv.HoLot = s[1].Trim();
            sv.Ten = s[2].Trim();
            sv.NgaySinh = ngaySinh;
            sv.CMND = s[4].Trim();
            sv.DiaChi = s[5].Trim();
            sv.GioiTinh = (s[6].Trim() == "1");
            sv.Lop = s[7].Trim();
            sv.SoDT = s[8].Trim();

            if (s.Length > 9 && !string.IsNullOrWhiteSpace(s[9]))
            {
                sv.MonHoc = s[9].Split(',')
                                .Select(m => m.Trim())
                                .Where(m => m != "")
                                .ToList();
            }
            return sv;
        }
    }
}
