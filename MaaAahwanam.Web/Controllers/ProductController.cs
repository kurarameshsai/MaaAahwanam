using MaaAahwanam.Models;
using MaaAahwanam.Repository;
using MaaAahwanam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /CardSelect/
        public ActionResult Index()
        {
            ProductService productService=new ProductService();
            string servicetypeQuerystring = Request.QueryString["par"];
            List<GetProducts_Result> Productlist = productService.GetProducts_Results(servicetypeQuerystring);
            ViewBag.ServiceType = servicetypeQuerystring;
            return View(Productlist);
        }
	}
}