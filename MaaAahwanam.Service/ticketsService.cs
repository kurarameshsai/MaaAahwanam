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
        public int TicketsCount()
        {
            IssueTicketRepository issueTicketRepository = new IssueTicketRepository();
            int l1 = issueTicketRepository.IssueTicketsList().Count;
            return l1;
        }
    }
}
