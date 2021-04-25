using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;


namespace RandevuSistemi1.Controllers
{
    public class RandevuController : Controller
    {
        RandevuSistemi rs = new RandevuSistemi();
        public ActionResult Index()
        {
            List<Randevu> ran;
            int id;
            string userEmail = HttpContext.User.Identity.Name;
            Kullaniciler currentUser = rs.Kullanicilers.FirstOrDefault(x => x.Eposta == userEmail);
            if (User.IsInRole("A"))
            {
                id = Convert.ToInt32(currentUser.akmGirisID);
                ran = rs.Randevus.Where(x => x.AkmId == id).ToList();
            }
            else
            {
                id = Convert.ToInt32(currentUser.ogrenciGirisID);
                ran = rs.Randevus.Where(x => x.OgrId == id).ToList();
            }


            return View(ran);
        }
        [HttpPost]
        public string RandevuSil(int id)
        {
            Randevu ran = rs.Randevus.FirstOrDefault(x => x.RandevuId == id);
            rs.Randevus.Remove(ran);
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

        public ActionResult RandevuEkle()
        {
            ViewBag.fakulte = rs.Fakultelers.ToList();
            ViewBag.bolum = rs.Bolumlers.ToList();
            ViewBag.Akademisyen = rs.Akademisyenlers.ToList();
            ViewBag.saat = rs.Saatlers.ToList();
            ViewBag.tarih = rs.Müsaitlikler.ToList();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "O")]
        public ActionResult RandevuEkle(Randevu ran)
        {
            string userEmail = HttpContext.User.Identity.Name;
            Kullaniciler currentUser = rs.Kullanicilers.FirstOrDefault(x => x.Eposta == userEmail);
            ran.OgrId = currentUser.ogrenciGirisID;
            rs.Randevus.Add(ran);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public string RandevuOnayla(int id)
        {
            Randevu ran = rs.Randevus.FirstOrDefault(x => x.RandevuId == id);
            ran.AktifMi = true;
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

    }
}