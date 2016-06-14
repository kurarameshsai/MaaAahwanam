using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string command)
        {
            return View();
        }
        public JsonResult RegularExpressionPattern_Password()
        {
            return Json(ValidationsUtility.PatternforPassword(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult SignOut()
        {
            //logs.LogTimings("Out");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}