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
using System.Text;
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}