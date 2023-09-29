using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDBStokEntities db = new MvcDBStokEntities(); //mvcdbstokentitiesden db isimli nesne üretir ve modeli tutar
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.tblKategori.ToList();  //degerleri listeler
            var degerler = db.tblKategori.ToList().ToPagedList(sayfa, 5); //1den başla 5 tane sayfala
            return View(degerler);
        }

        [HttpGet] //hiç bişey yapılmazsa bu işlemi yapar
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost] //butona tıklarsa bunları yapar
      public ActionResult YeniKategori(tblKategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tblKategori.Add(p1); 
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.tblKategori.Find(id);
            db.tblKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(tblKategori p1)
        {
            var ktg = db.tblKategori.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}