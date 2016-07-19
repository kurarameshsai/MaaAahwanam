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
            ViewBag.Tickets = othersService.TicketList();
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
        public ActionResult TicketDetails(string id)
        {
            if (id!=null)
            {
                ViewBag.record = othersService.TicketRecordService(long.Parse(id));
            }
            return View();
        }
        public ActionResult TestimonialDetails()
        {
            return View();
        }
        public ActionResult CommentDetails(string id,string uid,string date, CommentDetail commentDetail,string Command)
        {
            if (id!=null)
            {
               ViewBag.record = othersService.CommentRecordService(long.Parse(id));
               ViewBag.comment = othersService.CommentDetail(long.Parse(uid));
               //return View();
            }
            if (Command == "Submit")
            {
                commentDetail.CommentId = long.Parse(id);
                commentDetail.UserLoginId = int.Parse(uid);
                commentDetail.CommentDate = Convert.ToDateTime(date);
                commentDetail.UpdatedBy = ValidUserUtility.ValidUser();
                othersService.AddComment(commentDetail);
                if (commentDetail.CommentDetId != 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Replied Successfully');location.href='" + @Url.Action("comments", "others") + "'</script>");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Failed');location.href='" + @Url.Action("comments", "others") + "'</script>");
                }
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