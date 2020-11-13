using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterOfFixAssets.Models
{
    public class ChangePassword
    {
        [Required, DataType(DataType.Password)]
        [Display(Name ="Current Password")]
     public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        
        [Required, DataType(DataType.Password)]
        [Display(Name = "Confirm new Password")]
        [Compare(otherProperty: "NewPassword", ErrorMessage ="Password doesn't match")]
        public string ConfirmNewPassword { get; set; }

    }
}