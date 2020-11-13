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
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class DetailMasterController : Controller
    {
        private EntityConfig db = new EntityConfig();

        // GET: DetailMaster
        public ActionResult Index()
        {
            return View(db.Detail_Master.Where(x=>x.Status==1).Include("AssetsP").Include("SuppllierP").OrderBy(x =>x.D_ID).ToList());
        }

        // GET: DetailMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Master detail_Master = db.Detail_Master.Find(id);
            if (detail_Master == null)
            {
                return HttpNotFound();
            }
            return View(detail_Master);
        }

        
        public ActionResult Create()
        {


                DropdownMaster dm = new DropdownMaster();
                foreach (var item in db.UserMasters)
                {
                    dm.UserCollection.Add(new SelectListItem { Text = item.UserName + '(' + item.RoomNo + ')', Value = item.UserName + '|' + item.RoomNo });
                }
                foreach (var item in db.CategoryMasters)
                {
                    dm.CategoryCollection.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
                }
                foreach (var sList in db.SuppllierPs)
                {
                    dm.SupplerCollection.Add(new SelectListItem { Text = sList.Supplier_Name, Value = sList.Supplier_ID.ToString() });
                }
                return View(dm);
           
        }

      
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? CategoryId, int? AssetId,DropdownMaster doc)
        {
            DropdownMaster dm = new DropdownMaster();
           

                List<SuppllierP> Suppliers = db.SuppllierPs.Where(x => x.status == 1).ToList();
                foreach (var item in db.UserMasters)
                {
                    dm.UserCollection.Add(new SelectListItem { Text = item.UserName + '(' + item.RoomNo + ')', Value = item.UserName + '|' + item.RoomNo });
                }
                foreach (var sList in Suppliers)
                {
                    dm.SupplerCollection.Add(new SelectListItem { Text = sList.Supplier_Name, Value = sList.Supplier_ID.ToString() });
                }
                foreach (var item in db.CategoryMasters)
                {
                    dm.CategoryCollection.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
                }

                if (CategoryId.HasValue)
                {
                    var items = (from itemlist in db.AssetsPs
                                 where itemlist.category == CategoryId.Value
                                 select itemlist).Where(x => x.status == 1).ToList();
                    foreach (var itemcollection in items)
                    {
                        dm.Asset.Add(new SelectListItem { Text = itemcollection.item_name, Value = itemcollection.item_ID.ToString() });
                    }

                }

                return View(dm);
            
        }

        [HttpPost]
        public ActionResult SaveCreate(DropdownMaster dm)
        {
           
                Detail_Master doc = new Detail_Master();
                string str = dm.User_Name.ToString();
                string[] str1 = str.Split('|');
                doc.Category = dm.CategoryId.ToString();
                Random rand = new Random();
                for (int i = 1; i <= dm.Itemcount; i++)
                {


                    doc.Item_Name = dm.AssetId.ToString() + rand.Next();
                    doc.item_ID = dm.AssetId;

                    doc.Bill_Date = dm.Bill_Date;
                    doc.Bill_No = dm.Bill_No;
                    doc.File_No = dm.File_No;
                    doc.Cost = dm.Cost;
                    doc.Model_SlNo = dm.Model_SlNo;
                    doc.RoomNo = str1[1].ToString();
                    doc.User_Name = str1[0].ToString();
                    doc.Remarks = dm.Remarks;
                    doc.Status = dm.Status;
                    doc.Supplier_ID = dm.Supplier_Id;
                    doc.CreatedOn = DateTime.Now;

                    db.Detail_Master.Add(doc);

                    db.SaveChanges();
                }
                ViewBag.Message = "New record inserted successfully";
                return RedirectToAction("Create", "DetailMaster");
         
        }



        private void AddRows(DropdownMaster doc)
        {
            List<int> rowcount = new List<int>();
            int rows = 0;
            int.TryParse(doc.Itemcount.ToString(), out rows);
            for(int i = 0; i < rows; i++)
            {
                rowcount.Add(i);
            }
        }
       

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Master detail_Master = db.Detail_Master.Find(id);
            var selected = detail_Master.User_Name + '|' + detail_Master.RoomNo ;
            //string[] selectedsplit = selected.Split('|');
            List<SelectListItem> UserCollection = new List<SelectListItem>();
            UserMaster user = new UserMaster();
            foreach (var item in db.UserMasters)
            {
                UserCollection.Add(new SelectListItem { Text = item.UserName + '(' + item.RoomNo + ')', Value = item.UserName + '|' + item.RoomNo});
            }
            List<SelectListItem> SupplerCollection = new List<SelectListItem>();
            foreach (var sList in db.SuppllierPs)
            {
               SupplerCollection.Add(new SelectListItem { Text = sList.Supplier_Name, Value = sList.Supplier_ID.ToString() });
            }
            ViewBag.users = UserCollection;
            ViewBag.suppliers = SupplerCollection;
            if (detail_Master == null)
            {
                return HttpNotFound();
            }
            return View(detail_Master);

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Detail_Master detail_Master)
        {
            string str = detail_Master.CombinedValue.ToString();
            string[] str1 = str.Split('|');
            if (ModelState.IsValid)
            {
                detail_Master.RoomNo = str1[1].ToString();
                detail_Master.User_Name = str1[0].ToString();
                db.Entry(detail_Master).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detail_Master);
        }

        // GET: DetailMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Master detail_Master = db.Detail_Master.Find(id);
            if (detail_Master == null)
            {
                return HttpNotFound();
            }
            return View(detail_Master);
        }

        // POST: DetailMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail_Master detail_Master = db.Detail_Master.Find(id);
            db.Detail_Master.Remove(detail_Master);
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
