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
    public class TicketsController : Controller
    {
        LogsUtility logs = new LogsUtility();
        // GET: /Tickets/
        public ActionResult Index(IssueTicketDetails issueticketModel)
        {
            try
            {
                if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
                {
                    ViewBag.Type = ValidUserUtility.UserType();
                }   
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    issueticketModel.SP_TicketsUserList1 = issuebal.Userticketlist(uservalidity);
                    logs.LogEvents("Viewing TicketDetails", "Tickets/Index");
                    return View(issueticketModel);
                }
                else
                {
                    return RedirectToAction("Index", "Signin");
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Tickets/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
            }
        }
        [HttpPost]
        public ActionResult Index(IssueTicketDetails issueticketModel, string submit)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                IssueTicketDetails issuedetmodel = new IssueTicketDetails();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    issuedetmodel.UserLoginId = uservalidity;
                    issuedetmodel.Issue_Type = issueticketModel.Issue_Type;
                    issuedetmodel.Subject = issueticketModel.Subject;
                    issuedetmodel.Severity = issueticketModel.Severity;
                    issuedetmodel.Name = issueticketModel.Name;
                    issuedetmodel.Msg = issueticketModel.Msg;
                    issuebal.RegisterIssueDetails(issuedetmodel, 0);
                    logs.LogEvents("User Issue Raised successfully", "Tickets/Index", uservalidity);
                    return Content("<script language='javascript' type='text/javascript'>alert('Ticket Submitted Successfully!');location.href='" + @Url.Action("Index", "Tickets") + "'</script>");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('User Not exists please Login!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Tickets/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Tickets") + "'</script>");
            }
            return View();
        }
	}
}