using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /Admin/Services/
        public ActionResult BidRequests()
        {
            return View();
        }
        public ActionResult QuotRequests()
        {
            return View();
        }
        public ActionResult RevBidRequests()
        {
            return View();
        }
        public ActionResult BidReqView()
        {
            return View();
        }
        public ActionResult QuotReqView()
        {
            return View();
        }
        public ActionResult RevBidReqView()
        {
            return View();
        }
        public ActionResult Biddings()
        {
            return View();
        }
        public ActionResult Quotations()
        {
            return View();
        }
        public ActionResult ReverseBiddings()
        {
            return View();
        }
	}
}