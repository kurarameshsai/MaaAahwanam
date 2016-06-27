using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using MaaAahwanam.Service;

namespace MaaAahwanam.Web.Controllers
{
    public class MyProfileController : Controller
    {
        //
        // GET: /MyProfile/
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                ViewBag.Type = ValidUserUtility.UserType();
                UserLoginDetailsService userLoginDetailsService = new UserLoginDetailsService();
                UserDetail userDetail = userLoginDetailsService.GetUser(ValidUserUtility.ValidUser());
                return View(userDetail);
            }
            return View();
        }
	}
}