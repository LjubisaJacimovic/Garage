using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage.Models;

namespace Garage.Controllers
{
    public class DeloviController : Controller
    {
        private GarageDB2Entities db = new GarageDB2Entities();

        // GET: /Delovi/
        public ActionResult Index()
        {
            return View(db.ProductType.ToList());
        }

        // GET: /Delovi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductType.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // GET: /Delovi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Delovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.ProductType.Add(producttype);
                db.SaveChanges();
                return RedirectToAction("Parts","Home");
            }

            return View(producttype);
        }

        // GET: /Delovi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductType.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /Delovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Parts", "Home");
            }
            return View(producttype);
        }

        // GET: /Delovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductType.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /Delovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductType producttype = db.ProductType.Find(id);
            db.ProductType.Remove(producttype);
            db.SaveChanges();
            return RedirectToAction("Parts", "Home");
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
