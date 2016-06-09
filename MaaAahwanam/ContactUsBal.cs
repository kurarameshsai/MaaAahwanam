using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class ContactUsBal
    {
        Maa_AhwaanamBase _Respositories = new Maa_AhwaanamBase();

        public void SavingEnquiryInfo(ContactUs contactus)
        {
            MA_Enquiry enquiry = new MA_Enquiry();
            enquiry.PersonName = contactus.PersonName;
            enquiry.SenderEmailId = contactus.SenderEmailId;
            enquiry.SenderPhone = contactus.SenderPhone;
            enquiry.EnquiryTitle = contactus.EnquiryTitle;
            enquiry.EnquiryDetails = contactus.EnquiryDetails;
            enquiry.CompanyName = contactus.CompanyName;
            enquiry.PostalCode = contactus.PostalCode;
            enquiry.Country = contactus.Country;
            enquiry.EnquiryDate = DateTime.Now;
            enquiry.EnquiryStatus = contactus.EnquiryStatus;
            enquiry.CreatedDate = DateTime.Now;
            _Respositories.Enquiry.Add(enquiry);
            _Respositories.SaveChanges();
        }
    }
}
