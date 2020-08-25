using RegisterOfFixAssets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterOfFixAssets.Controllers
{
    public class ValidationTestController : Controller
    {
        // GET: ValidationTest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ValidationTest vs)
        {
            if (ModelState.IsValid)
            {
                return View("Messsage");
            }
            return View();
        }

        public ActionResult Messsage()
        {
            return View();
                
        }
    }
}