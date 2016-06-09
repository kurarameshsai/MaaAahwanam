using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class BuyNowModel
    {
        public int BuyNowReqDetId { get; set; }
        public int BuyNowReqId { get; set; }
        public int UserLoginId { get; set; }
        public string UserName { get; set; }      
        public System.DateTime ReqDate { get; set; }
        public System.DateTime EventDate { get; set; }
        public string EventAddress { get; set; }
        public string EventLocation { get; set; }
        public string EventCity { get; set; }
        public int UserBusiId { get; set; }
        public string EventName { get; set; }
        public string EventDates { get; set; }
        public Nullable<System.TimeSpan> EventStartTime { get; set; }
        public Nullable<System.TimeSpan> EventEndTime { get; set; }
        public string Status { get; set; }
        public string ServiceType { get; set; }

        public string BusinessName { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessPhLand { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessLocation { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessZIP { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessState { get; set; }

        public string UserImgId { get; set; }

        public List<VendorDetails> VendorList;
    }
}