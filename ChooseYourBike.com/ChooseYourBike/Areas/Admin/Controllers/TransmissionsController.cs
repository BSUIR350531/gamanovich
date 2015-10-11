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
    public class TransmissionsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Transmissions
        public ActionResult Index()
        {
            return View(db.Transmission.ToList());
        }

        // GET: Admin/Transmissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = db.Transmission.Find(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // GET: Admin/Transmissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Transmissions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SpeedCount,SystemName,Chain")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                db.Transmission.Add(transmission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transmission);
        }

        // GET: Admin/Transmissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = db.Transmission.Find(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // POST: Admin/Transmissions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SpeedCount,SystemName,Chain")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transmission);
        }

        // GET: Admin/Transmissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = db.Transmission.Find(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // POST: Admin/Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transmission transmission = db.Transmission.Find(id);
            db.Transmission.Remove(transmission);
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
