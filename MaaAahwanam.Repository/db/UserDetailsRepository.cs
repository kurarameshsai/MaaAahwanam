using System.Linq;
using MaaAahwanam.Models;


namespace MaaAahwanam.Repository.db
{
    public class UserDetailsRepository
    {
        readonly ApiContext _dbContext = new ApiContext();

        public UserDetailsRepository()
        {

        }

        public UserDetail AddUserDetails(UserDetail userDetails)
        {
            _dbContext.UserDetail.Add(userDetails);
            _dbContext.SaveChanges();
            return userDetails;
        }
        public UserDetail GetLoginDetailsByUsername(int userId)
        {
            UserDetail list = new UserDetail();
            if (userId != 0)
                list = _dbContext.UserDetail.SingleOrDefault(p => p.UserLoginId == userId);
            return list;
        }
    }
}
