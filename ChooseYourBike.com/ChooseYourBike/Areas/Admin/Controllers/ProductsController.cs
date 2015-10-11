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
    //[Authorize]
    public class ProductsController : Controller
    {
        private BikeSiteDBEntities db = new BikeSiteDBEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Accesories1).Include(p => p.Brakes1).Include(p => p.Category1).Include(p => p.Fork1).Include(p => p.Frame1).Include(p => p.Mark1).Include(p => p.Pedals1).Include(p => p.Saddle1).Include(p => p.Shifters1).Include(p => p.StrWheel1).Include(p => p.Transmission1).Include(p => p.Wheels1);
            return View(product.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Accesories = new SelectList(db.Accesories, "ID", "AccDescription");
            ViewBag.Brakes = new SelectList(db.Brakes, "ID", "FrBrakeName");
            ViewBag.Category = new SelectList(db.Category, "ID", "Category_Name");
            ViewBag.Fork = new SelectList(db.Fork, "ID", "ForkName");
            ViewBag.Frame = new SelectList(db.Frame, "ID", "Material");
            ViewBag.Mark = new SelectList(db.Mark, "ID", "Mark_Name");
            ViewBag.Pedals = new SelectList(db.Pedals, "ID", "Material");
            ViewBag.Saddle = new SelectList(db.Saddle, "ID", "SaddleName");
            ViewBag.Shifters = new SelectList(db.Shifters, "ID", "ShiftersName");
            ViewBag.StrWheel = new SelectList(db.StrWheel, "ID", "StrWheelName");
            ViewBag.Transmission = new SelectList(db.Transmission, "ID", "SystemName");
            ViewBag.Wheels = new SelectList(db.Wheels, "ID", "Diameter");
            return View();
        }

        // POST: Admin/Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mark,Model,Category,Manufacturer,DateOfBuild,Frame,Fork,Transmission,Shifters,Brakes,Wheels,StrWheel,Saddle,Pedals,Accesories")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Accesories = new SelectList(db.Accesories, "ID", "AccDescription", product.Accesories);
            ViewBag.Brakes = new SelectList(db.Brakes, "ID", "FrBrakeName", product.Brakes);
            ViewBag.Category = new SelectList(db.Category, "ID", "Category_Name", product.Category);
            ViewBag.Fork = new SelectList(db.Fork, "ID", "ForkName", product.Fork);
            ViewBag.Frame = new SelectList(db.Frame, "ID", "Material", product.Frame);
            ViewBag.Mark = new SelectList(db.Mark, "ID", "Mark_Name", product.Mark);
            ViewBag.Pedals = new SelectList(db.Pedals, "ID", "Material", product.Pedals);
            ViewBag.Saddle = new SelectList(db.Saddle, "ID", "SaddleName", product.Saddle);
            ViewBag.Shifters = new SelectList(db.Shifters, "ID", "ShiftersName", product.Shifters);
            ViewBag.StrWheel = new SelectList(db.StrWheel, "ID", "StrWheelName", product.StrWheel);
            ViewBag.Transmission = new SelectList(db.Transmission, "ID", "SystemName", product.Transmission);
            ViewBag.Wheels = new SelectList(db.Wheels, "ID", "Diameter", product.Wheels);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Accesories = new SelectList(db.Accesories, "ID", "AccDescription", product.Accesories);
            ViewBag.Brakes = new SelectList(db.Brakes, "ID", "FrBrakeName", product.Brakes);
            ViewBag.Category = new SelectList(db.Category, "ID", "Category_Name", product.Category);
            ViewBag.Fork = new SelectList(db.Fork, "ID", "ForkName", product.Fork);
            ViewBag.Frame = new SelectList(db.Frame, "ID", "Material", product.Frame);
            ViewBag.Mark = new SelectList(db.Mark, "ID", "Mark_Name", product.Mark);
            ViewBag.Pedals = new SelectList(db.Pedals, "ID", "Material", product.Pedals);
            ViewBag.Saddle = new SelectList(db.Saddle, "ID", "SaddleName", product.Saddle);
            ViewBag.Shifters = new SelectList(db.Shifters, "ID", "ShiftersName", product.Shifters);
            ViewBag.StrWheel = new SelectList(db.StrWheel, "ID", "StrWheelName", product.StrWheel);
            ViewBag.Transmission = new SelectList(db.Transmission, "ID", "SystemName", product.Transmission);
            ViewBag.Wheels = new SelectList(db.Wheels, "ID", "Diameter", product.Wheels);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mark,Model,Category,Manufacturer,DateOfBuild,Frame,Fork,Transmission,Shifters,Brakes,Wheels,StrWheel,Saddle,Pedals,Accesories")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Accesories = new SelectList(db.Accesories, "ID", "AccDescription", product.Accesories);
            ViewBag.Brakes = new SelectList(db.Brakes, "ID", "FrBrakeName", product.Brakes);
            ViewBag.Category = new SelectList(db.Category, "ID", "Category_Name", product.Category);
            ViewBag.Fork = new SelectList(db.Fork, "ID", "ForkName", product.Fork);
            ViewBag.Frame = new SelectList(db.Frame, "ID", "Material", product.Frame);
            ViewBag.Mark = new SelectList(db.Mark, "ID", "Mark_Name", product.Mark);
            ViewBag.Pedals = new SelectList(db.Pedals, "ID", "Material", product.Pedals);
            ViewBag.Saddle = new SelectList(db.Saddle, "ID", "SaddleName", product.Saddle);
            ViewBag.Shifters = new SelectList(db.Shifters, "ID", "ShiftersName", product.Shifters);
            ViewBag.StrWheel = new SelectList(db.StrWheel, "ID", "StrWheelName", product.StrWheel);
            ViewBag.Transmission = new SelectList(db.Transmission, "ID", "SystemName", product.Transmission);
            ViewBag.Wheels = new SelectList(db.Wheels, "ID", "Diameter", product.Wheels);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
