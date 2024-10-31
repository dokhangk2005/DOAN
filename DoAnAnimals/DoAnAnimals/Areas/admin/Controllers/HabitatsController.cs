using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnAnimals.Models;

namespace DoAnAnimals.Areas.admin.Controllers
{
    public class HabitatsController : Controller
    {
        private DoAnEntities1 db = new DoAnEntities1();

        // GET: admin/Habitats
        public ActionResult Index()
        {
            return View(db.Habitats.ToList());
        }

        // GET: admin/Habitats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitat habitat = db.Habitats.Find(id);
            if (habitat == null)
            {
                return HttpNotFound();
            }
            return View(habitat);
        }

        // GET: admin/Habitats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Habitats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Habitat_ID,Habitat_Type,Description")] Habitat habitat)
        {
            if (ModelState.IsValid)
            {
                db.Habitats.Add(habitat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(habitat);
        }

        // GET: admin/Habitats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitat habitat = db.Habitats.Find(id);
            if (habitat == null)
            {
                return HttpNotFound();
            }
            return View(habitat);
        }

        // POST: admin/Habitats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Habitat_ID,Habitat_Type,Description")] Habitat habitat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habitat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(habitat);
        }

        // GET: admin/Habitats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitat habitat = db.Habitats.Find(id);
            if (habitat == null)
            {
                return HttpNotFound();
            }
            return View(habitat);
        }

        // POST: admin/Habitats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Habitat habitat = db.Habitats.Find(id);
            db.Habitats.Remove(habitat);
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
