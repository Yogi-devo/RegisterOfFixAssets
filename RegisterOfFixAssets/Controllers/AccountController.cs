using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterOfFixAssets.Models;
using System.Web.Security;

namespace RegisterOfFixAssets.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignIn()
        {
           

            return View();

        }
        [HttpPost]
        public ActionResult SignIn(Login login)
        {
            using (var context = new EntityConfig())
            {
                bool IsValied = context.Logins.Any(x => x.LoginId ==login.LoginId && x.Password==login.Password);
                if(IsValied)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError("", "Invalied user and/or password");
                return View();
            }
            
        }
    }
}