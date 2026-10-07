using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLySinhVien
{
    // Lớp đọc danh sách sinh viên từ tập tin văn bản (*.txt)
    public class DocFileSinhVien
    {
        public List<SinhVien> Doc(string filename)
        {
            List<SinhVien> ds = new List<SinhVien>();
            if (!File.Exists(filename)) return ds;

            using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
            {
                string t;
                while ((t = sr.ReadLine()) != null)
                {
                    SinhVien sv = SinhVien.FromLine(t);
                    if (sv != null) ds.Add(sv);   // bỏ qua dòng lỗi
                }
            }
            return ds;
        }
    }

    // Lớp ghi danh sách sinh viên ra tập tin văn bản (*.txt)
    public class GhiFileSinhVien
    {
        public void Ghi(string filename, IEnumerable<SinhVien> ds)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, new UTF8Encoding(true)))
            {
                foreach (SinhVien sv in ds)
                    sw.WriteLine(sv.ToLine());
            }
        }
    }
}
