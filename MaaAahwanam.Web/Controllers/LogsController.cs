using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using MaaAahwanam.Bal;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Controllers
{
    public class LogsController : Controller
    {
        //
        // GET: /Logs/


        public ActionResult Index()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");//
                string r = client.DownloadString("http://localhost:8566/server/api/login/OrdersListAsPerUser");     
                JArray json = JArray.Parse(r);
                List<SP_ADMIN_ORDERS_Result> JSONParsedlist = json.ToObject<List<SP_ADMIN_ORDERS_Result>>();               
            }
            return View();
        }
    }
}