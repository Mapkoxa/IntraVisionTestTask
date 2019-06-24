using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntraVisionTestTask;
using IntraVisionTestTask.Models;

namespace IntraVisionTestTask.Controllers
{
    public class AdminController : Controller
    {
        private ProjectContext db = new ProjectContext();
        
        public ActionResult Index()
        {
            ViewBag.Model = new CanOfDrinkViewModel();
            return View(db.CanOfDrinks.ToList().Select(a=>new CanOfDrinkViewModel{Count=a.Count,ImageName=a.ImageName,Name=a.Name,Price=a.Price,Id=a.Id}).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Price,Name,Image,Count")] CanOfDrinkViewModel canOfDrinkViewModel)
        {
            if (ModelState.IsValid)
            {
                CanOfDrink canOfDrink = new CanOfDrink
                {
                    Name = canOfDrinkViewModel.Name,
                    Price = canOfDrinkViewModel.Price,
                    Count = canOfDrinkViewModel.Count
                };
                if (canOfDrinkViewModel.Image != null && canOfDrinkViewModel.Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(canOfDrinkViewModel.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    canOfDrinkViewModel.Image.SaveAs(path);
                    canOfDrink.ImageName = fileName;

                }
                db.CanOfDrinks.Add(canOfDrink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Model = canOfDrinkViewModel;
            return View("Index", db.CanOfDrinks.ToList().Select(a => new CanOfDrinkViewModel { Count = a.Count, ImageName = a.ImageName, Name = a.Name, Price = a.Price, Id = a.Id }).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Name,ImageName,Image,Count")] CanOfDrinkViewModel canOfDrinkViewModel)
        {
            if (ModelState.IsValid)
            {
                CanOfDrink canOfDrink = new CanOfDrink
                {
                    Name = canOfDrinkViewModel.Name,
                    Price = canOfDrinkViewModel.Price,
                    Id=canOfDrinkViewModel.Id,
                    Count=canOfDrinkViewModel.Count,
                    ImageName = canOfDrinkViewModel.ImageName
                };
                if (canOfDrinkViewModel.Image != null && canOfDrinkViewModel.Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(canOfDrinkViewModel.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    canOfDrinkViewModel.Image.SaveAs(path);
                    canOfDrink.ImageName = fileName;
                }
                db.Entry(canOfDrink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Model = new CanOfDrinkViewModel();
            var canOfDrinks = db.CanOfDrinks.ToList().Select(a => new CanOfDrinkViewModel
                {Count = a.Count, ImageName = a.ImageName, Name = a.Name, Price = a.Price, Id = a.Id}).ToList();
            canOfDrinks[canOfDrinks.FindIndex(ind => ind.Id== canOfDrinkViewModel.Id)] = canOfDrinkViewModel;

            return View("index", canOfDrinks);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanOfDrink canOfDrink = db.CanOfDrinks.Find(id);
            if (canOfDrink == null)
            {
                return HttpNotFound();
            }
            db.CanOfDrinks.Remove(canOfDrink);
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
