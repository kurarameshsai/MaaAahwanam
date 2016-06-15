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
    }
}
