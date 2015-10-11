using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChooseYourBike.Models;

namespace ChooseYourBike.Areas.Admin.Controllers
{
    public class BrakesController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Brakes
        public ActionResult Index()
        {
            return View(db.Brakes.ToList());
        }

        // GET: Admin/Brakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // GET: Admin/Brakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brakes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FrBrakeName,FrBrakeType,RrBrakeName,RrBrakeType")] Brakes brakes)
        {
            if (ModelState.IsValid)
            {
                db.Brakes.Add(brakes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brakes);
        }

        // GET: Admin/Brakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // POST: Admin/Brakes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FrBrakeName,FrBrakeType,RrBrakeName,RrBrakeType")] Brakes brakes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brakes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brakes);
        }

        // GET: Admin/Brakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // POST: Admin/Brakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brakes brakes = db.Brakes.Find(id);
            db.Brakes.Remove(brakes);
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
