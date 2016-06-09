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
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class ServiceRequestController : Controller
    {
        LogsUtility logs = new LogsUtility();
        //
        // GET: /ServiceRequest/
        public ActionResult requests()
        {
            try
            {
                
                string page = HttpContext.Request.Params.Get("page");
                ServiceRequest servicerequest = new ServiceRequest();
                ServiceRequestBAL ServiceRequestBAL = new ServiceRequestBAL();
                List<ServiceRequest> servicerequestlist = new List<ServiceRequest>();
                var sp_returned_invitationlist = ServiceRequestBAL.ServiceRequest(page,null);
                servicerequest.eventmasterlist = sp_returned_invitationlist;
                logs.LogEvents("Viewing InvitationRequestlist ", "ServiceRequest/Bidddingrequest");
                ViewBag.Pagetitle = page;
                return View(servicerequest);
            }
            catch (Exception ex)
            {
                logs.LogTheExceptions(ex, "ServiceRequest/Bidddingrequest");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard") + "'</script>");
            }
        }
        public ActionResult Requestdetails()
        {
            string page = HttpContext.Request.Params.Get("page");
            int Eventid = Convert.ToInt32(HttpContext.Request.Params.Get("id"));
            ServiceRequestBAL ServiceRequestBAL = new ServiceRequestBAL();
            var sp_returned_invitationlistitem = ServiceRequestBAL.ServiceRequest(page, Eventid);
            ServiceRequest servicerequest = new ServiceRequest();
            servicerequest.SP_ADMIN_Servicerequest_list = sp_returned_invitationlistitem;
            ViewBag.Pagetitle = page;
            return View(servicerequest);
        }
    }
}