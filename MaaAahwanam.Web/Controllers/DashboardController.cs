using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;


namespace MaaAahwanam.Web.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {            
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {

                ViewBag.Type = ValidUserUtility.UserType();
                OrdersListBAL orderlistbal = new OrdersListBAL();
                EventDetailsBAL eventdetailsbal = new EventDetailsBAL();
                List<SP_ADMIN_ORDERS_Result> SP_ADMIN_ORDERS = orderlistbal.OrdersListAsPerUser();
                List<SP_EVENTDETAILSANDEVENTDATES_Result> SP_EVENTDETAILSANDEVENTDATES = eventdetailsbal.EventsListAsPerEventID(0);
                List<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result> SP_COUNTSOFNOTIFICATIONSANDEVENTS = eventdetailsbal.CountsOfEventsAndNotifications();
                var tupleModel = new Tuple<List<SP_ADMIN_ORDERS_Result>, List<SP_EVENTDETAILSANDEVENTDATES_Result>, List<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result>>(SP_ADMIN_ORDERS, SP_EVENTDETAILSANDEVENTDATES, SP_COUNTSOFNOTIFICATIONSANDEVENTS);
                return View(tupleModel);
            }
            else
            {
                return View();
            }
        }
    }
}