using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterOfFixAssets.Models;

namespace RegisterOfFixAssets.Controllers
{
    public class DashboardController : Controller
    {
        EntityConfig db = new EntityConfig();
        // GET: Dashboard
        public ActionResult Index()
        {

            ViewBag.totalrecognizable = db.AssetsPs.Where(x => x.category == 1).Count();
            ViewBag.totalnonrecognizable = db.AssetsPs.Where(x => x.category == 2).Count();
            ViewBag.totalEntry = db.Detail_Master.Count();
            ViewBag.disposeditem = db.Detail_Master.Where(x => x.Status == 0).Count();
            ViewBag.activeitem = db.AssetsPs.Where(x => x.status == 1).Count();
            ViewBag.tatalSupplier = db.SuppllierPs.Count();

           
            return View();
        }
    }
}