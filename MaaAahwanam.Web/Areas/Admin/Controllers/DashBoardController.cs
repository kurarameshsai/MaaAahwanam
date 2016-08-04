//using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
//using MaaAahwanam.Repository;
using System.Text;
using System.IO;
using MaaAahwanam.Service;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        DashboardService dashboardService = new DashboardService();
        OrderService orderService = new OrderService();
        OthersService othersService = new OthersService();
        public ActionResult dashboard()
        {
            ViewBag.vendorcount = dashboardService.VendorsCountService();
            ViewBag.commentscount = dashboardService.CommentsCountService();
            ViewBag.ticketcount = dashboardService.TicketsCountService();
            ViewBag.orderscount = dashboardService.OrdersCountService();
            ViewBag.orders = orderService.OrderList().OrderByDescending(m=>m.OrderDate).Take(10);
            ViewBag.users = othersService.AllRegisteredUsersDetails().OrderByDescending(m=>m.RegDate).Take(4);
            //ViewBag.admin = othersService.RegisteredUsersList()
            return View();
        }
    }
}