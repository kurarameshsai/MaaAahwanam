using System;
using MaaAahwanam.Models;
using MaaAahwanam.Repository.db;

namespace MaaAahwanam.Service
{
    public class UserLoginDetailsService
    {
        public string AddUserDetails(UserLogin userLogin, UserDetail userDetails)
        {
            string response;
            userLogin.Status = "Active";
            userLogin.RegDate = DateTime.Now;
            userLogin.UpdatedDate = DateTime.Now;
            UserLoginRepository userLoginRepository = new UserLoginRepository();
            UserDetailsRepository userDetailsRepository = new UserDetailsRepository();
            try
            {
                UserLogin l1 = userLoginRepository.AddLoginCredentials(userLogin);
                UserDetail l2 = userDetailsRepository.AddUserDetails(userDetails);
                response = "sucess";
            }
            catch (Exception ex)
            {
                response = "failure";
            }
            return response;
        }
        public UserLogin AuthenticateUser(UserLogin UserLogin)
        {
            string response = string.Empty;
            UserLoginRepository userLoginRepository = new UserLoginRepository();
            UserLogin = userLoginRepository.GetLoginDetailsByUsername(UserLogin);
            return UserLogin;
        }
    }
}
