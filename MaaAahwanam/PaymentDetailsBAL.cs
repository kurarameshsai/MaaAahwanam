using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class PaymentDetailsBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();

        public List<MA_Payment_Carddetails> PaymentDetails(int OrderID)
        {
            return _Repositories.PaymentDetails.Get().Where(i => i.OrderID == OrderID).OrderByDescending(i => i.CreatedDate).ToList();
        }
    }
}
