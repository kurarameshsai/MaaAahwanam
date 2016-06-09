using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
   public class OrderReqs
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
