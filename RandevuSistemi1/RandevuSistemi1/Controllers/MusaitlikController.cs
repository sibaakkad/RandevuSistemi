using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;

namespace RandevuSistemi1.Controllers
{
    [Authorize(Roles = "A")]
    public class MusaitlikController : Controller
    {
        // GET: Musaitlik
        RandevuSistemi rs = new RandevuSistemi();

        public ActionResult Index()
        {
            int id;
            string userEmail = HttpContext.User.Identity.Name;
            Kullaniciler currentUser = rs.Kullanicilers.FirstOrDefault(x => x.Eposta == userEmail);
            id = Convert.ToInt32(currentUser.akmGirisID);
            List<Müsaitlikler> musaitlikler = rs.Müsaitlikler.Where(x => x.AkmId == id).ToList();
            return View(musaitlikler);
        }
        [HttpPost]
        public string MusaitlikSil(int id)
        {
            Müsaitlikler m = rs.Müsaitlikler.FirstOrDefault(x => x.Id == id);
            rs.Müsaitlikler.Remove(m);
            try
            {
                rs.SaveChanges();
                return "tamam";
            }
            catch (Exception)
            {
                return "hata";

            }
        }
        public ActionResult MusaitlikEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusaitlikEkle(Müsaitlikler m, Saatler s)
        {
            string userEmail = HttpContext.User.Identity.Name;
            Kullaniciler currentUser = rs.Kullanicilers.FirstOrDefault(x => x.Eposta == userEmail);
            rs.Saatlers.Add(s);
            m.SaatId = s.SaatId;
            m.AkmId = currentUser.akmGirisID;
            rs.Müsaitlikler.Add(m);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}