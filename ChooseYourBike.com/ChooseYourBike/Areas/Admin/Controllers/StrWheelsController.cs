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
    public class StrWheelsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/StrWheels
        public ActionResult Index()
        {
            return View(db.StrWheel.ToList());
        }

        // GET: Admin/StrWheels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrWheel strWheel = db.StrWheel.Find(id);
            if (strWheel == null)
            {
                return HttpNotFound();
            }
            return View(strWheel);
        }

        // GET: Admin/StrWheels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StrWheels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StrWheelName,StrWheelType")] StrWheel strWheel)
        {
            if (ModelState.IsValid)
            {
                db.StrWheel.Add(strWheel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strWheel);
        }

        // GET: Admin/StrWheels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrWheel strWheel = db.StrWheel.Find(id);
            if (strWheel == null)
            {
                return HttpNotFound();
            }
            return View(strWheel);
        }

        // POST: Admin/StrWheels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StrWheelName,StrWheelType")] StrWheel strWheel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strWheel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strWheel);
        }

        // GET: Admin/StrWheels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrWheel strWheel = db.StrWheel.Find(id);
            if (strWheel == null)
            {
                return HttpNotFound();
            }
            return View(strWheel);
        }

        // POST: Admin/StrWheels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StrWheel strWheel = db.StrWheel.Find(id);
            db.StrWheel.Remove(strWheel);
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
