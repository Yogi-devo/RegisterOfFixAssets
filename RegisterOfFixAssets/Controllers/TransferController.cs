using RegisterOfFixAssets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterOfFixAssets.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class TransferController : Controller
    {
        // GET: Transfer
        EntityConfig db = new EntityConfig(); // connection

        public ActionResult Index(int id)
        {
            Detail_Master ds = new Detail_Master();
            ds = db.Detail_Master.Find(id);
            ViewBag.itemname = db.Detail_Master.Include("AssetsP").Where(x=>x.D_ID==id).FirstOrDefault();
            List<SelectListItem> UserCollection = new List<SelectListItem>();
            foreach (var item in db.UserMasters)
            {
                UserCollection.Add(new SelectListItem { Text = item.UserName + '(' + item.RoomNo + ')', Value = item.UserName + '|' + item.RoomNo });
            }
            ViewBag.users = UserCollection;
            return View(ds);
        }

        [HttpPost]
        public ActionResult Index(Detail_Master doc)
        {
            DropdownMaster dm = new DropdownMaster();
            AssetTransaction asp = new AssetTransaction();
            string str = doc.User_Name.ToString();
            string[] str1 = str.Split('|');

            doc.User_Name = str1[0].ToString();
            doc.RoomNo = str1[1].ToString();
            doc.Flag = 1;   
            db.Entry(doc).State = System.Data.Entity.EntityState.Modified;
            asp.D_ID = doc.D_ID;
            asp.UserName = str1[0].ToString(); 
            asp.Item_Id = doc.item_ID;
            asp.Date_Modified = DateTime.Now;
            asp.Roomno = str1[1].ToString(); ;

            db.AssetTransactions.Add(asp);

            db.SaveChanges();

           
            return RedirectToAction("Index","Modifier");
        }

        public ActionResult DisposeAsset(int id)
        {
            Detail_Master ds = new Detail_Master();
            ds = db.Detail_Master.Find(id);
            return View(ds); 
        }

        [HttpPost]
        public ActionResult DisposeAsset(Detail_Master dtm)
        {
            db.Entry(dtm).State = System.Data.Entity.EntityState.Modified;
            dtm.Status = 0;
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index", "Modifier");

        }
        public ActionResult DisposedList()
        {
            Detail_Master ds = new Detail_Master();
            var query = db.Detail_Master.Where(x => x.Status == 0).ToList();


            return View(query);
        }
        public ActionResult ItemTransaction( int rowId)
        {
            var query = db.AssetTransactions.Where(x => x.D_ID == rowId).ToList();

            return View(query);
        }

    }
}