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
    
    public class AssetsController : Controller
    {
        private EntityConfig db = new EntityConfig();

        // GET: Assets
        public ActionResult Index()
        {
            return View(db.AssetsPs.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsP assetsP = db.AssetsPs.Find(id);
            if (assetsP == null)
            {
                return HttpNotFound();
            }
            return View(assetsP);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AssetsP assetsP)
        {
            if (ModelState.IsValid)
            {
                db.AssetsPs.Add(assetsP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assetsP);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsP assetsP = db.AssetsPs.Find(id);
            if (assetsP == null)
            {
                return HttpNotFound();
            }
            return View(assetsP);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "item_ID,item_name,category,status")] AssetsP assetsP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetsP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assetsP);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsP assetsP = db.AssetsPs.Find(id);
            if (assetsP == null)
            {
                return HttpNotFound();
            }
            return View(assetsP);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsP assetsP = db.AssetsPs.Find(id);
            db.AssetsPs.Remove(assetsP);
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
