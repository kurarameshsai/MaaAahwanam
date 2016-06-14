using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using Newtonsoft.Json.Linq;

namespace MaaAahwanam.Web.Controllers
{
    public class SigninController : Controller
    {
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                TempData["Alert"] = TempData["AlertContent"];
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(string command)
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Signin");
        }

        [ChildActionOnly]
        public PartialViewResult SigninPartial()
        {
            return PartialView("SigninPartial");
        }
        public JsonResult RegularExpressionPattern_Password()
        {
            return Json(ValidationsUtility.PatternforPassword(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string sample)
        {
            return View();
        }
    }
}