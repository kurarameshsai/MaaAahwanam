using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using MaaAahwanam.Service;

namespace MaaAahwanam.Web.Controllers
{
    public class AddressBookController : Controller
    {
        UserAddBookService userAddBookService = new UserAddBookService();
        //
        // GET: /AddressBook/
        [HttpGet]
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 &&
                (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                ViewBag.Type = ValidUserUtility.UserType();
                ViewBag.Addressbooklist = userAddBookService.GetUserAddBook(ValidUserUtility.ValidUser());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserAddBook userAddBook)
        {
            userAddBook.UserLoginId = ValidUserUtility.ValidUser();
            userAddBook.UpdatedBy = ValidUserUtility.ValidUser();
            string message = userAddBookService.InsertUserAddBook(userAddBook);
            if (message == "Success")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Address Inserted successfully');location.href='" + @Url.Action("Index", "AddressBook") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Error Occured');location.href='" + @Url.Action("Index", "AddressBook") + "'</script>");
            }
        }
    }
}