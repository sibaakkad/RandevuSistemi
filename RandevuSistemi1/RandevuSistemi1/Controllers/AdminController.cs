using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;

namespace RandevuSistemi1.Controllers
{
    [Authorize(Roles = "Ad")]
    public class AdminController : Controller
    {
        // GET: Admin
        RandevuSistemi rs = new RandevuSistemi();
        public ActionResult Index()
        {
            List<Adminler> adminler = rs.Adminlers.ToList();
            return View(adminler);
        }


        [HttpPost]
        public string AdminSil(int id)
        {
            Adminler admin = rs.Adminlers.FirstOrDefault(x => x.adminID == id);
            Kullaniciler ku = rs.Kullanicilers.FirstOrDefault(x => x.adminGirisID == admin.adminID);

            rs.Kullanicilers.Remove(ku);
            rs.Adminlers.Remove(admin);
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

        [HttpPost]
        public ActionResult AdminEkle(Adminler admin, Kullaniciler ku)
        {
            rs.Adminlers.Add(admin);
            ku.Eposta = admin.KullaniciAdi;
            if (ku.Parola != null && ku.Eposta != null)
            {
                ku.KullaniciRole = "Ad";
                ku.adminGirisID = admin.adminID;
                rs.Kullanicilers.Add(ku);
            }
            rs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}