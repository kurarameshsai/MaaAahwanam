using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam.Bal
{
    public class UserLoginDetalsBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public int UserloginID(UserLoginDetails userlogindetails)
        {
            if (userlogindetails.Password != null)
            {
                string DecryptePassword = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.Password);
                userlogindetails.UserLoginId = _Repositories.UserLoginDetails.Get().Where(i => i.UserName == userlogindetails.UserName && i.Password == DecryptePassword).Select(i => i.UserLoginId).SingleOrDefault();
            }
            else
            {
                userlogindetails.UserLoginId = _Repositories.UserLoginDetails.Get().Where(i => i.UserName == userlogindetails.UserName).Select(i => i.UserLoginId).SingleOrDefault();
            }
            return userlogindetails.UserLoginId;
        }

        public string Usertype(int id)
        {
            return _Repositories.UserLoginDetails.Get().Where(i => i.UserLoginId == id).Select(i => i.UserType).SingleOrDefault();
        }
        public void RegisterUserDetails(UserLoginDetails userlogindetails, string action)
        {
            MaaAahwanam.Dal.MA_User_Login userlogin = new MA_User_Login();
            MaaAahwanam.Dal.MA_User_Details userdetails = new MA_User_Details();
            userlogin.UserName = userlogindetails.UserName;
            userlogin.Password = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.Password);
            userlogin.RegDate = DateTime.Now;
            userlogin.UserType = action;
            userlogin.Status = "1";
            _Repositories.UserLoginDetails.Add(userlogin);
            _Repositories.SaveChanges();
            userdetails.FirstName = userlogindetails.FirstName;
            userdetails.LastName = userlogindetails.LastName;
            userdetails.UserLoginId = userlogin.UserLoginId;
            if (action == "User")
            {
                userdetails.UserPhone = userlogindetails.UserPhone;
            }
            else
            {
                userdetails.UserPhone = "9553514112";
            }
            _Repositories.UserDetails.Add(userdetails);
            _Repositories.SaveChanges();
        }

        public bool SendingMail_For_PasswordForgot(UserLoginDetails userlogindetails, string action)
        {
            try
            {
                string userid = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.UserLoginId.ToString());
                string SubjectDetails = "Reset your MaaAhwaanam ID password";
                string BodyContent = " Dear User,";
                BodyContent += "<BR/><BR/> You Requested for Password Reset. Please Click The Link Below to Reset your Password <BR/><BR/> ";
                if (action=="Admin")
                {
                   // BodyContent += "<BR/><BR/> http://localhost:8566/Admin/Login/ResetPassword/" + userid;
                    BodyContent += "<BR/><BR/> http://betadev.maa-aahwanam.com/admin/login/ResetPassword?Id="+userid;                    
                }
                else
                {
                   // BodyContent += "<BR/><BR/> http://localhost:8566/Signin/ResetPassword?Id=" + userid;
                    BodyContent += "<BR/><BR/> http://betadev.maa-aahwanam.com/Signin/ResetPassword?Id="+userid;  
                }
                BodyContent += "<BR/><BR/> Thank You,";
                BodyContent += "<BR/> MaaAhwaanam ";
                //EmailUtility.SendHTMLMail( userlogindetails.UserName, FromAddress, SubjectDetails, BodyContent);
                EmailUtility.sendMailfromLocal(userlogindetails.UserName, SubjectDetails, BodyContent);//smtp host use
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Request_For_ForgetPassword(UserLoginDetails userlogindetails)
        {
            MaaAahwanam.Dal.MA_ForgotPassword forgotpassword = new MA_ForgotPassword();
            forgotpassword.UserLoginId = userlogindetails.UserLoginId;
            forgotpassword.UserName = userlogindetails.UserName;
            forgotpassword.ReqRaised = true;
            forgotpassword.RaisedDate = DateTime.Now;
            if (_Repositories.ForgetPassword.Get().Where(p => p.UserLoginId == userlogindetails.UserLoginId).FirstOrDefault() == null)
            {
                _Repositories.ForgetPassword.Add(forgotpassword);
            }
            _Repositories.SaveChanges();

        }
        public void ResetingPassword(UserLoginDetails userlogindetails)
        {
            var ma_user_loginlist = new List<MA_User_Login>();
            ma_user_loginlist = _Repositories.UserLoginDetails.Get().ToList();
            var query = (from updatepwd in ma_user_loginlist
                         where updatepwd.UserLoginId == userlogindetails.UserLoginId
                         select updatepwd).First();
            query.Password = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.Password);
            _Repositories.SaveChanges();
            var forgetquery = _Repositories.ForgetPassword.Get().Where(i => i.UserLoginId == userlogindetails.UserLoginId).SingleOrDefault();
            _Repositories.ForgetPassword.Delete(forgetquery);
            _Repositories.SaveChanges();
        }

        public int forgotpwdUserCheck(UserLoginDetails userlogindetails)
        {
            return _Repositories.UserLoginDetails.Get().Where(i => i.UserName == userlogindetails.UserName && i.Status == "1").Select(i => i.UserLoginId).SingleOrDefault();
        }

        public string forgotpwd_Requestcheck(UserLoginDetails userlogindetails)
        {
            return _Repositories.ForgetPassword.Get().Where(i => i.UserLoginId == userlogindetails.UserLoginId && i.ReqRaised == true).Select(i => i.UserName).First();
            //return _Repositories.ForgetPassword.Get().Where(i => i.UserName == userlogindetails.UserName && i.ReqRaised == true).Select(i => i.UserName).First();
        }
        public IEnumerable<Sp_Admin_UserProfile_Result> UserProfile(int ticket)
        {
            return _Repositories.Sp_Admin_UserProfile.ExecuteProcedure_WithParameters("exec Sp_Admin_UserProfile {0},{1}", ticket, 1).ToList();
        }

        public void Update_UserProfile(UserLoginDetails userlogindetails)
        {
            var ma_user_loginlist = new List<MA_User_Details>();
            ma_user_loginlist = _Repositories.UserDetails.Get().ToList();
            var userdetails = (from updateUser in ma_user_loginlist
                               where updateUser.UserLoginId == userlogindetails.UserLoginId
                               select updateUser).First();
            userdetails.FirstName = userlogindetails.FirstName;
            userdetails.LastName = userlogindetails.LastName;
            userdetails.UserPhone = userlogindetails.UserPhone;
            userdetails.Address = userlogindetails.Address;
            userdetails.Url = userlogindetails.Url;
            userdetails.City = userlogindetails.City;
            userdetails.State = userlogindetails.State;
            userdetails.ZipCode = userlogindetails.ZipCode;
            userdetails.UserImgId = userlogindetails.UserImgId;
            userdetails.UserImgName = userlogindetails.UserImgName;
            _Repositories.SaveChanges();
        }

        public int checkuservalidity()
        {
            return ValidUserUtility.ValidUser();
        }

        public IQueryable<MA_User_Details> List_UserLoginDetails(UserLoginDetails userlogindetails)
        {
            var List = _Repositories.UserDetails.Get().Where(i => i.UserLoginId == userlogindetails.UserLoginId);
            return List;
        }
        public int LockPwdCheck(UserLoginDetails userlogindetails)
        {
            string DecryptePassword = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.Password);
            userlogindetails.UserLoginId = _Repositories.UserLoginDetails.Get().Where(i => i.Password == DecryptePassword && i.UserLoginId == userlogindetails.UserLoginId).Select(i => i.UserLoginId).SingleOrDefault();
            _Repositories.Dispose();
            return userlogindetails.UserLoginId;
        }
        public int forgotpwdUserCheck_changepwd(UserLoginDetails userlogindetails)
        {
            string pwd = Encrypt_and_DecryptUtility.Encrypt(userlogindetails.Password).ToString();
            return _Repositories.UserLoginDetails.Get().Where(i => i.Password == pwd && i.Status == "1").Select(i => i.UserLoginId).FirstOrDefault();
        }
    }
}





