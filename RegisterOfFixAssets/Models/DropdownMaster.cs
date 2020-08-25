using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterOfFixAssets.Models
{
    public class DropdownMaster
    {
        public DropdownMaster()
        {
            this.Asset = new List<SelectListItem>();
            this.CategoryCollection = new List<SelectListItem>();
            this.SupplerCollection= new List<SelectListItem>();
            this.UserCollection = new List<SelectListItem>();
        }

        public List<SelectListItem> Asset { get; set; }
        public List<SelectListItem> CategoryCollection { get; set; }
        public List<SelectListItem> SupplerCollection { get; set; }
        public List<SelectListItem> UserCollection { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        public int AssetId { get; set; }
        [Required(ErrorMessage ="Please Select Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Bill No.")]
        [Required(ErrorMessage ="Kindly Fill")]
        public string Bill_No { get; set; }
        [Display(Name = "Bill Date")]
        public Nullable<System.DateTime> Bill_Date { get; set; }
        public string Cost { get; set; }
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }
        [Display(Name ="User Name")]
        public string User_Name { get; set; }
        [Display(Name = "Item Name")]
        public string Item_Name { get; set; }
        [Display(Name = "Model & Sl. No.")]

        [Required]
        public string Model_SlNo { get; set; }

        [Display(Name = "File No.")]
        public string File_No { get; set; }
        public string Category { get; set; }
        public Nullable<int> Status { get; set; } = 1;
        public string Remarks { get; set; }
        
        [Display(Name = "Supplier Id")]
        public int Supplier_Id { get; set; }
        [NotMapped]
        [Required]
        public int Itemcount { get; set; } = 1;
       
     

    }
}