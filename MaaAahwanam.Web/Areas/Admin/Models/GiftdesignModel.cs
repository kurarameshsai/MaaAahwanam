using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class GiftdesignModel
    {
        public int giftid { get; set; }
        public string Category { get; set; }
        public string GiftName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> GiftCost { get; set; }
        public string Image { get; set; }
        public string ImageId { get; set; }
        //public string Vendorname { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string VendorID { get; set; }

        public List<MA_Giftdesigns> Giftlist;

        public List<MA_User_Vendor> VendorsList;
    }
}