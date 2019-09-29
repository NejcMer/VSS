using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class zivaliController : Controller
    {
        private zivaliContext db = new zivaliContext();

        // GET: zivali
        public ActionResult Index()
        {
            return View(db.zivalis.ToList());
        }

        // GET: zivali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivali zivali = db.zivalis.Find(id);
            if (zivali == null)
            {
                return HttpNotFound();
            }
            return View(zivali);
        }

        // GET: zivali/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zivali/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Deblo,Razred,Red,Druzina,Vrsta")] zivali zivali)
        {
            if (ModelState.IsValid)
            {
                db.zivalis.Add(zivali);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zivali);
        }

        // GET: zivali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivali zivali = db.zivalis.Find(id);
            if (zivali == null)
            {
                return HttpNotFound();
            }
            return View(zivali);
        }

        // POST: zivali/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Deblo,Razred,Red,Druzina,Vrsta")] zivali zivali)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zivali).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zivali);
        }

        // GET: zivali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivali zivali = db.zivalis.Find(id);
            if (zivali == null)
            {
                return HttpNotFound();
            }
            return View(zivali);
        }

        // POST: zivali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zivali zivali = db.zivalis.Find(id);
            db.zivalis.Remove(zivali);
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
