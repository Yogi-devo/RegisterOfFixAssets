using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterOfFixAssets.Models;

namespace RegisterOfFixAssets.Controllers
{
  
    public class ReportController : Controller
    {
        private EntityConfig db = new EntityConfig();
      
        // GET: Report
        public ActionResult Index()
        {
            string query = "select count([AssetsP].Item_Name) as TotalCount,[AssetsP].Item_Name, [AssetsP].Item_Id FROM [Register_Of_Fixed_Assets].[dbo].[Detail_Master] inner join [Register_Of_Fixed_Assets].[dbo].[AssetsP] on Detail_Master.item_ID = AssetsP.item_ID and [Register_Of_Fixed_Assets].[dbo].[Detail_Master].[Status]=1 group by [AssetsP].Item_Name,[AssetsP].Item_Id";
            var recordCount = db.Database.SqlQuery<Report>(query).ToList();
            ViewBag.Record = recordCount;
            return View(); 
        }
        public ActionResult RecordDetail(int itemid)
        {
            var query = db.Detail_Master.Where(x=>x.item_ID==itemid && x.Status==1).ToList();
            return View(query);
        }
    }
}