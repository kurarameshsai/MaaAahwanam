using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class OthersController : Controller
    {
        //
        // GET: /Admin/Others/
        public ActionResult Tickets()
        {
            return View();
        }
        public ActionResult Comments()
        {
            return View();
        }
        public ActionResult Testimonials()
        {
            return View();
        }
        public ActionResult TicketDetails()
        {
            return View();
        }
        public ActionResult TestimonialDetails()
        {
            return View();
        }
        public ActionResult CommentDetails()
        {
            return View();
        }
        public ActionResult RegisteredUsers()
        {
            return View();
        }
        public ActionResult RegUserDetails()
        {
            return View();
        }
	}
}