using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using MaaAahwanam.Service;
using System.IO;

namespace MaaAahwanam.Web.Controllers
{
    public class TicketsController : Controller
    {
        ticketsService ticketsServices = new ticketsService();
        // GET: /Tickets/
        public ActionResult Index()
        {
            var a=ticketsServices.GetIssueTicket();
            ViewBag.Issueticketslist = a;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, IssueTicket issueTicket)
        {
            issueTicket.UpdatedBy = ValidUserUtility.ValidUser();
            string status=ticketsServices.Insertissueticket(issueTicket);
            if(status=="Success")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Ticket Raised');location.href='" + @Url.Action("Index", "Tickets") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Ticket Not Raised');location.href='" + @Url.Action("Index", "Tickets") + "'</script>");
            }
            return View();
        }
	}
}