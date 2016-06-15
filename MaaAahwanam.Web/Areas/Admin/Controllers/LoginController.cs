using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using MaaAahwanam.Service;
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
        public ActionResult Index([Bind(Prefix = "Item1")] UserLogin userLogin,[Bind(Prefix = "Item2")] UserDetail userDetails, string command)
        {
            if (command == "Register")
            {
                UserLoginDetailsService userLoginDetailsService = new UserLoginDetailsService();
                var response = userLoginDetailsService.AddUserDetails(userLogin, userDetails);
            }
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