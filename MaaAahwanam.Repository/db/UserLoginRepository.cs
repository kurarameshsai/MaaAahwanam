using System.Linq;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class UserLoginRepository
    {
        readonly ApiContext _dbContext = new ApiContext();

        public UserLoginRepository()
        {

        }

        public UserLogin AddLoginCredentials(UserLogin userLogin)
        {
            _dbContext.UserLogin.Add(userLogin);
            _dbContext.SaveChanges();
            return userLogin;
        }

        public UserLogin GetLoginDetailsByUsername(UserLogin userLogin)
        {
            UserLogin list = null;
            if (userLogin.Password != null)
                list = _dbContext.UserLogin.FirstOrDefault(p => p.UserName == userLogin.UserName && p.Password == userLogin.Password);
            if (userLogin.Password == null)
                list = _dbContext.UserLogin.FirstOrDefault(p => p.UserName == userLogin.UserName);
            return list;
        }
        //public UserLogin GetLoginDetailsByUsername(int userId)
        //{
        //    //UserLogin list = new UserLogin();
        //    UserDetail list = new UserDetail();
        //    if (userId != 0)
        //    list = _dbContext.UserDetail.SingleOrDefault(p => p.UserLoginId==userId);
        //    return list;
        //}
    }
}
