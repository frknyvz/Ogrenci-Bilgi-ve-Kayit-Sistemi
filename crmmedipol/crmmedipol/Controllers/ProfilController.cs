using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using crmmedipol.Models.Entity;

namespace crmmedipol.Controllers
{  
    public class ProfilController : Controller
    {
        // GET: Profil
        CRMMEDIPOLEntities db = new CRMMEDIPOLEntities();

        public ActionResult Index()
        {
            var admink = (string)Session["Kullaniciadi"];
            var degerler = db.CRM_ADMIN.FirstOrDefault(x => x.KULLANICIADI == admink);

            var d1 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.KULLANICIADI).FirstOrDefault();
            ViewBag.dgr1 = d1;

            var d2 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.ADSOYAD).FirstOrDefault();
            ViewBag.dgr2 = d2;

            var d3 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.FOTO).FirstOrDefault();
            ViewBag.dgr3 = d3;

            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(CRM_ADMIN p)
        {
            var kullanici = (string)Session["Kullaniciadi"];
            var admin = db.CRM_ADMIN.FirstOrDefault(x => x.KULLANICIADI == kullanici);
            //admin.KULLANICIADI = p.KULLANICIADI;
            admin.SIFRE = p.SIFRE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Hosgeldiniz()
        {
            var admink = (string)Session["Kullaniciadi"];
            var d2 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.ADSOYAD).FirstOrDefault();
            ViewBag.dgr2 = d2;
            var d3 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.FOTO).FirstOrDefault();
            ViewBag.dgr3 = d3;
            return View();
        }
        [HttpGet]
        public ActionResult Iletisim()
        {
            var admink = (string)Session["Kullaniciadi"];
            var d2 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.ADSOYAD).FirstOrDefault();
            ViewBag.dgr2 = d2;
            var d3 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.FOTO).FirstOrDefault();
            ViewBag.dgr3 = d3;
            return View();
        }
        [HttpPost]
        public ActionResult Iletisim(CRM_ILETISIM k)
        {
            if (!ModelState.IsValid)
            {
                return View("Iletisim");
            }
            db.CRM_ILETISIM.Add(k);
            db.SaveChanges();
            return RedirectToAction("Iletisim", "Profil");
        }
    }
}