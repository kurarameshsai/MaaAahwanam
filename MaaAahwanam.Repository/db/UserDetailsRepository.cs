using MaaAahwanam.Models;

namespace MaaAahwanam.Dal.db
{
    public class UserDetailsRepository
    {
        readonly ApiContext _dbContext = new ApiContext();

        public UserDetailsRepository()
        {

        }

        public UserDetails AddUserDetails(UserDetails userDetails)
        {
            _dbContext.MA_User_Details.Add(userDetails);
            _dbContext.SaveChanges();
            return userDetails;
        }
    }
}
