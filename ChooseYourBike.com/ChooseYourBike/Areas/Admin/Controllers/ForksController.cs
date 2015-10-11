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
    public class ForksController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Forks
        public ActionResult Index()
        {
            return View(db.Fork.ToList());
        }

        // GET: Admin/Forks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = db.Fork.Find(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // GET: Admin/Forks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Forks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ForkName,ForkType,ShockStep,Block,Diameter")] Fork fork)
        {
            if (ModelState.IsValid)
            {
                db.Fork.Add(fork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fork);
        }

        // GET: Admin/Forks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = db.Fork.Find(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // POST: Admin/Forks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ForkName,ForkType,ShockStep,Block,Diameter")] Fork fork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fork);
        }

        // GET: Admin/Forks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = db.Fork.Find(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // POST: Admin/Forks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fork fork = db.Fork.Find(id);
            db.Fork.Remove(fork);
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
