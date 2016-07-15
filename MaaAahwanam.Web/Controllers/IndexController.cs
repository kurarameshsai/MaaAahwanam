using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Utility;
using MaaAahwanam.Models;
using MaaAahwanam.Service;
using MaaAahwanam.Repository;

namespace MaaAahwanam.Web.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            EventsService eventsService=new EventsService();
            ViewBag.EventsCount = eventsService.EventInformationCount();//Successful Events Count
            ticketsService ticketsService = new ticketsService();
            ViewBag.Ticketscount = ticketsService.TicketsCount();//Raised Tickets COunt
            TestmonialService testmonialService=new TestmonialService();
            ViewBag.Testimonials = testmonialService.TestmonialServiceList();//Testimonials List
            //Products List Index(4 Services Photography,Beautition,Decorators,Travels)
            ProductService productService = new ProductService();
            List<GetProducts_Result> Productlist_Photography = productService.GetProducts_Results("Photography");
            List<GetProducts_Result> Productlist_BeautyService = productService.GetProducts_Results("BeautyService");
            List<GetProducts_Result> Productlist_Decorator = productService.GetProducts_Results("Decorator");
            List<GetProducts_Result> Productlist_Travel = productService.GetProducts_Results("Travel");
            ViewBag.PhotographersDetails = Productlist_Photography;
            ViewBag.Beautician = Productlist_BeautyService;
            ViewBag.Decorators = Productlist_Decorator;
            ViewBag.ToursandTravels = Productlist_Travel;

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