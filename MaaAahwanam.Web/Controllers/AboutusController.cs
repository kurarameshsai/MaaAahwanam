using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;

namespace MaaAahwanam.Web.Controllers
{
    public class AboutusController : Controller
    {
        //
        // GET: /Aboutus/
        public ActionResult Index()
        {
            //For Count number of clients and successfull events
            SmartCount smartcount = new SmartCount();
            EventsandtipsBAL eventsandtips = new EventsandtipsBAL();
            smartcount = eventsandtips.CountDetails();
            ViewBag.Ticketscount = smartcount.ticketscount;
            ViewBag.EventsCount = smartcount.eventscount;
            return View();
        }
    }
}