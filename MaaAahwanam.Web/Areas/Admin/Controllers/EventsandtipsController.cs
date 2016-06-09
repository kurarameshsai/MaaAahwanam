using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;


namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class EventsandtipsController : Controller
    {
        //
        // GET: /Admin/Eventsandtips/
        [HttpGet]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(HttpContext.Request.Params.Get("id"));
            Eventsandtips model = new Eventsandtips();
            EventsandtipsBAL eventsandtipsbal = new EventsandtipsBAL();
            string page = HttpContext.Request.Params.Get("page");
            if (page == "events")
            {
                ViewBag.Pagetitle = "Upcoming Events";
            }
            else if (page == "Beauty")
            {
                ViewBag.Pagetitle = "Beauty Tips";
            }
            else if (page == "Health")
            {
                ViewBag.Pagetitle = "Health Tips";
            }
            model.parameter = page;
            model.Eventsandtipslist = eventsandtipsbal.geteventsandtips(page).ToList();
            var itemslist = eventsandtipsbal.geteventsandtipsitem(id).SingleOrDefault();
            if (id != 0)
            {
                model.eventid = itemslist.EventID;
                model.Title = itemslist.Title;
                model.Description = itemslist.Description;
                model.Location = itemslist.location;
                model.phone = itemslist.phone;
                model.Person = itemslist.person;
                model.Price = itemslist.price ?? 0.00m;
                model.Image = itemslist.image;
                model.Eventstartdate = itemslist.Eventstartdate;
                model.Eventenddate = itemslist.Eventstartdate;
                model.Link = itemslist.link;
                model.parameter = itemslist.Type;
            }
            return View(model);
        }

        //
        // Post: /Admin/Eventsandtips/
        [HttpPost]
        public ActionResult Index(Eventsandtips model, HttpPostedFileBase file)
        {
            UploadFile uploadfile = new UploadFile();
            EventsandtipsBAL _Eventsandtipsbal = new EventsandtipsBAL();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (file != null)
            {
                string filedetails = uploadfile.Uploadfiles(file, controllerName);
                string[] words = filedetails.Split('|');
                model.Image = words[0];
                model.Image = words[1];
            }
            model.Type = model.parameter;
            _Eventsandtipsbal.saveeventsandtips(model);
            string t = string.Empty;
            if (model.Type == "events")
            {
                t = "Upcoming event added";
            }
            else if (model.Type == "Beauty")
            {
                t = "Beauty Tip added";
            }
            else if (model.Type == "Health")
            {
                t = "Health Tip added";
            }
            string str = "<script language='javascript' type='text/javascript'>alert('" + t + " Successfully');location.href='/Admin/Eventsandtips/?page=" + model.Type + "'</script>";
            return Content(str);
        }
    }
}