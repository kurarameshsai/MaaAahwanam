using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;

namespace MaaAahwanam.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        //
        // GET: /OrderDetails/
        public ActionResult Index(int id)
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {              
                ViewBag.Type = ValidUserUtility.UserType();
                OrdersListBAL orderlistbal = new OrdersListBAL();
                PaymentDetailsBAL paymentdetailsbal = new PaymentDetailsBAL();
                List<SP_ADMIN_ORDERDITEMS_USER_Result> SP_ADMIN_ORDERDITEMS = orderlistbal.OrderDetails(id);
                List<MA_Payment_Carddetails> PaymentDetails = paymentdetailsbal.PaymentDetails(id);
                var tupleModel = new Tuple<List<SP_ADMIN_ORDERDITEMS_USER_Result>, List<MA_Payment_Carddetails>>(SP_ADMIN_ORDERDITEMS, PaymentDetails);
                return View(tupleModel);
            }
            else
            {
                return View();
            }
        }
    }
}