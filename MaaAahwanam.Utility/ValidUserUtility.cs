using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Utility
{
    public class ValidUserUtility
    {
        public static int ValidUser()
        {
            int Userid = 0;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) Userid = 0;
            //else if (authCookie.Name == ".ASPXAUTH") Userid = 0;
            else Userid = int.Parse(FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            return Userid;
        }
        public static string UserType()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userdata = ticket.UserData;
            return userdata;
        }
        public static void SetAuthCookie(string UserID, string Userdata)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
              1,                                        // ticket version
              UserID,                                   // authenticated username
              DateTime.Now,                             // issueDate
              DateTime.Now.AddMonths(1),                // expiryDate
              false,                                    // true to persist across browser sessions
              Userdata,                                 // can be used to store additional user data
              FormsAuthentication.FormsCookiePath);     // the path for the cookie
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(cookie);

        }


    }
}
