using System;
using System.Collections.Generic;

namespace CTQLGV
{
    public enum KieuTim
    {
        TheoMa,
        TheoHoTen,
        TheoSDT
    }

    public delegate int SoSanh(object a, object b);

    public class QuanLyGiangVien
    {
        private List<GiangVien> dsGiangVien;

        public GiangVien this[int index]
        {
            get { return dsGiangVien[index]; }
            set { dsGiangVien[index] = value; }
        }

        public QuanLyGiangVien()
        {
            dsGiangVien = new List<GiangVien>();
        }

        public void SapXep(SoSanh ss)
        {
            for (int i = 0; i < dsGiangVien.Count - 1; i++)
            {
                for (int j = i + 1; j < dsGiangVien.Count; j++)
                {
                    if (ss(dsGiangVien[i], dsGiangVien[j]) > 0)
                    {
                        GiangVien temp = dsGiangVien[i];
                        dsGiangVien[i] = dsGiangVien[j];
                        dsGiangVien[j] = temp;
                    }
                }
            }
        }

        public bool Them(GiangVien gv)
        {
            if (Tim(gv.MaSo, KieuTim.TheoMa) != null)
                return false;

            dsGiangVien.Add(gv);
            return true;
        }

        public GiangVien Tim(object temp, KieuTim ss)
        {
            foreach (GiangVien gv in dsGiangVien)
            {
                switch (ss)
                {
                    case KieuTim.TheoMa:
                        if (gv.MaSo == temp.ToString())
                            return gv;
                        break;

                    case KieuTim.TheoHoTen:
                        if (gv.HoTen == temp.ToString())
                            return gv;
                        break;

                    case KieuTim.TheoSDT:
                        if (gv.SoDT == temp.ToString())
                            return gv;
                        break;
                }
            }

            return null;
        }

        public GiangVien Xoa(object temp, KieuTim ss)
        {
            GiangVien gv = Tim(temp, ss);

            if (gv != null)
                dsGiangVien.Remove(gv);

            return gv;
        }
    }
}
    