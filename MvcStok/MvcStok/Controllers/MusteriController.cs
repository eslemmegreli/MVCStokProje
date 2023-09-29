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
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.tblMusteri.ToList();
            var degerler = db.tblMusteri.ToList().ToPagedList(sayfa, 9);
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteri m1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tblMusteri.Add(m1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.tblMusteri.Find(id);
            db.tblMusteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblMusteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(tblMusteri p1)
        {
            var musteri = db.tblMusteri.Find(p1.MUSTERIID); //p1e göre müşteri bul
            musteri.MUSTERIAD = p1.MUSTERIAD; //p1den gelen musteri adını ata
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}