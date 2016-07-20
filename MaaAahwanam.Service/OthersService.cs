using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;
using MaaAahwanam.Repository;

namespace MaaAahwanam.Service
{
    public class OthersService
    {
        OthersRepository othersRepository = new OthersRepository();
        //Comments Module
        public List<Comment> CommentList()
        {
            return othersRepository.CommentsList();
        }

        public CommentDetail AddComment(CommentDetail commentDetail)
        {
            commentDetail.Status = "Active";
            commentDetail.UpdatedDate = DateTime.Now;
            return othersRepository.AddComment(commentDetail);
        }

        public List<MaaAahwanam_Others_Comments_Result> CommentRecordService(long id)
        {
            return othersRepository.CommentRecord(id);
        }

        public List<CommentDetail> CommentDetail(long id)
        {
            return othersRepository.CommentDetail(id);
        }

        //Tickets Module
        public List<IssueTicket> TicketList()
        {
            return othersRepository.TicketList();
        }
        public List<MaaAahwanam_Others_Tickets_Result> TicketRecordService(long id)
        {
            return othersRepository.TicketRecord(id);
        }
    }
}
