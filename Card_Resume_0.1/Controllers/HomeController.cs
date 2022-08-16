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


        public ActionResult Card(int? ID)
        {
            //var lastInfo = db.User_Infos.OrderByDescending(p => p.ID).FirstOrDefault();
            var quote = db.User_Infos.Single(x => x.User_ID == ID);
            return View(quote);
        }

        public ActionResult GeneratePDF(int? ID)
        {
            // Direkt indirme
            var report = new Rotativa.ActionAsPdf("Card", new { ID = ID }) 
            { FileName = "MyBusinessCard.pdf", PageHeight = 240, PageWidth = 200 };
            // Önizleme
            //var report = new Rotativa.ActionAsPdf("Card")
            //{ PageHeight = 240, PageWidth = 200 };
            return report;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,User_ID,Name1,Adres1,Tel1,E_Posta1")] User_Info userInfo)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                userInfo.User_ID = rnd.Next(100000000, 999999999);
                db.User_Infos.Add(userInfo);
                int in_use_ID = userInfo.User_ID;
                db.SaveChanges();
                return RedirectToAction("GeneratePDF", new { ID = in_use_ID });
            }
            return View(userInfo);
        }
    }
}