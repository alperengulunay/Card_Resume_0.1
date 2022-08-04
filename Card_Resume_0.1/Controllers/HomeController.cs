using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Card_Resume_0._1.Views.Home;


namespace Card_Resume_0._1.Controllers
{
    public class HomeController : Controller
    {
        private ResumeDBContext db = new ResumeDBContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Card()
        {
            return View();
        }

        public ActionResult GeneratePDF()
        {
            // Direkt indirme
            //var report = new Rotativa.ActionAsPdf("Card") { FileName="MyBusinessCard.pdf", PageHeight=200 };
            // Önizleme ile
            var report = new Rotativa.ActionAsPdf("Card")
            {
                PageHeight = 120,
                PageWidth = 100,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                ContentDisposition = Rotativa.Options.ContentDisposition.Inline,
            };

            return report;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,Name1,Adres1,Tel1,E_Posta1")] PerInfo perInfo)
        {
            if (ModelState.IsValid)
            {
                db.PerInfos.Add(perInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perInfo);
        }
    }
}