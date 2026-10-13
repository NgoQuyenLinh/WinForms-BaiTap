using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text.Json;

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

        public void Them(SinhVien sv)
        {
            this.ds.Add(sv);
        }


        // --- NHÓM HÀM NGHIỆP VỤ ---
        public SinhVien TimKiemTheoMSSV(string mssv)
        {
            return ds.FirstOrDefault(x => x.MSSV == mssv);
        }

        // Tìm kiếm đa điều kiện
        public List<SinhVien> TimKiem(string tuKhoaMSSV, string tuKhoaTen, string tuKhoaLop)
        {
            tuKhoaMSSV = tuKhoaMSSV?.Trim().ToLower() ?? "";
            tuKhoaTen = tuKhoaTen?.Trim().ToLower() ?? "";
            tuKhoaLop = tuKhoaLop?.Trim().ToLower() ?? "";

            return ds.Where(sv =>
                (string.IsNullOrEmpty(tuKhoaMSSV) || sv.MSSV.ToLower().Contains(tuKhoaMSSV)) &&
                (string.IsNullOrEmpty(tuKhoaTen) || sv.HoTen.ToLower().Contains(tuKhoaTen)) &&
                (string.IsNullOrEmpty(tuKhoaLop) || sv.Lop.ToLower().Contains(tuKhoaLop))
            ).ToList();
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
        // --- NHÓM HÀM FILE JSON ---
        public void LuuRaJSON(string filename)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(ds, options);
            File.WriteAllText(filename, jsonString);
        }

        public void DocTuJSON(string filename)
        {
            if (!File.Exists(filename)) return;
            string jsonString = File.ReadAllText(filename);
            ds = JsonSerializer.Deserialize<List<SinhVien>>(jsonString) ?? new List<SinhVien>();
        }

        // --- NHÓM HÀM FILE XML ---
        public void LuuRaXML(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<SinhVien>));
            using (StreamWriter sw = new StreamWriter(filename))
            {
                xs.Serialize(sw, ds);
            }
        }

        public void DocTuXML(string filename)
        {
            if (!File.Exists(filename)) return;
            XmlSerializer xs = new XmlSerializer(typeof(List<SinhVien>));
            using (StreamReader sr = new StreamReader(filename))
            {
                ds = (List<SinhVien>)xs.Deserialize(sr) ?? new List<SinhVien>();
            }
        }


        // --- NHÓM HÀM FILE TXT ---
        public void DocTuFile(string filename)
        {
            ds.Clear();
            if (!File.Exists(filename)) return;
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                SinhVien sv = SinhVien.FromLine(line);
                if (sv != null) this.Them(sv);
            }
        }

        public void LuuRaFile(string filename)
        {
            var lines = ds.Select(sv => sv.ToLine());
            File.WriteAllLines(filename, lines);
        }
    }
}