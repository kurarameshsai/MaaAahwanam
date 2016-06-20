using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Utility;
using MaaAahwanam.Models;
using MaaAahwanam.Service;

namespace MaaAahwanam.Web.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            AllVendorsService allVendorsService = new AllVendorsService();
            ViewBag.PhotographersDetails = allVendorsService.VendorsPhotographyList();
            ViewBag.Beautician = allVendorsService.VendorsBeautyList();
            ViewBag.Decorators = allVendorsService.VendorsDecoratorList();
            ViewBag.ToursandTravels = allVendorsService.VendorsTravelandAccomodationList();
            EventsService eventsService=new EventsService();
            @ViewBag.EventsCount = eventsService.EventInformationCount();
            ticketsService ticketsService = new ticketsService();
            @ViewBag.Ticketscount = ticketsService.TicketsCount();
            TestmonialService testmonialService=new TestmonialService();
            @ViewBag.Testimonials = testmonialService.TestmonialServiceList();
            return View();
        }


        [ChildActionOnly]
        public PartialViewResult ItemsCartViewBindingLayout()
        {
            CartService cartService = new CartService();
            ViewBag.cartCount = cartService.CartItemsCount(ValidUserUtility.ValidUser());
            return PartialView("ItemsCartViewBindingLayout");
        }

        [ChildActionOnly]
        public PartialViewResult TestimonialsBindingLayout(string view)
        {
            return PartialView("TestimonialsBindingLayout");
        }

        [HttpPost]
        public JsonResult SubmittingSubscriber(Subscription Subscription)
        {
            string message = string.Empty;
            try
            {
                SubscriptionService subscriptionService = new SubscriptionService();
                subscriptionService.addsubscription(Subscription);
                message = "subscribed successfully";
            }
            catch
            {
                message = "subscription failed";
            }
            return Json(String.Format(message));
        }

        public JsonResult AutoCompleteCountry()
        {
            AllVendorsService allVendorsService=new AllVendorsService();
            var Listoflocations = allVendorsService.VendorsList();
            string[] ListofEvents = {"Photographer", "Travels" };
            return Json(new { Listoflocations, ListofEvents }, JsonRequestBehavior.AllowGet);
        }
    }
}