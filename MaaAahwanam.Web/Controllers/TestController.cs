using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Utility;
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
            return View();
        }
    }
}