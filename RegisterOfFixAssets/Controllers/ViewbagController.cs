using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegisterOfFixAssets.Models;
using System.Web.Mvc;

namespace RegisterOfFixAssets.Controllers
{
    public class ViewbagController : Controller
    {
        // GET: Viewbag
        [Route("Test/Test")]
        public ActionResult Index()
        {
            EntityConfig db = new EntityConfig();
            AssetsP model = new AssetsP();
            List<SelectListItem> itemlist = new List<SelectListItem>();
            foreach(var items in db.AssetsPs)
            {
                itemlist.Add(new SelectListItem { Text = items.item_name, Value = items.item_ID.ToString() });
            }
            ViewBag.ItemCollection = itemlist;
            return View();
        }
    }
}