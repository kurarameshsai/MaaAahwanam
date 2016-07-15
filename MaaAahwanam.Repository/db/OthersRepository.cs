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
    }
}
