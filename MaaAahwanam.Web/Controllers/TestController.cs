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
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            DealsBAL dealbal = new DealsBAL();

            // TopDeals List
            var ListofDeals_All = dealbal.DealsBindingLayoutList("0");
            var Photographer = ListofDeals_All.Where(p => p.ServiceType == "Photographers").ToList();
            ViewBag.PhotographersDetails = Photographer;
            var ToursTravels = ListofDeals_All.Where(p => p.ServiceType == "Tours & Travels").ToList();
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

            //Testimonials List
            TestmonialsBAL testmonialbal = new TestmonialsBAL();
            var Testimonials = testmonialbal.TestmonialsViewList(1).ToList();
            ViewBag.Testimonials = Testimonials;            
            return View();
        }
    }
}