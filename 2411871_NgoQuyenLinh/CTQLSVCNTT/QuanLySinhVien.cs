using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTQLSVCNTT
{
    internal class QuanLySinhVien
    {
        ArrayList ds;
        public QuanLySinhVien()
        {
            ds = new ArrayList();
        }

        public ArrayList DanhSach
        {
            get { return ds; }
        }

        public SinhVien TimTheoMSSV(string mssv)
        {
            foreach (object o in ds)
            {
                SinhVien sv = (SinhVien)o;
                if (sv.MSSV == mssv) return sv;
            }
            return null;
        }

        // Đọc file VÀ gán vào ds luôn
        public void DocFile()
        {
            ds.Clear();
            if (!File.Exists("DSNV.txt")) return;

            using (StreamReader sr = new StreamReader("DSNV.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "") continue;
                    string[] p = line.Split('|');
                    if (p.Length < 9) continue;

                    SinhVien sv = new SinhVien();
                    sv.MSSV = p[0];
                    sv.Ten = p[1];
                    sv.Email = p[2];
                    sv.DiaChi = p[3];
                    sv.NgaySinh = DateTime.ParseExact(p[4], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    sv.Phai = p[5];
                    sv.Lop = p[6];
                    sv.SoDT = p[7];
                    sv.Hinh = p[8];

                    ds.Add(sv);
                }
            }
        }

        // Ghi file từ chính ds bên trong
        public void GhiFile()
        {
            List<string> lines = new List<string>();
            foreach (object o in ds)
            {
                SinhVien sv = (SinhVien)o;
                lines.Add(string.Join("|",
                    sv.MSSV, sv.Ten, sv.Email, sv.DiaChi,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.Phai, sv.Lop, sv.SoDT, sv.Hinh));
            }
            File.WriteAllLines("DSNV.txt", lines);
        }

        // Thêm hoặc cập nhật — trả về true nếu là CẬP NHẬT
        public bool ThemHoacCapNhat(SinhVien sv)
        {
            SinhVien cu = TimTheoMSSV(sv.MSSV);
            if (cu != null)
            {
                // cập nhật object cũ trong ds
                cu.Ten = sv.Ten;
                cu.Email = sv.Email;
                cu.DiaChi = sv.DiaChi;
                cu.NgaySinh = sv.NgaySinh;
                cu.Phai = sv.Phai;
                cu.Lop = sv.Lop;
                cu.SoDT = sv.SoDT;
                cu.Hinh = sv.Hinh;
                return true;   // đã cập nhật
            }
            else
            {
                ds.Add(sv);
                return false;  // đã thêm mới
            }
        }

        public bool Xoa(string mssv)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                SinhVien sv = (SinhVien)ds[i];
                if (sv.MSSV == mssv)
                {
                    ds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

    }
}
