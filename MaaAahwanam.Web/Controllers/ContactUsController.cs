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
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactUs contactusmodel, string submit)
        {
            try
            {
                ContactUsBal contactusbal = new ContactUsBal();
                ContactUs contactus = new ContactUs();
                contactus.PersonName = contactusmodel.PersonName;
                contactus.SenderEmailId = contactusmodel.SenderEmailId;
                contactus.SenderPhone = contactusmodel.SenderPhone;
                contactus.EnquiryTitle = contactusmodel.EnquiryTitle;
                contactus.EnquiryDetails = contactusmodel.EnquiryDetails;
                contactusmodel.EnquiryDate = contactusmodel.EnquiryDate;
                contactus.CompanyName = contactusmodel.CompanyName;
                contactus.Country = contactusmodel.Country;
                contactus.CreatedDate = contactusmodel.CreatedDate;
                contactus.EnquiryDate = contactusmodel.EnquiryDate;
                contactus.PostalCode = contactusmodel.PostalCode;
                contactusbal.SavingEnquiryInfo(contactus);
                return Content("<script language='javascript' type='text/javascript'>alert('Submitted Enquiry Successfully!');location.href='" + @Url.Action("Index", "ContactUs") + "'</script>");
            }

            catch (Exception exception)
            {
                //logs.LogTheExceptions(exception, "AddressBook/Index");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("Index", "ContactUs") + "'</script>");
            }
        }
	}
}