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
    public class PerInfos3Controller : Controller
    {
        private ResumeDBContext db = new ResumeDBContext();

        // GET: PerInfos3
        public ActionResult Index()
        {
            return View(db.PerInfos.ToList());
        }

        // GET: PerInfos3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfos.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // GET: PerInfos3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerInfos3/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name1,Adres1,Tel1,E_Posta1")] PerInfo perInfo)
        {
            if (ModelState.IsValid)
            {
                db.PerInfos.Add(perInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perInfo);
        }

        // GET: PerInfos3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfos.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // POST: PerInfos3/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name1,Adres1,Tel1,E_Posta1")] PerInfo perInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perInfo);
        }

        // GET: PerInfos3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfos.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // POST: PerInfos3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerInfo perInfo = db.PerInfos.Find(id);
            db.PerInfos.Remove(perInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
