using MaaAahwanam.Repository;
using MaaAahwanam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaaAahwanam.Web.Controllers
{
    public class AllServicesController : Controller
    {
        ProductService productService = new ProductService();
        // GET: AllServices
        public ActionResult Index()
        {
            List<GetProducts_Result> Productlist_Venue = productService.GetProducts_Results("Venue", 0);
            List<GetProducts_Result> Productlist_Catering = productService.GetProducts_Results("Catering", 0);
            List<GetProducts_Result> Productlist_Decorator = productService.GetProducts_Results("Decorator", 0);
            List<GetProducts_Result> Productlist_Photography = productService.GetProducts_Results("Photography", 0);
            ViewBag.Venue = Productlist_Venue;
            ViewBag.Catering = Productlist_Catering;
            ViewBag.Decorator = Productlist_Decorator;
            ViewBag.Photography = Productlist_Photography;
            return View();
        }
    }
}