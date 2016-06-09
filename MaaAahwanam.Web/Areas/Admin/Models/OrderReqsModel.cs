using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class OrderReqsModel
    {
        public int OrderId { get; set; }
        public int RequestId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal PaidAmount { get; set; }      
       
    }
}