using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;
using MaaAahwanam.Repository;
namespace MaaAahwanam.Repository.db
{
    public class OthersRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        MaaAahwanamEntities maaAahwanamEntities = new MaaAahwanamEntities();
        //Comments Module
        public List<Comment> CommentsList()
        {
            return _dbContext.Comment.ToList();
        }

        public CommentDetail AddComment(CommentDetail commentDetail)
        {
            _dbContext.CommentDetail.Add(commentDetail);
            _dbContext.SaveChanges();
            return commentDetail;
        }

        public List<MaaAahwanam_Others_Comments_Result> CommentRecord(long id)
        {
            return maaAahwanamEntities.MaaAahwanam_Others_Comments(id).ToList();
        }

        public List<CommentDetail> CommentDetail(long id)
        {
            return _dbContext.CommentDetail.Where(m => m.UserLoginId == id).ToList();
        }

        //Tickets Module
        public List<IssueTicket> TicketList()
        {
            return _dbContext.IssueTicket.ToList();
        }
        public List<MaaAahwanam_Others_Tickets_Result> TicketRecord(long id)
        {
            return maaAahwanamEntities.MaaAahwanam_Others_Tickets(id).ToList();
        }
        public IssueDetail AddTicket(IssueDetail issueDetail)
        {
            _dbContext.IssueDetail.Add(issueDetail);
            _dbContext.SaveChanges();
            return issueDetail;
        }
        public List<IssueDetail> TicketDetail(long id)
        {
            return _dbContext.IssueDetail.Where(m => m.TicketId == id).ToList();
        }

        //Registered Users Module
        public List<MaaAahwanam_Others_RegisteredUsers_Result> RegisteredUsersList()
        {
            return maaAahwanamEntities.MaaAahwanam_Others_RegisteredUsers().ToList();
        }
        public List<MaaAahwanam_Others_RegisteredUsersDetails_Result> RegisteredUserDetails(long id)
        {
            return maaAahwanamEntities.MaaAahwanam_Others_RegisteredUsersDetails(id).ToList();
        }

        //Testimonals Module
        //public List<MaaAahwanam_Others_Testimonials_Result> TestimonalsList()
        //{
        //    return maaAahwanamEntities.MaaAahwanam_Others_Testimonials().ToList();
        //}
        //public List<MaaAahwanam_Others_TestimonialDetail_Result> TestimonalDetail(long id)
        //{
        //    return maaAahwanamEntities.MaaAahwanam_Others_TestimonialDetail(id).ToList();
        //}
    }
}
