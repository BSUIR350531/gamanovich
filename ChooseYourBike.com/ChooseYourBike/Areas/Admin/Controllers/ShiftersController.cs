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
    public class ShiftersController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Shifters
        public ActionResult Index()
        {
            return View(db.Shifters.ToList());
        }

        // GET: Admin/Shifters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifters shifters = db.Shifters.Find(id);
            if (shifters == null)
            {
                return HttpNotFound();
            }
            return View(shifters);
        }

        // GET: Admin/Shifters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shifters/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShiftersName,ShiftersType")] Shifters shifters)
        {
            if (ModelState.IsValid)
            {
                db.Shifters.Add(shifters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shifters);
        }

        // GET: Admin/Shifters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifters shifters = db.Shifters.Find(id);
            if (shifters == null)
            {
                return HttpNotFound();
            }
            return View(shifters);
        }

        // POST: Admin/Shifters/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShiftersName,ShiftersType")] Shifters shifters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shifters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shifters);
        }

        // GET: Admin/Shifters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifters shifters = db.Shifters.Find(id);
            if (shifters == null)
            {
                return HttpNotFound();
            }
            return View(shifters);
        }

        // POST: Admin/Shifters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shifters shifters = db.Shifters.Find(id);
            db.Shifters.Remove(shifters);
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
