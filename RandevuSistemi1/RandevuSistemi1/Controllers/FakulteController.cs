using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi1.Models;

namespace RandevuSistemi1.Controllers
{

    [Authorize(Roles = "Ad")]
    public class FakulteController : Controller
    {
        // GET: Fakulte
        RandevuSistemi rs = new RandevuSistemi();
        public ActionResult Index()
        {
            List<Fakulteler> fakulteler = rs.Fakultelers.ToList();
            return View(fakulteler);
        }
        [HttpPost]
        public string FakulteSil(int id)
        {
            Fakulteler f = rs.Fakultelers.FirstOrDefault(x => x.FakulteId == id);
            rs.Fakultelers.Remove(f);
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
        public ActionResult FakulteEkle(Fakulteler f)
        {
            rs.Fakultelers.Add(f);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}