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
    public class FramesController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Frames
        public ActionResult Index()
        {
            return View(db.Frame.ToList());
        }

        // GET: Admin/Frames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frame frame = db.Frame.Find(id);
            if (frame == null)
            {
                return HttpNotFound();
            }
            return View(frame);
        }

        // GET: Admin/Frames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Frames/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Material,FrameType,FrameColor")] Frame frame)
        {
            if (ModelState.IsValid)
            {
                db.Frame.Add(frame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frame);
        }

        // GET: Admin/Frames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frame frame = db.Frame.Find(id);
            if (frame == null)
            {
                return HttpNotFound();
            }
            return View(frame);
        }

        // POST: Admin/Frames/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Material,FrameType,FrameColor")] Frame frame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frame);
        }

        // GET: Admin/Frames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frame frame = db.Frame.Find(id);
            if (frame == null)
            {
                return HttpNotFound();
            }
            return View(frame);
        }

        // POST: Admin/Frames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frame frame = db.Frame.Find(id);
            db.Frame.Remove(frame);
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
