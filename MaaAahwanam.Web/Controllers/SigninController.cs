using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using Newtonsoft.Json.Linq;

namespace MaaAahwanam.Web.Controllers
{
    public class SigninController : Controller
    {
        LogsUtility logs = new LogsUtility();
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                TempData["Alert"] = TempData["AlertContent"];
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(UserLoginDetails model, string Command)
        {
            try
            {
                WebClient client = new WebClient();
                string action = "User";
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                UserLoginDetails userlogindetails = new UserLoginDetails();
                if (Command == "Authenticate")
                {
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.Password = model.Password;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId != 0)
                    {
                        ValidUserUtility.SetAuthCookie(userlogindetails.UserLoginId.ToString(), userlogindetailsbal.Usertype(userlogindetails.UserLoginId));
                        logs.LogEvents("Login Successfully", "signin/Index");
                        logs.LogTimings("In");
                        return RedirectToAction("Index", "DashBoard");
                    }
                    else
                    {
                        TempData["AlertContent"] = "<script language='javascript' type='text/javascript'>alert('Invalid username/password!')</script>";
                    }
                }
                if (Command == "Register")
                {
                    userlogindetails.FirstName = model.FirstName;
                    userlogindetails.LastName = model.LastName;
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.Password = model.Password;
                    userlogindetails.UserPhone = model.UserPhone;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId == 0)
                    {
                        userlogindetailsbal.RegisterUserDetails(userlogindetails, action);
                        logs.LogEvents("User registerd successfully", "Login/Index", userlogindetailsbal.UserloginID(userlogindetails));
                        return Content("<script language='javascript' type='text/javascript'>alert('Registered  Successfully!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");

                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('User already exists!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                    }
                }
                if (Command == "ForgotPassword")
                {
                    userlogindetails.UserName = model.UserName;
                    userlogindetails.UserLoginId = userlogindetailsbal.UserloginID(userlogindetails);
                    if (userlogindetails.UserLoginId != 0)
                    {
                        if (userlogindetailsbal.SendingMail_For_PasswordForgot(userlogindetails, action) == true)
                        {
                            userlogindetailsbal.Request_For_ForgetPassword(userlogindetails);
                            return Content("<script language='javascript' type='text/javascript'>alert('Email sent successfully!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                        }
                        else
                        {
                            logs.LogEvents("User ForgotPassword mail sending failed", "Signin / Index");
                            return Content("<script language='javascript' type='text/javascript'>alert('Email sending failed!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                        }
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please check the username!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                    }
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Signin/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "signin") + "'</script>");
            }
            return RedirectToAction("Index", "Signin");
        }

        public ActionResult SignOut()
        {
            logs.LogTimings("Out");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Signin");
        }

        [ChildActionOnly]
        public PartialViewResult SigninPartial()
        {
            UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
            UserLoginDetails model = new UserLoginDetails();
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                ViewBag.Type = ValidUserUtility.UserType();
                var userlist = userlogindetailsbal.UserProfile(ValidUserUtility.ValidUser()).FirstOrDefault();
                if (userlist != null)
                {
                    model.FirstName = userlist.FirstName;
                    model.LastName = userlist.LastName;
                    model.UserImgId = userlist.UserImgId;
                    model.UserLoginId = userlist.UserLoginId;
                }
            }
            return PartialView("SigninPartial", model);
        }
        public JsonResult RegularExpressionPattern_Password()
        {
            return Json(ValidationsUtility.PatternforPassword(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResetPassword()
        {
            string Id = HttpContext.Request.Params.Get("Id");
            UserLoginDetails model = new UserLoginDetails();
            model.UserLoginId = Convert.ToInt32(Encrypt_and_DecryptUtility.Decrypt(Id));
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(UserLoginDetails model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Password))
                {
                    UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                    if (model.UserLoginId != 0)
                    {
                        string requestcheck = userlogindetailsbal.forgotpwd_Requestcheck(model);
                        if (!string.IsNullOrEmpty(requestcheck))
                        {
                            userlogindetailsbal.ResetingPassword(model);
                            logs.LogEvents("PassWord Updated Successfully", "Index", model.UserLoginId);
                            return RedirectToAction("Index", "Signin");
                        }
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please Raise Request For ResetPassword!');location.href='Signin/Index'</script>");
                    }
                }

            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "Signin/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='/Signin/Index'</script>");
            }
            return View();
        }
    }
}