using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Controllers
{
    public class CommentsController : Controller
    {
        LogsUtility logs = new LogsUtility();
        // GET: /Comments/
        public ActionResult Index(string Id)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                IssueTicketDetails issueticketModel = new IssueTicketDetails();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    int id = Convert.ToInt32(HttpContext.Request.Params.Get("id"));
                    if (id != 0)
                    {
                        issueticketModel.Ticket_Id = Convert.ToInt32(id.ToString());
                        issueticketModel.SP_TICKETLIST1 = issuebal.ticketlist(id);
                        logs.LogEvents("Viewing TicketCommentsDetails", "Comments/Index");
                        return View(issueticketModel);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Tickets");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Signin");
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Tickets/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Tickets") + "'</script>");
            }
        }

        public ActionResult Update(IssueTicketDetails issueticketModel)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    IssueTicketDetailsBal issuebal = new IssueTicketDetailsBal();
                    IssueTicketDetails issuedetmodel = new IssueTicketDetails();
                    //int val = Convert.ToInt32(this.HttpContext.Request.Params.Get("id").ToString());
                    // int val = Convert.ToInt32(this.ControllerContext.RouteData.Values["id"].ToString());
                    int val = issueticketModel.Ticket_Id;
                    if (val != 0)
                    {
                        issuedetmodel.UserLoginId = uservalidity;
                        issuedetmodel.Severity = issueticketModel.Severity;
                        issuedetmodel.Msg = issueticketModel.Msg;
                        issuebal.RegisterIssueDetails(issuedetmodel, val);
                        logs.LogEvents("Updating TicketCommentsDetails", "Comments/Index");
                        return Content("<script language='javascript' type='text/javascript'>alert('Issue Submitted Successfully!');location.href='/Comments/Index?Id=" + val + "'</script>");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Comments");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Signin");
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "IssueTicket/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Comments") + "'</script>");
            }
        }
    }
}