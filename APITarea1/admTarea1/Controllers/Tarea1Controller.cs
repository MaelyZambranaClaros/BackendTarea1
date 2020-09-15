using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admTarea1.Models;

namespace admTarea1.Controllers
{
    public class Tarea1Controller : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tarea1
        public ActionResult Index()
        {
            return View(db.Tarea1.ToList());
        }

        // GET: Tarea1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea1 tarea1 = db.Tarea1.Find(id);
            if (tarea1 == null)
            {
                return HttpNotFound();
            }
            return View(tarea1);
        }

        // GET: Tarea1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarea1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZambranaID,FrinedofZambrana,Place,Email,Birthdate")] Tarea1 tarea1)
        {
            if (ModelState.IsValid)
            {
                db.Tarea1.Add(tarea1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarea1);
        }

        // GET: Tarea1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea1 tarea1 = db.Tarea1.Find(id);
            if (tarea1 == null)
            {
                return HttpNotFound();
            }
            return View(tarea1);
        }

        // POST: Tarea1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZambranaID,FrinedofZambrana,Place,Email,Birthdate")] Tarea1 tarea1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarea1);
        }

        // GET: Tarea1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea1 tarea1 = db.Tarea1.Find(id);
            if (tarea1 == null)
            {
                return HttpNotFound();
            }
            return View(tarea1);
        }

        // POST: Tarea1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea1 tarea1 = db.Tarea1.Find(id);
            db.Tarea1.Remove(tarea1);
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
