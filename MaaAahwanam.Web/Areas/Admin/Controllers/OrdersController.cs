using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Admin/Orders/
        public ActionResult AllOrders()
        {
            return View();
        }
        public ActionResult OrderDetails()
        {
            return View();
        }
	}
}