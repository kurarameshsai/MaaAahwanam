using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class OrderRequestsController : Controller
    {
        //
        // GET: /Admin/OrderRequests/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Allorders()
        {
            return View();
        }


        
        public ActionResult Invitationorders()
        {
            return View();
        }
        public ActionResult Quotationorders()
        {
            return View();
        }
        public ActionResult Biddingorders()
        {
            return View();
        }
        public ActionResult Returngiftorders()
        {
            return View();
        }
        public ActionResult Booknoworders()
        {
            return View();
        }
	}
}