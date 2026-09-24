using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuDe3
{
    internal class StudentInfo
    {
        public string MSSV {  get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public double Diem {  get; set; }
        public bool TonGiao { get; set; }
        public StudentInfo(string mssv, string hoTen, int tuoi, double diem, bool tonGiao)
        {
            MSSV = mssv;
            HoTen = hoTen;
            Tuoi = tuoi;
            Diem = diem;
            TonGiao = tonGiao;
        }

    }
}
