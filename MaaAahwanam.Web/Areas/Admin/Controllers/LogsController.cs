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
    public class LogsController : Controller
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        //
        // GET: /Admin/Logs/
        public ActionResult Index()
        {
           
            List<MA_ExceptionLogs> logslist = new List<MA_ExceptionLogs>();
            logslist = _Repositories.ExceptionLogs.Get().ToList();
            return View(logslist);
        }

	}
}