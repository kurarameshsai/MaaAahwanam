using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class IssueTicketDetails
    {
        public int Ticket_Id { get; set; }
        public Nullable<int> UserLoginId { get; set; }
        public Nullable<int> Order_Id { get; set; }
        public string Issue_Type { get; set; }
        public string Subject { get; set; }
        public string Severity { get; set; }
        public Nullable<System.DateTime> RaisedDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Name { get; set; }
        public int Ticket_Commu_Id { get; set; }
        public string Msg { get; set; }
        public string RepliedBy { get; set; }
        public Nullable<System.DateTime> ReplayedDate { get; set; }

        public List<SP_TicketsUserList_Result> SP_TicketsUserList1;

        public List<SP_TICKETLIST_Result> SP_TICKETLIST1;
      
    }
}
