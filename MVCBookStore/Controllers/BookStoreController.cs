using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBookStore.Models;
using PagedList;
using PagedList.Mvc;
namespace MVCBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        dbQLBanSachDataContext db = new dbQLBanSachDataContext();
        // GET: BookStore
        private List<SACH> LaySachMoi(int count)
        {
            return db.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);

            var laysach = LaySachMoi(24);
            return View(laysach.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ChuDe()
        {
            var chude = from cd in db.CHUDEs
                        select cd;
            return PartialView(chude);
        }
        public ActionResult NhaXuatBan()
        {
            var nhaxuatban = from nxb in db.NHAXUATBANs
                             select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult QuangCao()
        {
            var quangcao = from qc in db.QUANGCAOs
                           select qc;
            return PartialView(quangcao);
        }
        public ActionResult SPTTheoChuDe(int id)
        {
            var sach = from s in db.SACHes
                       where s.MaCD == id
                       select s;
            return View(sach);
        }
        public ActionResult SPTTheoNXB(int id)
        {
            var sach = from s in db.SACHes
                       where s.MaNXB == id
                       select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in db.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }
    }
}