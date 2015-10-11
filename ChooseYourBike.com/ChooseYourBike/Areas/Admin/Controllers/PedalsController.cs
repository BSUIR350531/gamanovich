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
    public class PedalsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Pedals
        public ActionResult Index()
        {
            return View(db.Pedals.ToList());
        }

        // GET: Admin/Pedals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedals pedals = db.Pedals.Find(id);
            if (pedals == null)
            {
                return HttpNotFound();
            }
            return View(pedals);
        }

        // GET: Admin/Pedals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Pedals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Material,PedalsType")] Pedals pedals)
        {
            if (ModelState.IsValid)
            {
                db.Pedals.Add(pedals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedals);
        }

        // GET: Admin/Pedals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedals pedals = db.Pedals.Find(id);
            if (pedals == null)
            {
                return HttpNotFound();
            }
            return View(pedals);
        }

        // POST: Admin/Pedals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Material,PedalsType")] Pedals pedals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedals);
        }

        // GET: Admin/Pedals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedals pedals = db.Pedals.Find(id);
            if (pedals == null)
            {
                return HttpNotFound();
            }
            return View(pedals);
        }

        // POST: Admin/Pedals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedals pedals = db.Pedals.Find(id);
            db.Pedals.Remove(pedals);
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
