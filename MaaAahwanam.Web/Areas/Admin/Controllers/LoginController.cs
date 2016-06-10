using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        LogsUtility logs = new LogsUtility();
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginDetailsModel model, string Command)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                UserLoginDetails userlogindetails = new UserLoginDetails();
                string action = "Admin";
                if (Command == "Authenticate")
                {
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.Password = model.Password;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId != 0)
                    {
                        ValidUserUtility.SetAuthCookie(userlogindetails.UserLoginId.ToString(), userlogindetailsbal.Usertype(userlogindetails.UserLoginId));
                        logs.LogEvents("Login Successfully", "Login/Index");
                        logs.LogTimings("In");
                        return RedirectToAction("Dashboard", "DashBoard");
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Invalid username/password!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                    }
                }
                if (Command == "ForgotPassword")
                {
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId != 0)
                    {
                        if (userlogindetailsbal.SendingMail_For_PasswordForgot(userlogindetails,"") == true)
                        {
                            userlogindetailsbal.Request_For_ForgetPassword(userlogindetails);
                            logs.LogEvents("ForgotPassword mail sent", "Login / Index");
                            return Content("<script language='javascript' type='text/javascript'>alert('Email sent successfully!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                        }
                        else
                        {
                            logs.LogEvents("ForgotPassword mail sending failed", "Login / Index");
                            return Content("<script language='javascript' type='text/javascript'>alert('Email sending failed!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                        }
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please check the username!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                    }
                }
                if (Command == "Register")
                {

                    userlogindetails.FirstName = model.FirstName;
                    userlogindetails.LastName = model.LastName;
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.Password = model.Password;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId == 0)
                    {
                        userlogindetailsbal.RegisterUserDetails(userlogindetails, action);
                        logs.LogEvents("user registerd successfully", "Login/Index", userlogindetailsbal.UserloginID(userlogindetails));
                        return Content("<script language='javascript' type='text/javascript'>alert('Registered  Successfully!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('User already exists!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
                    }
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Login/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Login") + "'</script>");
            }
            return View();
        }
        public JsonResult RegularExpressionPattern_Password()
        {
            return Json(ValidationsUtility.PatternforPassword(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult SignOut()
        {
            logs.LogTimings("Out");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
         public ActionResult ResetPassword(UserLoginDetails model)
        {
            try
            {
                if ((!string.IsNullOrEmpty(model.Password)) && (!string.IsNullOrEmpty(model.UserName)))
                {
                    UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                    UserLoginDetails userlogindetails = new UserLoginDetails();
                    userlogindetails.UserName = model.UserName;
                    int uservalidity = userlogindetailsbal.forgotpwdUserCheck(userlogindetails);
                    if (uservalidity != 0)
                    {
                        string requestcheck = userlogindetailsbal.forgotpwd_Requestcheck(userlogindetails);
                        if (!string.IsNullOrEmpty(requestcheck))
                        {
                            userlogindetails.UserLoginId = uservalidity;
                            userlogindetails.Password = model.Password;
                            userlogindetailsbal.ResetingPassword(userlogindetails);
                            logs.LogEvents("PassWord Updated Successfully", "Index", uservalidity);
                             return RedirectToAction("Index", "Login");
                         }
                     }
                     else
                     {
                         return Content("<script language='javascript' type='text/javascript'>alert('User Not exists!');location.href='Index'</script>");
                     }
                }
               
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Login/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='Index'</script>");
            }
            return View();
        }
    }
}