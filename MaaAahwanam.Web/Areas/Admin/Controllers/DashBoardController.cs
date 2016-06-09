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
using MaaAahwanam.Dal;
using System.Text;
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        LogsUtility logs = new LogsUtility();
        public ActionResult dashboard()
        {
            AdminDashboard admindashboard=new AdminDashboard();
            AdminDashboardBAL admindashboardBAL=new AdminDashboardBAL();
            admindashboard.Dashboardcounts = admindashboardBAL.dashboardcounts().ToList();
            return View(admindashboard);
        }

        public ActionResult UserProfile(UserLoginDetailsModel model)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    var userlist = userlogindetailsbal.UserProfile(uservalidity).FirstOrDefault();
                    model.UserType = userlist.UserType;
                    model.FirstName = userlist.FirstName;
                    model.LastName = userlist.LastName;
                    model.Address = userlist.Address;
                    model.City = userlist.City;
                    model.Url = userlist.Url;
                    model.State = userlist.State;
                    model.UserPhone = userlist.UserPhone;
                    model.ZipCode = userlist.ZipCode;
                    model.UserImgId = userlist.UserImgId;
                    model.UserImgName = userlist.UserImgName;
                    logs.LogEvents("Viewing UserProfile", "DashBoard/UserProfile");

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='UserProfile'</script>");
            }
            return View();

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserProfile(UserLoginDetailsModel model, HttpPostedFileBase file)
        {
            UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
            UploadFile uploadfile = new UploadFile();
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            int uservalidity = userlogindetailsbal.checkuservalidity();
            if (uservalidity != 0)
            {
                UserLoginDetails userlogindetails = new UserLoginDetails();
                userlogindetails.FirstName = model.FirstName;
                userlogindetails.LastName = model.LastName;
                userlogindetails.UserLoginId = uservalidity;
                userlogindetails.UserPhone = model.UserPhone;
                userlogindetails.Address = model.Address;
                userlogindetails.Url = model.Url;
                userlogindetails.City = model.City;
                userlogindetails.State = model.State;
                userlogindetails.ZipCode = model.ZipCode;
                string imgname = model.UserImgName;
                if (file != null && (string.IsNullOrEmpty(imgname)))
                {
                    string filedetails = uploadfile.Uploadfiles(file, actionName);
                    string[] words = filedetails.Split('|');
                    userlogindetails.UserImgId = words[0];
                    userlogindetails.UserImgName = words[1];
                }
                else if (file != null && (!string.IsNullOrEmpty(imgname)))
                {
                    string filedetails = uploadfile.Uploadfiles(file, actionName);
                    string[] words = filedetails.Split('|');
                    userlogindetails.UserImgId = words[0];
                    userlogindetails.UserImgName = words[1];
                }
                else if (file == null && (!string.IsNullOrEmpty(imgname)))
                {
                    userlogindetails.UserImgId = model.UserImgId;
                    userlogindetails.UserImgName = model.UserImgName;
                }
                userlogindetailsbal.Update_UserProfile(userlogindetails);
                logs.LogEvents("Saving UserProfile", "DashBoard/UserProfile");
                logs.LogTimings("In");
                return Content("<script language='javascript' type='text/javascript'>alert('UserProfile Updated  Successfully');location.href='UserProfile'</script>");
            }
            return View(model);
        }

        public ActionResult Lock(UserLoginDetailsModel model, string Command, FormCollection collection)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["UserSettings"];
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                UserLoginDetails userlogindetails = new UserLoginDetails();
                if (cookie == null || cookie["ID"] == "")
                {
                    Response.Cookies["UserSettings"]["URL"] = Request.UrlReferrer.LocalPath;
                    Response.Cookies["UserSettings"]["ID"] = ValidUserUtility.ValidUser().ToString();
                    userlogindetails.UserLoginId = ValidUserUtility.ValidUser();
                }
                else
                {
                    userlogindetails.UserLoginId = int.Parse(cookie["ID"]);
                }
                var List = userlogindetailsbal.List_UserLoginDetails(userlogindetails).FirstOrDefault();
                if (List != null)
                {
                    model.FirstName = List.FirstName;
                    model.LastName = List.LastName;
                    model.UserLoginId = List.UserLoginId;
                    model.UserImgId = List.UserImgId;
                }
                if (Command == "Lock")
                {
                    userlogindetails.UserLoginId = int.Parse(collection["UserLoginId"]);
                    userlogindetails.Password = model.Password;
                    model.FirstName = collection["FirstName"];
                    model.LastName = collection["LastName"];
                    model.UserImgId = collection["UserImgId"];
                    model.UserLoginId = userlogindetails.UserLoginId;
                    userlogindetails.UserLoginId = userlogindetailsbal.LockPwdCheck(userlogindetails);
                    if (userlogindetails.UserLoginId != 0)
                    {
                        var currenturl = cookie["url"].Substring(7);
                        Response.Cookies["UserSettings"]["ID"] = null;
                        FormsAuthentication.SetAuthCookie(userlogindetails.UserLoginId.ToString(), false);
                        return RedirectToAction("../" + currenturl);
                    }
                    else
                    {
                        return View(model);
                    }
                }
                FormsAuthentication.SignOut();
                return View(model);
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/Lock");
                return View(model);
            }
        }
        public ActionResult Masterdata(UserLoginDetailsModel model)
        {
            UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
            if (ValidUserUtility.ValidUser() != 0 && ValidUserUtility.UserType() == "Admin")
            {
                var userlist = userlogindetailsbal.UserProfile(ValidUserUtility.ValidUser()).FirstOrDefault();
                model.FirstName = userlist.FirstName;
                model.LastName = userlist.LastName;
                model.UserImgId = userlist.UserImgId;
                return View(model);
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Please Login');location.href='/Admin/Login/Index'</script>");

            }

        }

        public ActionResult ChangePassword(UserLoginDetailsModel model)
        {
            try
            {
                if ((!string.IsNullOrEmpty(model.Password)) && (!string.IsNullOrEmpty(model.NewPassword)))
                {
                    UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                    UserLoginDetails userlogindetails = new UserLoginDetails();
                    userlogindetails.Password = model.Password;
                    int uservalidity = userlogindetailsbal.forgotpwdUserCheck_changepwd(userlogindetails);
                    if (uservalidity != 0)
                    {
                        //string requestcheck = userlogindetailsbal.forgotpwd_Requestcheck(userlogindetails);
                        //if (!string.IsNullOrEmpty(requestcheck))
                        //{
                        userlogindetails.UserLoginId = uservalidity;
                        userlogindetails.Password = model.NewPassword;
                        userlogindetailsbal.ResetingPassword(userlogindetails);
                        logs.LogEvents("PassWord Updated Successfully", "Index", uservalidity);
                        return Content("<script language='javascript' type='text/javascript'>alert('Password Changed Successfully!');location.href='Changepassword'</script>");
                        //return RedirectToAction("Index", "Login");
                        //}
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('User Not exists!');location.href='Changepassword'</script>");
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