using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Admin/Reports/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Useractionsreport()
        {
            var list = new SelectList(new[] 
            {
                new { ID = "1", Name = "Sai Krishna" },
                new { ID = "2", Name = "Reddy" },
                new { ID = "3", Name = "Krishna" },
            },
            "ID", "Name", 1);
            
            ViewData["list"] = list;



            var list2 = new SelectList(new[] 
            {
                new { ID = "1", Name = "Admin" },
                new { ID = "2", Name = "User" },
                new { ID = "3", Name = "Vendor" },
            },"ID", "Name", 1);

            ViewData["list2"] = list2;

            return View();
        }

        public ActionResult Orders()
        {
            var list2 = new SelectList(new[] 
            {
                new { ID = "1", Name = "101" },
                new { ID = "2", Name = "102" },
                new { ID = "3", Name = "103" },
            },
            "ID", "Name", 1);

            ViewData["list2"] = list2;



            var list = new SelectList(new[] 
            {
                new { ID = "1", Name = "Invitation" },
                new { ID = "2", Name = "Photography" },
                new { ID = "3", Name = "Lighting" },
            }, "ID", "Name", 1);

            ViewData["list"] = list;

            var list3 = new SelectList(new[] 
            {
                new { ID = "1", Name = "Sai Krishna" },
                new { ID = "2", Name = "Reddy" },
                new { ID = "3", Name = "Krishna" },
            },
            "ID", "Name", 1);

            ViewData["list3"] = list3;

            var list4 = new SelectList(new[] 
            {
                new { ID = "1", Name = "In Cart" },
                new { ID = "2", Name = "Advance Paid" },
                new { ID = "3", Name = "Total Paid" },
            },
            "ID", "Name", 1);

            ViewData["list4"] = list4;
            return View();
        }

        public ActionResult Nextevents()
        {
            
            return View();
        }
    }
}