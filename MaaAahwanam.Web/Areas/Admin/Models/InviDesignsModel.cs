using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class InviDesignsModel
    {
        public int DesignId { get; set; }
        public string Category { get; set; }
        public string DesignName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> CardCost { get; set; }
        public string Image { get; set; }
        public string ImageId { get; set; }
        public string VendorID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public List<MA_Invi_Designs> DesignsList;
        public List<MA_User_Vendor> VendorsList;
    }
}