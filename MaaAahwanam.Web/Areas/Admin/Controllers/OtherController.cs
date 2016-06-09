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

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class OtherController : Controller
    {
        LogsUtility logs = new LogsUtility();
        //
        // GET: /Other/
        public ActionResult Index(UserLoginDetailsModel model)
        {
            try
            {
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    var userlist = userlogindetailsbal.UserProfile(uservalidity).FirstOrDefault();
                    model.FirstName = userlist.FirstName;
                    model.LastName = userlist.LastName;
                    model.UserImgId = userlist.UserImgId;
                    logs.LogEvents("Viewing DashBoard", "DashBoard/dashboard");
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
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='DashBoard/dashboard'</script>");
            }
            return View();
        }
    }
}