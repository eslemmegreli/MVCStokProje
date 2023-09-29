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
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tblUrunler.ToList();
            var degerler = db.tblUrunler.ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD, //kategori adı şeklinde kullanıcıya göster
                                                 Value = i.KATEGORIID.ToString() // kategori ıd şeklinde al
                                             }).ToList();
            ViewBag.dgr = degerler; //yukarda sorgudan gelen degerleri dgr'nin içerisine attım ve bunları taşıyacağım
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tblUrunler u1)
        {
            var ktg = db.tblKategori.Where(m => m.KATEGORIID == u1.tblKategori.KATEGORIID).FirstOrDefault();
            u1.tblKategori = ktg;

            db.tblUrunler.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.tblUrunler.Find(id);
            db.tblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tblUrunler.Find(id);

            List<SelectListItem> degerler = (from i in db.tblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD, //kategori adı şeklinde kullanıcıya göster
                                                 Value = i.KATEGORIID.ToString() // kategori ıd şeklinde al
                                             }).ToList();
            ViewBag.dgr = degerler; //yukarda sorgudan gelen degerleri dgr'nin içerisine attım ve bunları taşıyacağım
            return View("UrunGetir", urun);

        }
        public ActionResult Guncelle(tblUrunler p)
        {
            var urun = db.tblUrunler.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.tblKategori.Where(m => m.KATEGORIID == p.tblKategori.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI= ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}