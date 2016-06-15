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
            _dbContext.MaUserLogin.Add(userLogin);
            _dbContext.SaveChanges();
            return userLogin;
        }

        public UserLogin GetLoginDetailsByUsername(UserLogin userLogin)
        {
            UserLogin list = null;
            if (userLogin.Password != null)
                list = _dbContext.MaUserLogin.FirstOrDefault(p => p.UserName == userLogin.UserName && p.Password == userLogin.Password);
            if (userLogin.Password == null)
                list = _dbContext.MaUserLogin.FirstOrDefault(p => p.UserName == userLogin.UserName);
            return list;
        }
    }
}
