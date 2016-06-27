﻿using System;
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
    public class ChangePasswordController : Controller
    {
        //
        // GET: /ChangePassword/
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                ViewBag.Type = ValidUserUtility.UserType();
            }   
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin userLogin)
        {
            UserLoginDetailsService userLoginDetailsService = new UserLoginDetailsService();
            userLoginDetailsService.changepassword(userLogin, ValidUserUtility.ValidUser());
            return View();
        }
	}
}