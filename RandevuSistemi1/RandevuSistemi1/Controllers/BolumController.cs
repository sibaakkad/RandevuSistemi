using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;

namespace RandevuSistemi1.Controllers
{
    [Authorize(Roles = "Ad")]
    public class BolumController : Controller
    {
        // GET: Bolum
        RandevuSistemi rs = new RandevuSistemi();
        public ActionResult Index()
        {
            List<Bolumler> bolumler = rs.Bolumlers.ToList();
            ViewBag.fakulte = rs.Fakultelers.ToList();
            return View(bolumler);
        }

        [HttpPost]
        public string BolumSil(int id)
        {

            Bolumler bolum = rs.Bolumlers.FirstOrDefault(x => x.BolumId == id);
            rs.Bolumlers.Remove(bolum);
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
        public ActionResult BolumEkle(Bolumler b)
        {
            rs.Bolumlers.Add(b);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}