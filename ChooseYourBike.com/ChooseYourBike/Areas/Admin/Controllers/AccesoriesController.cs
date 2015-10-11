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
    public class AccesoriesController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Accesories
        public ActionResult Index()
        {
            return View(db.Accesories.ToList());
        }

        // GET: Admin/Accesories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesories accesories = db.Accesories.Find(id);
            if (accesories == null)
            {
                return HttpNotFound();
            }
            return View(accesories);
        }

        // GET: Admin/Accesories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Accesories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AccDescription")] Accesories accesories)
        {
            if (ModelState.IsValid)
            {
                db.Accesories.Add(accesories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accesories);
        }

        // GET: Admin/Accesories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesories accesories = db.Accesories.Find(id);
            if (accesories == null)
            {
                return HttpNotFound();
            }
            return View(accesories);
        }

        // POST: Admin/Accesories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AccDescription")] Accesories accesories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accesories);
        }

        // GET: Admin/Accesories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesories accesories = db.Accesories.Find(id);
            if (accesories == null)
            {
                return HttpNotFound();
            }
            return View(accesories);
        }

        // POST: Admin/Accesories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accesories accesories = db.Accesories.Find(id);
            db.Accesories.Remove(accesories);
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
