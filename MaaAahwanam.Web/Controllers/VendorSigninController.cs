using MaaAahwanam.Models;
using MaaAahwanam.Service;
using MaaAahwanam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Controllers
{
    public class VendorSigninController : Controller
    {
        //
        // GET: /VendorSignin/
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string command,UserLogin userLogin)
        {
            if (command == "Authenticate")
            {
                UserLoginDetailsService userLoginDetailsService = new UserLoginDetailsService();
                var response = userLoginDetailsService.AuthenticateUser(userLogin);
                if (response != null)
                {
                    ValidUserUtility.SetAuthCookie(response.UserLoginId.ToString(), response.UserType);
                    Response.Redirect("VendorDashBoard/Index");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Wrong Credentials,Check Username and password');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
                }
            }
            return View();
        }
	}
}