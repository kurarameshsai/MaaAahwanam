using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;

namespace MaaAahwanam.Web.Controllers
{
    public class ReverseBiddingConfirmationController : Controller
    {
        //
        // GET: /ReverseBiddingConfirmation/
        public ActionResult Index(ServiceRequest serviceRequest)
        {
            return View(serviceRequest);
        }
	}
}