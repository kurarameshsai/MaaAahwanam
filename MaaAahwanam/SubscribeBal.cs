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
    public class SubscribeBal
    {
        Maa_AhwaanamBase _Respositories = new Maa_AhwaanamBase();
        public void SavingSubscriptionEmailId(Subscription subscription)
        {
            MA_Subscription subscribe = new MA_Subscription();
            subscribe.EmailId = subscription.EmailId;
            subscribe.Status = subscription.Status;
            _Respositories.Subscription.Add(subscribe);
            _Respositories.SaveChanges();
        }
    }
}
