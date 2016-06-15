using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Utility;
using MaaAahwanam.Models;
//using MaaAahwanam.Repository;

namespace MaaAahwanam.Web.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [ChildActionOnly]
        public PartialViewResult ItemsCartViewBindingLayout()
        {
            return PartialView("ItemsCartViewBindingLayout");
        }

        [ChildActionOnly]
        public PartialViewResult TestimonialsBindingLayout(string view)
        {
            return PartialView("TestimonialsBindingLayout");
        }

        [HttpPost]
        public JsonResult SubmittingSubscriber()
        {
            return Json(String.Format("ss"));
        }
    }
}