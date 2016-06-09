using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class InvitationRequestModel
    {
        public int InvitationReqId { get; set; }
        public int UserLoginId { get; set; }
        public System.DateTime RequestDate { get; set; }
        public string EventDates { get; set; }
        public string InvitationType { get; set; }
        public string ServiceType { get; set; }
        public string EventLocation { get; set; }
        public string EventCity { get; set; }
        public string EventName { get; set; }

        public string Status { get; set; }

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