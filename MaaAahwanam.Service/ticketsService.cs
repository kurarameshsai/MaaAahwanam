using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class ticketsService
    {
        IssueTicketRepository issueTicketRepository = new IssueTicketRepository();

        public int TicketsCount()
        {
            int l1 = issueTicketRepository.IssueTicketsList().Count;
            return l1;
        }
        public List<IssueTicket> GetIssueTicket()
        {
            return issueTicketRepository.IssueTicketsList();
        }

        public string Insertissueticket(IssueTicket issueTicket)
        {
            string message = string.Empty;
            try
            {
                issueTicket.UpdatedDate = DateTime.Now;
                issueTicketRepository.Insertissueticket(issueTicket);
                message = "Success";
            }
            catch (Exception Ex)
            {
                message = "Success";
            }
            return message;
        }
    }
}
