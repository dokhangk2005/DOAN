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
    public class AnimalsController : Controller
    {
        private DoAnEntities1 db = new DoAnEntities1();

        // GET: admin/Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.ConservationStatu).Include(a => a.Diet1).Include(a => a.Habitat).Include(a => a.Region1);
            return View(animals.ToList());
        }

        // GET: admin/Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: admin/Animals/Create
        public ActionResult Create()
        {
            ViewBag.Conservation_Status = new SelectList(db.ConservationStatus, "Status_ID", "Status_Name");
            ViewBag.Diet = new SelectList(db.Diets, "Diet_ID", "Diet_Type");
            ViewBag.Habitat_ID = new SelectList(db.Habitats, "Habitat_ID", "Habitat_Type");
            ViewBag.Region = new SelectList(db.Regions, "Region_ID", "Region_Name");
            return View();
        }

        // POST: admin/Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Habitat_ID,Conservation_Status,Diet,Lifespan,Size,Image_URL,Region")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Conservation_Status = new SelectList(db.ConservationStatus, "Status_ID", "Status_Name", animal.Conservation_Status);
            ViewBag.Diet = new SelectList(db.Diets, "Diet_ID", "Diet_Type", animal.Diet);
            ViewBag.Habitat_ID = new SelectList(db.Habitats, "Habitat_ID", "Habitat_Type", animal.Habitat_ID);
            ViewBag.Region = new SelectList(db.Regions, "Region_ID", "Region_Name", animal.Region);
            return View(animal);
        }

        // GET: admin/Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Conservation_Status = new SelectList(db.ConservationStatus, "Status_ID", "Status_Name", animal.Conservation_Status);
            ViewBag.Diet = new SelectList(db.Diets, "Diet_ID", "Diet_Type", animal.Diet);
            ViewBag.Habitat_ID = new SelectList(db.Habitats, "Habitat_ID", "Habitat_Type", animal.Habitat_ID);
            ViewBag.Region = new SelectList(db.Regions, "Region_ID", "Region_Name", animal.Region);
            return View(animal);
        }

        // POST: admin/Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Habitat_ID,Conservation_Status,Diet,Lifespan,Size,Image_URL,Region")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Conservation_Status = new SelectList(db.ConservationStatus, "Status_ID", "Status_Name", animal.Conservation_Status);
            ViewBag.Diet = new SelectList(db.Diets, "Diet_ID", "Diet_Type", animal.Diet);
            ViewBag.Habitat_ID = new SelectList(db.Habitats, "Habitat_ID", "Habitat_Type", animal.Habitat_ID);
            ViewBag.Region = new SelectList(db.Regions, "Region_ID", "Region_Name", animal.Region);
            return View(animal);
        }

        // GET: admin/Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: admin/Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
