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
        public List<IssueTicket> EventsandTipsList()
        {
            IssueTicketRepository issueTicketRepository = new IssueTicketRepository();
            List<IssueTicket> l1 = issueTicketRepository.IssueTicketsList();
            return l1;
        }
    }
}
