using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterOfFixAssets.Models;

namespace RegisterOfFixAssets.Controllers
{
    public class SupplierController : Controller
    {
        private EntityConfig db = new EntityConfig();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.SuppllierPs.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppllierP suppllierP = db.SuppllierPs.Find(id);
            if (suppllierP == null)
            {
                return HttpNotFound();
            }
            return View(suppllierP);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supplier_ID,Supplier_Name,Address,status")] SuppllierP suppllierP)
        {
            if (ModelState.IsValid)
            {
                db.SuppllierPs.Add(suppllierP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suppllierP);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppllierP suppllierP = db.SuppllierPs.Find(id);
            if (suppllierP == null)
            {
                return HttpNotFound();
            }
            return View(suppllierP);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppllierP suppllierP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppllierP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suppllierP);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppllierP suppllierP = db.SuppllierPs.Find(id);
            if (suppllierP == null)
            {
                return HttpNotFound();
            }
            return View(suppllierP);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuppllierP suppllierP = db.SuppllierPs.Find(id);
            db.SuppllierPs.Remove(suppllierP);
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
