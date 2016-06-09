using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using MaaAahwanam.Dal;
using System.Net;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class TestimonialsController : Controller
    {
        LogsUtility logs = new LogsUtility();
        //
        // GET: /Admin/Testimonials/
        public ActionResult Index()
        {
            TestmonialsBAL testmonialbal = new TestmonialsBAL();
            TestimonialDetails testmonialdetails = new TestimonialDetails();
            testmonialdetails.testmonialslist = testmonialbal.TestmonialsViewList(2);
            return View(testmonialdetails);
        }
	}
}