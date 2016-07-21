﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Service;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class VendorsController : Controller
    {
        VendorSetupService vendorSetupService = new VendorSetupService();
        public ActionResult AllVendors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AllVendors(string dropstatus,string command,string id)
        {
            if (dropstatus != null)
            {
                ViewBag.VendorList = vendorSetupService.AllVendorList(dropstatus);
            }
            if (command == "Edit")
            {
                return RedirectToAction(dropstatus, "CreateVendor", id);
            }
            return View();
        }
        public ActionResult ActiveVendors()
        {
            return View();
        }
        public ActionResult PendingVendors()
        {
            return View();
        }
        public ActionResult SuspendedVendors()
        {
            return View();
        }
        public ActionResult VendorDetails()
        {
            return View();
        }
	}
}