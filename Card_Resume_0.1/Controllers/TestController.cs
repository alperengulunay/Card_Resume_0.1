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
    public class TestController : Controller
    {
        // GET: Test
        //public ActionResult Index()
        //{
        //    return View();
        //    //return new ViewAsPdf();
        //}

        private ResumeDBContext db = new ResumeDBContext();      
                                                                 
        // GET: PerInfos3/Create                                 
        public ActionResult Index()                              
        {                                                        
            return View();                                       
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


        public ActionResult GeneratePDF()
        {
            var report = new Rotativa.ActionAsPdf("Index");
            return report;
        }
    }
}