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

namespace MaaAahwanam.Web.Controllers
{
    public class AddressBookController : Controller
    {
        //
        // GET: /AddressBook/
        public ActionResult Index(UserAddBook addbookmodel)
        {
            try
            {
                if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
                {
                    ViewBag.Type = ValidUserUtility.UserType();
                }
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    UserAddressBookBal useraddbookbal = new UserAddressBookBal();
                    addbookmodel.sp_AddressBook1 = useraddbookbal.Addressbook(uservalidity);
                    return View(addbookmodel);
                }
                else
                {
                    return RedirectToAction("Index", "Signin");
                }
            }
            catch (Exception exception)
            {
                //logs.LogTheExceptions(exception, "Tickets/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "Signin") + "'</script>");
            }
        }
        [HttpPost]
        public ActionResult Index(UserAddBook addbookmodel, string submit)
        {
            try
            {
                UserAddressBookBal useraddbookbal = new UserAddressBookBal();
                UserAddBook useraddbook = new UserAddBook();
                useraddbook.PersonName = addbookmodel.PersonName;
                useraddbook.PersonPhone = addbookmodel.PersonPhone;
                useraddbook.PersonEmail = addbookmodel.PersonEmail;
                useraddbook.PersonLocation = addbookmodel.PersonLocation;
                useraddbook.PersonAddress = addbookmodel.PersonAddress;
                useraddbook.PersonCity = addbookmodel.PersonCity;
                useraddbookbal.SavingAddressBookDetails(useraddbook);
                //logs.LogEvents("Address Saved Successfully", "AddressBook/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Address Saved Successfully!');location.href='" + @Url.Action("Index", "AddressBook") + "'</script>");
            }

            catch (Exception exception)
            {
                //logs.LogTheExceptions(exception, "AddressBook/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "AddressBook") + "'</script>");
            }
        }
    }
}