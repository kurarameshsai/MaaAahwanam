using MaaAahwanam.Models;


namespace MaaAahwanam.Repository.db
{
    public class UserDetailsRepository
    {
        readonly ApiContext _dbContext = new ApiContext();

        public UserDetailsRepository()
        {

        }

        public UserDetails AddUserDetails(UserDetails userDetails)
        {
            _dbContext.MaUserDetails.Add(userDetails);
            _dbContext.SaveChanges();
            return userDetails;
        }
    }
}
