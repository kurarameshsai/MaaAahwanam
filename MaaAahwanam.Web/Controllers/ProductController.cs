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
            List<GetProducts_Result> Productlist = productService.GetProducts_Results(servicetypeQuerystring,0);
            ViewBag.ServiceType = servicetypeQuerystring;
            return View(Productlist);
        }
        public JsonResult Loadmore(string VID, string servicetypeQuerystring)
        {
            ProductService productService = new ProductService();
            List<GetProducts_Result> Productlist = productService.GetProducts_Results(servicetypeQuerystring, int.Parse(VID));
            ViewBag.ServiceType = servicetypeQuerystring;
            return Json(Productlist);
        }
    }
}