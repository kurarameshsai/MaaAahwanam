using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class ContactUs
    {

        public int EnquiryId { get; set; }
        public string PersonName { get; set; }
        public string SenderEmailId { get; set; }
        public string SenderPhone { get; set; }
        public string EnquiryTitle { get; set; }
        public string EnquiryDetails { get; set; }
        public System.DateTime EnquiryDate { get; set; }
        public string EnquiryStatus { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string CompanyName { get; set; }
        public System.DateTime CreatedDate { get; set; }

    }
}
