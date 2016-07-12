using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Service;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class ServicesController : Controller
    {
        ServiceRequestService serviceRequestService = new ServiceRequestService();
        public ActionResult BidRequests(ServiceRequest serviceRequest, string BidReqId,string name)
        {
            serviceRequest.Type = "Bidding";
            ViewBag.records = serviceRequestService.GetServiceRequestList(serviceRequest);
            if (name == "View")
            {
                serviceRequest.RequestId = BidReqId;
                TempData["Records"] = serviceRequestService.GetServiceRequestRecord(serviceRequest);
                return RedirectToAction("BidReqView");
            }
            if (name == "Delete")
            {

            }
            return View();
        }
        public ActionResult QuotRequests()
        {
            return View();
        }
        public ActionResult RevBidRequests()
        {
            return View();
        }
        public ActionResult BidReqView()
        {
            if (TempData["Records"]!=null)
            {
                ViewBag.vendordetails = TempData["Records"];
                return View();
            }
            return View();
        }
        public ActionResult QuotReqView()
        {
            return View();
        }
        public ActionResult RevBidReqView()
        {
            return View();
        }
        public ActionResult Biddings()
        {
            return View();
        }
        public ActionResult Quotations()
        {
            return View();
        }
        public ActionResult ReverseBiddings()
        {
            return View();
        }
	}
}