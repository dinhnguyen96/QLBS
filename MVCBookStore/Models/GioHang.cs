using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBookStore.Models
{
    public class GioHang
    {
        dbQLBanSachDataContext db = new dbQLBanSachDataContext();

        public int iMasach { set; get; }
        public string sTensach { set; get; }
        public string sHinhminhhoa { set; get; }
        public double dDongia { set; get; }
        public int isoluong { set; get; }
        public double dThanhtien
        {
            get { return isoluong * dDongia; }
        }
        public GioHang(int Masach)
        {
            iMasach = Masach;
            SACH sach = db.SACHes.Single(n => n.Masach == iMasach);
            sTensach = sach.Tensach;
            sHinhminhhoa = sach.Hinhminhhoa;
            dDongia = double.Parse(sach.Dongia.ToString());
            isoluong = 1;
        }
    }
}