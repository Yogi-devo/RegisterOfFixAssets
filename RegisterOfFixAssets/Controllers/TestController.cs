using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterOfFixAssets.Models;

namespace RegisterOfFixAssets.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(dynamicrow item)
        {
            List<dynamicrow> ilist = new List<dynamicrow>();
           
            using(Test db=new Test())
            {
                for (int i = 0; i < item.count; i++)
                {
                    item.tablevalue = "table" + i;
                    db.dynamicrows.Add(item);
                    db.SaveChanges();
                }

            }   
            return View();
        }
    }
}