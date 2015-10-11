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
    public class SaddlesController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Saddles
        public ActionResult Index()
        {
            return View(db.Saddle.ToList());
        }

        // GET: Admin/Saddles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saddle saddle = db.Saddle.Find(id);
            if (saddle == null)
            {
                return HttpNotFound();
            }
            return View(saddle);
        }

        // GET: Admin/Saddles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Saddles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SaddleName,SaddleType")] Saddle saddle)
        {
            if (ModelState.IsValid)
            {
                db.Saddle.Add(saddle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saddle);
        }

        // GET: Admin/Saddles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saddle saddle = db.Saddle.Find(id);
            if (saddle == null)
            {
                return HttpNotFound();
            }
            return View(saddle);
        }

        // POST: Admin/Saddles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SaddleName,SaddleType")] Saddle saddle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saddle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saddle);
        }

        // GET: Admin/Saddles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saddle saddle = db.Saddle.Find(id);
            if (saddle == null)
            {
                return HttpNotFound();
            }
            return View(saddle);
        }

        // POST: Admin/Saddles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saddle saddle = db.Saddle.Find(id);
            db.Saddle.Remove(saddle);
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
