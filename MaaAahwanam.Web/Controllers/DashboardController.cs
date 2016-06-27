﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MaaAahwanam.Repository;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;


namespace MaaAahwanam.Web.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {

                ViewBag.Type = ValidUserUtility.UserType();

            }
            return View();

        }
    }
}