using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using MaaAahwanam.Dal;
using System.IO;

namespace MaaAahwanam.Web.Controllers
{
    public class FaqController : Controller
    {
        //
        // GET: /Faq/
        public ActionResult Index(SiteFaq sitefaq)
        {
            SiteFaqBal sitefaqbal = new SiteFaqBal();
            sitefaq.FaqsList = sitefaqbal.FaqsList();
            return View(sitefaq);
        }   
	}
}