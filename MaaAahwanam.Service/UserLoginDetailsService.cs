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
            UserLoginRepository userLoginRepository = new UserLoginRepository();
            UserDetailsRepository userDetailsRepository = new UserDetailsRepository();
            try
            {
                UserLogin l1 = userLoginRepository.AddLoginCredentials(userLogin);
                UserDetail l2 = userDetailsRepository.AddUserDetails(userDetails);
                response = "sucess";
            }
            catch(Exception ex)
            {
                response = "failure";
            }
            return response;
        }
    }
}
