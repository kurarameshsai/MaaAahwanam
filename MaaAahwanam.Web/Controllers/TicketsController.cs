using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using MaaAahwanam.Dal;
using System.IO;

namespace MaaAahwanam.Web.Controllers
{
    public class TicketsController : Controller
    {
        // GET: /Tickets/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            return View();
        }
	}
}