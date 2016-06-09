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

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class BuyNowAdminController : Controller
    {
        LogsUtility logs = new LogsUtility();
        // GET: /Admin/BuyNowAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuyNowDet()
        {
            return View();
        }
	}
}