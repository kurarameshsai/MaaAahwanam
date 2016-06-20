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
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Enquiry enquiry)
        {
            EnquiryService enquiryService = new EnquiryService();
            string respnonse = enquiryService.SaveEnquiries(enquiry);
            return View();
        }
    }
}