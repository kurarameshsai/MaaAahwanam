using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;

namespace MaaAahwanam
{
    public class IssueTicketDetailsBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public void RegisterIssueDetails(IssueTicketDetails issueticketModel, int ticketid)
        {
            MA_IssueTickets issueticket = new MA_IssueTickets();
            MA_Issue_Details issueticketdetails = new MA_Issue_Details();
            if (ticketid == 0)
            {
                issueticket.UserLoginId = issueticketModel.UserLoginId;
                issueticket.Issue_Type = issueticketModel.Issue_Type;
                issueticket.Subject = issueticketModel.Subject;
                issueticket.Severity = issueticketModel.Severity;
                issueticket.Name = issueticketModel.Name;
                issueticket.CreatedBy = issueticketModel.UserLoginId.ToString();
                issueticket.CreatedDate = DateTime.Now;
                issueticket.Status = "Open";
                issueticket.ClosedDate = DateTime.Now;
                _Repositories.IssueTickets.Add(issueticket);
                _Repositories.SaveChanges();
                issueticketdetails.Ticket_Id = issueticket.Ticket_Id;
                issueticketdetails.Msg = issueticketModel.Msg;
                issueticketdetails.RepliedBy = issueticketModel.UserLoginId.ToString();
                issueticketdetails.ReplayedDate = DateTime.Now;
                _Repositories.IssueTickets_Details.Add(issueticketdetails);
                _Repositories.SaveChanges();
            }
            else
            {
                issueticket = _Repositories.IssueTickets.Get().Where(p => p.Ticket_Id == ticketid).First();
                issueticket.ClosedDate = DateTime.Now;
                _Repositories.SaveChanges();
                issueticketdetails = _Repositories.IssueTickets_Details.Get().Where(p => p.Ticket_Id == ticketid).First();
                issueticketdetails.Msg = issueticketModel.Msg;
                issueticketdetails.RepliedBy = issueticketModel.UserLoginId.ToString();
                issueticketdetails.ReplayedDate = DateTime.Now;
                _Repositories.IssueTickets_Details.Add(issueticketdetails);
                _Repositories.SaveChanges();
            }
        }
        public List<MA_IssueTickets> IssueTicketList(int id)
        {
            var issuelist = new List<MA_IssueTickets>();
            if (id == 0)
            {
                issuelist = _Repositories.IssueTickets.Get().OrderByDescending(p => p.Ticket_Id).ToList();
            }
            else
            {
                issuelist = _Repositories.IssueTickets.Get().Where(p => p.Ticket_Id == id).ToList();
            }
            return issuelist;
        }

        public List<MA_Issue_Details> IssueTicket_DetailsList(int id)
        {
            var issueDetaislist = new List<MA_Issue_Details>();
            if (id == 0)
            {
                issueDetaislist = _Repositories.IssueTickets_Details.Get().OrderByDescending(p => p.Ticket_Id).ToList();
            }
            else
            {
                issueDetaislist = _Repositories.IssueTickets_Details.Get().Where(p => p.Ticket_Id == id).OrderByDescending(p => p.ReplayedDate).ToList();
            }
            return issueDetaislist;
        }

        
        public List<SP_TICKETLIST_Result> ticketlist(int id)
        {
            return _Repositories.SP_TICKETLIST.ExecuteProcedure_WithParameters("exec SP_TICKETLIST  {0},{1}", 1, id).ToList();
        }
        public List<SP_TicketsUserList_Result> Userticketlist(int id)
        {
            return _Repositories.SP_TicketsUserList.ExecuteProcedure_WithParameters("exec SP_TicketsUserList  {0},{1}", id, 1).ToList();
        }
    }
}
