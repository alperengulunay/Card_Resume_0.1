using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Card_Resume_0._1.Models;
using Card_Resume_0._1.Views.Home;


namespace Card_Resume_0._1.Controllers
{
    public class HomeController : Controller
    {
        private AAContext db = new AAContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Card()
        {
            var lastInfo = db.PersonInfoes.OrderByDescending(p => p.ID).FirstOrDefault();
            return View(lastInfo);
        }

        [HttpPost]
        public ActionResult Bind() 
        {
            return RedirectToAction("Card");
        }

        public ActionResult GeneratePDF()
        {
            // Direkt indirme
            var report = new Rotativa.ActionAsPdf("Card") 
            { FileName = "MyBusinessCard.pdf", PageHeight = 120, PageWidth = 100 
            };
            // Önizleme ile
            //var report = new Rotativa.ActionAsPdf("Card")
            //{ PageHeight = 120, PageWidth = 100
            //};
            return report;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,Name1,Adres1,Tel1,E_Posta1")] PersonInfo perInfo)
        {
            if (ModelState.IsValid)
            {
                db.PersonInfoes.Add(perInfo);
                db.SaveChanges();
                return RedirectToAction("GeneratePDF");
            }
            return View(perInfo);
        }
    }
}