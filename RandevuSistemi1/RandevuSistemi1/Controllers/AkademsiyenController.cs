using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using RandevuSistemi1.Models;

namespace RandevuSistemi1.Controllers
{
    [Authorize(Roles = "Ad")]
    public class AkademsiyenController : Controller
    {
        RandevuSistemi rs = new RandevuSistemi();

        public ActionResult Index()
        {
            List<Akademisyenler> akademsiyenler = rs.Akademisyenlers.ToList();
            return View(akademsiyenler);
        }
        [HttpPost]
        public string AkademsiyenSil(int id)
        {
            Akademisyenler ak = rs.Akademisyenlers.FirstOrDefault(x => x.AkmId == id);
            Kullaniciler ku = rs.Kullanicilers.FirstOrDefault(x => x.akmGirisID == ak.AkmId);

            rs.Akademisyenlers.Remove(ak);
            rs.Kullanicilers.Remove(ku);
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

        public ActionResult AkademsiyenEkle()
        {
            ViewBag.fakulte = rs.Fakultelers.ToList();
            ViewBag.bolum = rs.Bolumlers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AkademsiyenEkle(Akademisyenler ak, Kullaniciler ku)
        {
            rs.Akademisyenlers.Add(ak);
            ku.KullaniciRole = "A";
            ku.akmGirisID = ak.AkmId;
            rs.Kullanicilers.Add(ku);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AkademsiyenGuncelle(int id)
        {
            Akademisyenler ak = rs.Akademisyenlers.FirstOrDefault(x => x.AkmId == id);
            ViewBag.akm = ak;
            ViewBag.fakulte = rs.Fakultelers.ToList();
            ViewBag.bolum = rs.Bolumlers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AkademsiyenGuncelle(int AkmId, string Ad, string Soyad, string Eposta, int FakulteId, int BolumId, string Parola)
        {
            Akademisyenler ak = rs.Akademisyenlers.FirstOrDefault(x => x.AkmId == AkmId);
            Kullaniciler ku = rs.Kullanicilers.FirstOrDefault(x => x.akmGirisID == ak.AkmId);


            ak.AkmId = AkmId;
            ak.Ad = Ad;
            ak.Soyad = Soyad;
            ak.Eposta = Eposta;
            ak.BolumId = BolumId;
            ak.FakulteId = FakulteId;
            ak.Parola = Parola;
            rs.Akademisyenlers.AddOrUpdate(ak);

            ku.Eposta = Eposta;
            ku.Parola = Parola;
            rs.Kullanicilers.AddOrUpdate(ku);

            rs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}