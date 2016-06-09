﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class VendorDetails
    {
        public int UserBusiId { get; set; }
        public int UserLoginId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessDesc { get; set; }
        public System.DateTime BusinessEstDate { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessPhLand { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessLocation { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessZIP { get; set; }
        public string ServiceType { get; set; }
        public int Experience { get; set; }
        public string BusinessUrl { get; set; }
        public string BusinessStatus { get; set; }
        public string BusinessEmail { get; set; }
        public Nullable<System.DateTime> Requestdate { get; set; }
        public string BusinessState { get; set; }
        public string TermsandConditions { get; set; }
        public Nullable<bool> BookNow { get; set; }
        public Nullable<bool> Quotation { get; set; }
        public Nullable<bool> Bidding { get; set; }

        public int UserBusiAminitiesId { get; set; }
        public string UserExperiance { get; set; }
        public string UserAminitiesType { get; set; }
        public string Category { get; set; }
        public Nullable<bool> PostWedding { get; set; }
        public Nullable<bool> PreWedding { get; set; }

        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string UserImgId { get; set; }


        //Vendor_Packages
        public string packagename { get; set; }
        public string description { get; set; }
        public DateTime PackageStartDate { get; set; }
        public DateTime PackageEndDate { get; set; }
        public decimal actualamount { get; set; }
        public decimal sellingamount { get; set; }
        public decimal dealamount { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int updatedby { get; set; }
        public DateTime updateddate { get; set; }
    }
}