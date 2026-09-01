using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQLTTSV
{
    public delegate int SoSanh(object sv1, object sv2);

   public class QuanLySinhVien
    {
        public List<SinhVien> dsSinhVien;

        public QuanLySinhVien()
        {
            dsSinhVien = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return this.dsSinhVien[index]; }
            set { dsSinhVien[index] = value; }
        }
        public void Them(SinhVien sv)
        {
            this.dsSinhVien.Add(sv);
        }

        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in dsSinhVien)
            {
                if (ss(obj, sv) == 0)
                    return sv;
            }
            return svresult;
        }

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.dsSinhVien.Count - 1;
            for (i = 0; i <= count; i++)
            if(ss(obj, this.dsSinhVien[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public void Xoa(object obj, SoSanh ss)
        {
            int i = dsSinhVien.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this.dsSinhVien[i]) == 0)
                {
                    this.dsSinhVien.RemoveAt(i);
                }
        }
        public void DocTuFile(string fileName)
        {
            string s;
            string[] t;
            SinhVien sv;
            string path = Path.IsPathRooted(fileName)
                ? fileName
                : Path.Combine(Application.StartupPath, fileName);

            if (!File.Exists(path))
                throw new FileNotFoundException("Không tìm thấy file dữ liệu sinh viên.", path);

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    t = s.Split('\t');
                    sv = new SinhVien();
                    sv.MaSo = t[0];
                    sv.HoTen = t[1];
                    sv.NgaySinh = DateTime.Parse(t[2]);
                    sv.DiaChi = t[3];
                    sv.Lop = t[4];
                    sv.Hinh = t[5];
                    sv.GioiTinh = false;
                    if (t[6] == "1")
                        sv.GioiTinh = true;
                    string[] cn = t[7].Split(',');
                    foreach (string c in cn)
                        sv.ChuyenNganh.Add(c);
                    this.Them(sv);
                }
            }
        }

     
    }
}
