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
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {
            
            db.tblSatislar.Add(p); //satislar tablosuna ekle p parametresini
            db.SaveChanges(); //değişiklikleri kaydet
            return View("Index"); //index sayfasına döndür
        }
        
    }
}