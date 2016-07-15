using System;
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
    public class OthersController : Controller
    {
        OthersService othersService = new OthersService();
        //
        // GET: /Admin/Others/
        public ActionResult Tickets()
        {
            return View();
        }
        public ActionResult Comments()
        {
            ViewBag.CommentList = othersService.CommentList();
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
        public ActionResult CommentDetails(long id, CommentDetail commentDetail,string Command)
        {
            if (id!=null)
            {
               ViewBag.record = othersService.CommentRecordService(id);
               return View();
            }
            if (Command == "Submit")
            {
                commentDetail.CommentId = id;
                //othersService.AddComment(commentDetail);
            }
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