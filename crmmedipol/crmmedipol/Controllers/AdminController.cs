using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using crmmedipol.Models.Entity;

namespace crmmedipol.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        CRMMEDIPOLEntities db = new CRMMEDIPOLEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Giris(CRM_ADMIN p)
        {
            var degerler = db.CRM_ADMIN.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.KULLANICIADI, false);
                Session["Kullaniciadi"] = degerler.KULLANICIADI.ToString();
                return RedirectToAction("Hosgeldiniz", "Profil");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SifreSifirla()
        {
            return View();
        }
    }
}