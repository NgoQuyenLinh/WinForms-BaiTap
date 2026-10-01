using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTQLSVCNTT
{
    internal class SinhVien
    {
        public string MSSV {  get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Phai { get; set; }
        public string Lop {  get; set; }
        public string SoDT { get; set; }
        public string Hinh { get; set; }
        public SinhVien()
        {
            
        }
        public SinhVien(string mssv, string ten, string email,string diaChi, DateTime ngaySinh, string phai, string lop, string soDT, string hinh)
        {
            MSSV = mssv;
            Ten = ten;
            Email = email;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            Phai = phai;
            Lop = lop;
            SoDT = soDT;
            Hinh = hinh;
        }

    }
}
