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
    public class AdvertisingsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Advertisings
        public ActionResult Index()
        {
            var advertising = db.Advertising.Include(a => a.Product1);
            return View(advertising.ToList());
        }

        // GET: Admin/Advertisings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertising.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // GET: Admin/Advertisings/Create
        public ActionResult Create()
        {
            ViewBag.Advertising_ID = new SelectList(db.Product, "ID", "Model");
            return View();
        }

        // POST: Admin/Advertisings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,CompanyAddress,Telephone,Price,Advertising_ID")] Advertising advertising)
        {
            if (ModelState.IsValid)
            {
                db.Advertising.Add(advertising);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Advertising_ID = new SelectList(db.Product, "ID", "Model", advertising.Advertising_ID);
            return View(advertising);
        }

        // GET: Admin/Advertisings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertising.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            ViewBag.Advertising_ID = new SelectList(db.Product, "ID", "Model", advertising.Advertising_ID);
            return View(advertising);
        }

        // POST: Admin/Advertisings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,CompanyAddress,Telephone,Price,Advertising_ID")] Advertising advertising)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertising).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Advertising_ID = new SelectList(db.Product, "ID", "Model", advertising.Advertising_ID);
            return View(advertising);
        }

        // GET: Admin/Advertisings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertising.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // POST: Admin/Advertisings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertising advertising = db.Advertising.Find(id);
            db.Advertising.Remove(advertising);
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
