using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class IssueTicketsModel
    {
        public int Ticket_Id { get; set; }
        public Nullable<int> UserLoginId { get; set; }
        public Nullable<int> Order_Id { get; set; }
        public string Issue_Type { get; set; }
        public string Subject { get; set; }
        public string Msg { get; set; }
        public string Severity { get; set; }
        public Nullable<System.DateTime> RaisedDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        public List<MA_IssueTickets> IssueList;

        public List<MA_Issue_Details> IssueDetailsList;
        
    }
}