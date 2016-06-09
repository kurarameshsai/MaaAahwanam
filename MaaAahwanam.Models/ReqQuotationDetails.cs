using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
    public class ReqQuotationDetails
    {
        public int QuotationReqId { get; set; }
        public int UserLoginId { get; set; }
        public System.DateTime RequestDate { get; set; }
        public string EventDates { get; set; }
        public decimal Budget { get; set; }
        public string Services { get; set; }
        public bool EventMgnt { get; set; }
        public string EventAddress { get; set;}
        public string EventLocation { get; set; }
        public string EventCity { get; set; }
        public string Preference { get; set; }
        public string EventName { get; set; }

        public string Status { get; set; }

        public Nullable<System.TimeSpan> EventStartTime { get; set; }
        public Nullable<System.TimeSpan> EventEndTime { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }   
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string UserPhone { get; set; }
    
    }
}
