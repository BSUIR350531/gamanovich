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
    public class WheelsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Wheels
        public ActionResult Index()
        {
            return View(db.Wheels.ToList());
        }

        // GET: Admin/Wheels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheels wheels = db.Wheels.Find(id);
            if (wheels == null)
            {
                return HttpNotFound();
            }
            return View(wheels);
        }

        // GET: Admin/Wheels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Wheels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Diameter,Material,Tyres")] Wheels wheels)
        {
            if (ModelState.IsValid)
            {
                db.Wheels.Add(wheels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wheels);
        }

        // GET: Admin/Wheels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheels wheels = db.Wheels.Find(id);
            if (wheels == null)
            {
                return HttpNotFound();
            }
            return View(wheels);
        }

        // POST: Admin/Wheels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Diameter,Material,Tyres")] Wheels wheels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wheels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wheels);
        }

        // GET: Admin/Wheels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheels wheels = db.Wheels.Find(id);
            if (wheels == null)
            {
                return HttpNotFound();
            }
            return View(wheels);
        }

        // POST: Admin/Wheels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wheels wheels = db.Wheels.Find(id);
            db.Wheels.Remove(wheels);
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
