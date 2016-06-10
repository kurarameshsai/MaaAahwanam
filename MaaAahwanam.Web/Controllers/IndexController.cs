using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Utility;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            TempData["Alert"] = TempData["AlertContent"];
            DealsBAL dealbal = new DealsBAL();

            // TopDeals List
            var ListofDeals_All = dealbal.DealsBindingLayoutList("0");
            var Photographer = ListofDeals_All.Where(p => p.ServiceType == "Photographers").ToList();
            ViewBag.PhotographersDetails = Photographer;
            var ToursTravels = ListofDeals_All.Where(p => p.ServiceType == "Tours and travels").ToList();
            ViewBag.ToursandTravels = ToursTravels;
            var Decorators = ListofDeals_All.Where(p => p.ServiceType == "Decorators").ToList();
            ViewBag.Decorators = Decorators;
            var Beauticians = ListofDeals_All.Where(p => p.ServiceType == "Beautician").ToList();
            ViewBag.Beautician = Beauticians;

            //For Count number of clients and successfull events
            SmartCount smartcount = new SmartCount();
            EventsandtipsBAL eventsandtips = new EventsandtipsBAL();
            smartcount = eventsandtips.CountDetails();
            ViewBag.Ticketscount = smartcount.ticketscount;
            ViewBag.EventsCount = smartcount.eventscount;

            //For UpcomingEvents,HealthTips and BeautyTips
            var EventsandTipsList = eventsandtips.EventsAndTipsBindingList();
            var UpcomingEvents = EventsandTipsList.Where(p => p.Type == "events").OrderByDescending(p => p.Eventstartdate).ToList().Take(10);
            ViewBag.UpcomingEvents = UpcomingEvents;
            var HealthTips = EventsandTipsList.Where(p => p.Type == "Health").OrderByDescending(p => p.Eventstartdate).ToList().Take(10);
            ViewBag.HealthTips = HealthTips;
            var BeautyTips = EventsandTipsList.Where(p => p.Type == "Beauty").OrderByDescending(p => p.Eventstartdate).ToList().Take(10);
            ViewBag.BeautyTips = BeautyTips;

            //Testimonials List--santosh
            TestmonialsBAL testmonialbal = new TestmonialsBAL();
            var Testimonials = testmonialbal.TestmonialsViewList(1).ToList();
            ViewBag.Testimonials = Testimonials;
            return View();
        }
        public JsonResult AutoCompleteCountry()
        {
            VendorDetailsBal vendorbal = new VendorDetailsBal();
            var Listoflocations = vendorbal.Locationsearch();
            var ListofEvents = vendorbal.GetServiceList();
            return Json(new { Listoflocations, ListofEvents }, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public PartialViewResult ItemsCartViewBindingLayout()
        {
            UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
            CartViewBal cartviewbal = new CartViewBal();
            CartViewItemDetails cartviewitemdetails = new CartViewItemDetails();
            if (ValidUserUtility.ValidUser() != 0 && ValidUserUtility.UserType() == "User")
            {
                var userlist = userlogindetailsbal.UserProfile(ValidUserUtility.ValidUser()).FirstOrDefault();
                var model = cartviewbal.CartItemsViewList(userlist.UserLoginId).ToList();
                cartviewitemdetails.cartlist = model.ToList();
                cartviewitemdetails.cartlistcount = model.ToList().Count();
                cartviewitemdetails.TotalPrice = cartviewbal.CartItemsViewListtotalPrice(userlist.UserLoginId);
            }
            return PartialView("ItemsCartViewBindingLayout", cartviewitemdetails);
        }

        [ChildActionOnly]
        public PartialViewResult TestimonialsBindingLayout(string view)
        {
            int Ntype = Convert.ToInt32(view.ToString());
            TestmonialsBAL testmonialbal = new TestmonialsBAL();
            TestimonialDetails testmonialdetails = new TestimonialDetails();
            testmonialdetails.testmonialslist = testmonialbal.TestmonialsViewList(Ntype);
            testmonialdetails.ntype = Ntype;
            return PartialView("TestimonialsBindingLayout", testmonialdetails);
        }

        [HttpPost]
        public JsonResult SubmittingSubscriber(Subscription Subscriptionmodel)
        {
            string message = string.Empty;
            try
            {
                SubscribeBal subscriptionbal = new SubscribeBal();
                Subscription subscription = new Subscription();
                subscription.EmailId = Subscriptionmodel.EmailId;
                subscription.Status = Subscriptionmodel.Status;
                subscriptionbal.SavingSubscriptionEmailId(subscription);
                //logs.LogEvents("Address Saved Successfully", "AddressBook/Index");     
                message = "success";
            }
            catch
            {
                message = "failed";
            }
            return Json(String.Format(message));
        }
    }
}