using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string EmailId { get; set; }
        public string Status { get; set; }
       
    }

}
