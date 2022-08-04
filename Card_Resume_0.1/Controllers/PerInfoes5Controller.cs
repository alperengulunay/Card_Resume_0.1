using Card_Resume_0._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Card_Resume_0._1.Controllers
{
    public class PerInfoes5Controller : Controller
    {
        private AAContext db = new AAContext();

        // GET: PerInfoes5
        public ActionResult Index()
        {
            return View(db.PerInfoes.ToList());
        }

        // GET: PerInfoes5/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfoes.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // GET: PerInfoes5/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerInfoes5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name1,Adres1,Tel1,E_Posta1")] PerInfo perInfo)
        {
            if (ModelState.IsValid)
            {
                db.PerInfoes.Add(perInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perInfo);
        }

        // GET: PerInfoes5/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfoes.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // POST: PerInfoes5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: PerInfoes5/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerInfo perInfo = db.PerInfoes.Find(id);
            if (perInfo == null)
            {
                return HttpNotFound();
            }
            return View(perInfo);
        }

        // POST: PerInfoes5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerInfo perInfo = db.PerInfoes.Find(id);
            db.PerInfoes.Remove(perInfo);
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
