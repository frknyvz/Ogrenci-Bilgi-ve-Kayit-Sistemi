using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using crmmedipol.Models.Entity;

namespace crmmedipol.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        CRMMEDIPOLEntities db = new CRMMEDIPOLEntities();
        public ActionResult Index()
        {
            //var degerler = from k in db.CRM_KISI select k;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(x => x.AD_SOYAD.Contains(p));
            //}
            //return View(degerler.ToList());
            var degerler = db.CRM_OGRENCI.ToList();
            return View(degerler);
        }
        public ActionResult OgrenciAra(string p)
        {
            var degerler = from k in db.CRM_OGRENCI select k;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.AD_SOYAD.Contains(p));
            }
            var admink = (string)Session["Kullaniciadi"];
            var d2 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.ADSOYAD).FirstOrDefault();
            ViewBag.dgr2 = d2;
            var d3 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.FOTO).FirstOrDefault();
            ViewBag.dgr3 = d3;
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            var admink = (string)Session["Kullaniciadi"];
            var d2 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.ADSOYAD).FirstOrDefault();
            ViewBag.dgr2 = d2;
            var d3 = db.CRM_ADMIN.Where(x => x.KULLANICIADI == admink).Select(z => z.FOTO).FirstOrDefault();
            ViewBag.dgr3 = d3;
            List<SelectListItem> deger1 = (from i in db.CRM_SEHIR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.SEHIRADI,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger4 = (from i in db.CRM_BOLUM.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BOLUMADI,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(CRM_OGRENCI k)
        {
            if (!ModelState.IsValid)
            {
                return View("OgrenciEkle");
            }
            db.CRM_OGRENCI.Add(k);
            db.SaveChanges();
            return RedirectToAction("OgrenciEkle","Ogrenci");
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris", "Admin");
        }
    }
}