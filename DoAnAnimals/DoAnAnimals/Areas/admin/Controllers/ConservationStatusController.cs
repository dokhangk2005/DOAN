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
    public class ConservationStatusController : Controller
    {
        private DoAnEntities1 db = new DoAnEntities1();

        // GET: admin/ConservationStatus
        public ActionResult Index()
        {
            return View(db.ConservationStatus.ToList());
        }

        // GET: admin/ConservationStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConservationStatu conservationStatu = db.ConservationStatus.Find(id);
            if (conservationStatu == null)
            {
                return HttpNotFound();
            }
            return View(conservationStatu);
        }

        // GET: admin/ConservationStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/ConservationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status_ID,Status_Name,Description")] ConservationStatu conservationStatu)
        {
            if (ModelState.IsValid)
            {
                db.ConservationStatus.Add(conservationStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conservationStatu);
        }

        // GET: admin/ConservationStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConservationStatu conservationStatu = db.ConservationStatus.Find(id);
            if (conservationStatu == null)
            {
                return HttpNotFound();
            }
            return View(conservationStatu);
        }

        // POST: admin/ConservationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Status_ID,Status_Name,Description")] ConservationStatu conservationStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conservationStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conservationStatu);
        }

        // GET: admin/ConservationStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConservationStatu conservationStatu = db.ConservationStatus.Find(id);
            if (conservationStatu == null)
            {
                return HttpNotFound();
            }
            return View(conservationStatu);
        }

        // POST: admin/ConservationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConservationStatu conservationStatu = db.ConservationStatus.Find(id);
            db.ConservationStatus.Remove(conservationStatu);
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
