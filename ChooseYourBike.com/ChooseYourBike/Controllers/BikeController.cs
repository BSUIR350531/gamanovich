using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChooseYourBike.Models;
using PagedList;

namespace ChooseYourBike.Controllers
{
    public class BikeController : Controller
    {
        // GET: Home
        private BikeSiteDBEntities db = new BikeSiteDBEntities();
        public ActionResult Index(int? page)
        {
            var product =
                db.Product.Include(p => p.Accesories1)
                    .Include(p => p.Brakes1)
                    .Include(p => p.Category1)
                    .Include(p => p.Fork1)
                    .Include(p => p.Frame1)
                    .Include(p => p.Mark1)
                    .Include(p => p.Pedals1)
                    .Include(p => p.Advertising11)
                    .Include(p => p.Image2)
                    .Include(p => p.Saddle1)
                    .Include(p => p.Shifters1)
                    .Include(p => p.StrWheel1)
                    .Include(p => p.Transmission1)
                    .Include(p => p.Wheels1)
                    .Include(p => p.Comments1)
                    .OrderBy(p => p.ID);
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Info(string mark, string model)
        {
            var product =
                db.Product.Include(p => p.Accesories1)
                    .Include(p => p.Brakes1)
                    .Include(p => p.Category1)
                    .Include(p => p.Fork1)
                    .Include(p => p.Frame1)
                    .Include(p => p.Mark1)
                    .Include(p => p.Pedals1)
                    .Include(p => p.Advertising11)
                    .Include(p => p.Image2)
                    .Include(p => p.Saddle1)
                    .Include(p => p.Shifters1)
                    .Include(p => p.StrWheel1)
                    .Include(p => p.Transmission1)
                    .Include(p => p.Wheels1)
                    .Include(p => p.Comments1)
                    .Where(p => p.Mark1.Mark_Name == mark)
                    .Where(p => p.Model == model);

            return View(product.First());
        }
    }
}