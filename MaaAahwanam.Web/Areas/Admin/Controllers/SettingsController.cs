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
    public class SettingsController : Controller
    {
        LogsUtility logs = new LogsUtility();

        //
        // GET: /ServiceRequest/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SiteFaq(SiteFaqModel model, int? id)
        {
            SiteFaqBal sitefaqbal = new SiteFaqBal();
            model.FaqsList = sitefaqbal.FaqsList();
            if (id != null)
            {
                var faqslist = sitefaqbal.SiteFaq(id ?? 0).FirstOrDefault();
                model.FaqId = faqslist.FaqId;
                model.Category = faqslist.Category;
                model.Question = faqslist.Question;
                model.Answer = faqslist.Answer;
            }
            return View(model);
        }

         [ValidateInput(false)]
        public ActionResult save(SiteFaqModel model,int? id)
        {
            try
            {
                SiteFaqBal sitefaqbal = new SiteFaqBal();
                SiteFaq sitefaq = new SiteFaq();
                id = model.FaqId;
                if (id != 0) sitefaq.FaqId = id ?? 0;
                sitefaq.Category = model.Category;
                sitefaq.Question = model.Question;
                sitefaq.Answer = model.Answer;
                sitefaqbal.Savefaq(sitefaq);
                logs.LogEvents("FaqSaved successfully", "Settings/SiteFaq", ValidUserUtility.ValidUser());
                 return Content("<script language='javascript' type='text/javascript'>alert('Design Saved  Successfully!');location.href='" + @Url.Action("SiteFaq", "Settings") + "'</script>");

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("SiteFaq");
        }
   
	}
}