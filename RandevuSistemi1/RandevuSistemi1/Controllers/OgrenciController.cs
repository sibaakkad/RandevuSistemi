using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;


namespace RandevuSistemi1.Controllers
{
    [Authorize(Roles = "Ad")]
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        RandevuSistemi rs = new RandevuSistemi();
        public ActionResult Index()
        {
            List<Ogrenciler> Ogrenciler = rs.Ogrencilers.ToList();

            return View(Ogrenciler);
        }

        [HttpPost]
        public string OgrenciSil(int id)
        {
            Ogrenciler ogr = rs.Ogrencilers.FirstOrDefault(x => x.OgrId == id);
            Kullaniciler ku = rs.Kullanicilers.FirstOrDefault(x => x.ogrenciGirisID == ogr.OgrId);

            rs.Kullanicilers.Remove(ku);
            rs.Ogrencilers.Remove(ogr);
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

        public ActionResult OgrenciEkle()
        {
            ViewBag.fakulte = rs.Fakultelers.ToList();
            ViewBag.bolum = rs.Bolumlers.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenciler ogr, Kullaniciler ku)
        {
            rs.Ogrencilers.Add(ogr);
            ku.KullaniciRole = "O";
            ku.ogrenciGirisID = ogr.OgrId;
            rs.Kullanicilers.Add(ku);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGuncelle(int id)
        {
            Ogrenciler ogr = rs.Ogrencilers.FirstOrDefault(x => x.OgrId == id);
            ViewBag.ogr = ogr;
            ViewBag.fakulte = rs.Fakultelers.ToList();
            ViewBag.bolum = rs.Bolumlers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciGuncelle(int OgrId, string OgrNo, string Ad, string Soyad, string EPosta, int FakulteId, int BolumId, string Parola)
        {
            Ogrenciler ogr = rs.Ogrencilers.FirstOrDefault(x => x.OgrId == OgrId);
            Kullaniciler ku = rs.Kullanicilers.FirstOrDefault(x => x.ogrenciGirisID == ogr.OgrId);

            ogr.OgrId = OgrId;
            ogr.OgrNo = OgrNo;
            ogr.Ad = Ad;
            ogr.Soyad = Soyad;
            ogr.EPosta = EPosta;
            ogr.BolumId = BolumId;
            ogr.FakulteId = FakulteId;
            ogr.Parola = Parola;
            rs.Ogrencilers.AddOrUpdate(ogr);

            ku.Eposta = EPosta;
            ku.Parola = Parola;
            rs.Kullanicilers.AddOrUpdate(ku);

            rs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}