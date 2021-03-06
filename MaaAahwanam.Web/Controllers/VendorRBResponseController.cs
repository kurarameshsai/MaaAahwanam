﻿using MaaAahwanam.Models;
using MaaAahwanam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Controllers
{
    public class VendorRBResponseController : Controller
    {
        ServiceResponseService serviceResponseService = new ServiceResponseService();
        // GET: VendorReverseBiddingResponseController
        public ActionResult Index()
        {
            string Rid = Request.QueryString["Rid"];
            ViewBag.rid = Rid;
            return View();
        }
        [HttpPost]
        public ActionResult Index(ServiceResponse serviceResponse)
        {
            string message = serviceResponseService.SaveServiceResponse(serviceResponse);
            if (message == "Success")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Submitted Response');location.href='" + @Url.Action("Index", "VendorRBResponse", new { Rid = serviceResponse.RequestId }) + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Failed to submit please try again');location.href='" + @Url.Action("Index", "VendorRBResponse", new { Rid = serviceResponse.RequestId }) + "'</script>");
            }
        }
    }
}