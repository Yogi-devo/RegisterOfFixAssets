using RegisterOfFixAssets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterOfFixAssets.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class ModifierController : Controller
    {
        EntityConfig db = new EntityConfig();
        public ActionResult Index()
        {
            List <SelectListItem> dropdownitems= new List<SelectListItem>();

            string query = "select [AssetsP].Item_Name, [AssetsP].Item_Id FROM [Register_Of_Fixed_Assets].[dbo].[Detail_Master] inner join [Register_Of_Fixed_Assets].[dbo].[AssetsP] on Detail_Master.item_ID = AssetsP.item_ID and [Register_Of_Fixed_Assets].[dbo].[Detail_Master].[Status]=1 group by [AssetsP].Item_Name,[AssetsP].Item_Id";
            var recordCount = db.Database.SqlQuery<Report>(query).ToList();
            foreach (var item in recordCount)
            {
                dropdownitems.Add(new SelectListItem { Text = item.Item_Name, Value = item.Item_Id.ToString() });
              
            }
            ViewBag.assets = dropdownitems;
            return View();
        }

        [HttpPost]

        public ActionResult Index(int item_ID)
        {
            var query = db.Detail_Master.Where(x => x.item_ID == item_ID && x.Status==1).ToList();
            return PartialView("Itemlist",query);
        }

     }
}