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
    public class IssueTicketsAdminController : Controller
    {
        LogsUtility logs = new LogsUtility();
        // GET: /IssueTicketsAdmin/
        public ActionResult AdminTicketIndex(IssueTicketsModel issueticketModel)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    issueticketModel.IssueList = issuebal.IssueTicketList(0);
                    issueticketModel.IssueDetailsList = issuebal.IssueTicket_DetailsList(0);
                    logs.LogEvents("Viewing IssueTicketAdmin", "DashBoard/IssueTicketsAdmin");
                    return View(issueticketModel);
                }
                else
                {
                    return RedirectToAction("Index", "Login", new { Areas = "Admin" });
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/IssueTicketsAdmin");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='DashBoard/IssueTicketsAdmin'</script>");
            }
            return View();
        }

        public ActionResult TicketDetView()
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                IssueTicketsModel issueticketModel = new IssueTicketsModel();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    //int id = Convert.ToInt32(HttpContext.Request.Params.Get("id"));
                    int id = Convert.ToInt32(this.ControllerContext.RouteData.Values["id"].ToString());
                    if (id != 0)
                    {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    issueticketModel.IssueList = issuebal.IssueTicketList(id);
                    issueticketModel.IssueDetailsList = issuebal.IssueTicket_DetailsList(id);
                    logs.LogEvents("Viewing IssueTicketAdmin", "IssueTicketsAdmin/AdminTicketIndex");
                    return View(issueticketModel);
                    }
                    else
                    {
                        return RedirectToAction("AdminTicketIndex", "IssueTicketsAdmin", new { Areas = "Admin" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login", new { Areas = "Admin" });
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "IssueTicketsAdmin/AdminTicketIndex");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='/Admin/IssueTicketsAdmin/AdminTicketIndex'</script>");
            }
           
        }

        public ActionResult Update(IssueTicketsModel issueticketModel,string id)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    IssueTicketDetails issuedetmodel = new IssueTicketDetails();
                    int val = Convert.ToInt32(id.ToString());
                    if (val != 0)
                    {
                        
                        issuedetmodel.UserLoginId = uservalidity;
                        issuedetmodel.Severity = issueticketModel.Severity;
                        issuedetmodel.Msg = issueticketModel.Msg;
                        issuebal.RegisterIssueDetails(issuedetmodel, val);
                        logs.LogEvents("Viewing IssueTicketDetails", "IssueTicket/Index");
                        return Content("<script language='javascript' type='text/javascript'>alert('Issue Submitted Successfully!');location.href='" + @Url.Action("TicketDetView", "IssueTicketsAdmin", new { id = val }) + "'</script>");
                    }
                    else
                    {
                        return RedirectToAction("AdminTicketIndex", "IssueTicketsAdmin", new { Areas = "Admin" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login", new { Areas = "Admin" });
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "IssueTicket/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("AdminTicketIndex", "IssueTicketsAdmin", new { Areas = "Admin" }) + "'</script>");
            }
        }
        
	}
}