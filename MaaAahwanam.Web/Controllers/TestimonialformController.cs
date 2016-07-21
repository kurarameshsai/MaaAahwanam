using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Service;

namespace MaaAahwanam.Web.Controllers
{
    public class TestimonialformController : Controller
    {
        //
        // GET: /Testimonialform/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saveform(HttpPostedFileBase file, AdminTestimonial adminTestimonial)
        {
            AdminTestimonialPath adminTestimonialPath = new AdminTestimonialPath();
            TestmonialService testmonialService = new TestmonialService();
            testmonialService.Savetestimonial(adminTestimonial);
            adminTestimonialPath.Id = adminTestimonial.Id;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                adminTestimonialPath.ImagePath = Request.Files[i].FileName;
                testmonialService.Savetestimonialpath(adminTestimonialPath);
            }
            return RedirectToAction("Index");
        }
    }
}