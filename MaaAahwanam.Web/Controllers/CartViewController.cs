using MaaAahwanam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Service;
using MaaAahwanam.Utility;

namespace MaaAahwanam.Web.Controllers
{
    public class CartViewController : Controller
    {
        CartService cartService = new CartService();
        //
        // GET: /CartView/
        public ActionResult Index()
        {
            if (ValidUserUtility.ValidUser() != 0 && (ValidUserUtility.UserType() == "User" || ValidUserUtility.UserType() == "Vendor"))
            {
                int vid = ValidUserUtility.ValidUser();
                List<GetCartItems_Result> cartlist = cartService.CartItemsList(vid);
                decimal total = cartlist.Sum(s => s.TotalPrice);
                ViewBag.Cartlist = cartlist;
                ViewBag.Total = total;
                return View();
            }
            return RedirectToAction("index", "Signin");
        }
	}
}