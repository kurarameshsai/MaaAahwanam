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
    public class EditProfileController : Controller
    {
        UserLoginDetailsService userLoginDetailsService = new UserLoginDetailsService();
        //
        // GET: /EditProfile/
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                UserDetail userDetail = userLoginDetailsService.GetUser(ValidUserUtility.ValidUser());
                ViewBag.Type = ValidUserUtility.UserType();
                return View(userDetail);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetail userDetail)
        {
            userLoginDetailsService.UpdateUserdetails(userDetail, ValidUserUtility.ValidUser());
            return View();
        }
	}
}