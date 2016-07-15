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
        public List<Comment> CommentList()
        {
            return othersRepository.CommentsList();
        }

        public CommentDetail AddComment(CommentDetail commentDetail)
        {
            return othersRepository.AddComment(commentDetail);
        }

        public List<MaaAahwanam_Others_Comments_Result> CommentRecordService(long id)
        {
            return othersRepository.CommentRecord(id);
        }
    }
}
