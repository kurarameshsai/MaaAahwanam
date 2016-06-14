using MaaAahwanam.Models;

namespace MaaAahwanam.Dal.db
{
    public class UserLoginRepository
    {
        readonly ApiContext _dbContext = new ApiContext();

        public UserLoginRepository()
        {

        }

        public UserLogin AddLoginCredentials(UserLogin userLogin)
        {
            _dbContext.MA_User_Login.Add(userLogin);
            _dbContext.SaveChanges();
            return userLogin;
        }
    }
}
