using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;
using System.Web.Security;

namespace RandevuSistemi1.Controllers
{
    public class LoginController : Controller
    {
        RandevuSistemi rs = new RandevuSistemi();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        [AllowAnonymous]
        public ActionResult Index(Kullaniciler k)
        {
            Kullaniciler kul = rs.Kullanicilers.FirstOrDefault(x => x.Eposta == k.Eposta && x.Parola == k.Parola);
            if (kul != null)
            {
                FormsAuthentication.SetAuthCookie(kul.Eposta, false);
                string userRole = Roles.GetRolesForUser(kul.Eposta).FirstOrDefault();
                if (userRole == "A" || userRole == "O")
                {
                    return RedirectToAction("index", "Randevu");
                }
                else
                {
                    return RedirectToAction("index", "Akademsiyen");

                }

            }
            else
            {

                ViewBag.Mesaj = "Geçersiz Eposta veya Parola";
                return View();

            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}