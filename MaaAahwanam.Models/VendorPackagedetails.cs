using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
    public class VendorPackagedetails
    {
        //Vendor_Packages
        public int UserBusiId { get; set; }
        public int vendorpackageID { get; set; }
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
