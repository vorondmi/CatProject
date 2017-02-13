using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CatProject.Models;
using System.Data.Entity;

namespace CatProject.Controllers
{
    public class CatController : Controller
    {
        private CatDbContext db = new CatDbContext();

        public ActionResult Index()
        {
            var catList = from m in db.cats select m;

            return View(catList);
        }

        public ActionResult Create()
        {
            return View(new Cat());
        }

        [HttpPost]
        public ActionResult Create(Cat input)
        {
            if (ModelState.IsValid)
            {
                db.cats.Add(input);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(input);
        }

        public ActionResult Details(int id)
        {
            return View(db.cats.Find(id));
        }

        public ActionResult Update(int id)
        {
            return View(db.cats.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Cat updatedCat)
        {
            db.cats.Attach(updatedCat);
            db.Entry(updatedCat).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Cat catToDelete = db.cats.Find(id);
            db.cats.Remove(catToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}