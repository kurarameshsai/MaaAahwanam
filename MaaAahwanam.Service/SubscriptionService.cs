using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;
using MaaAahwanam.Repository.db;

namespace MaaAahwanam.Service
{
    public class SubscriptionService
    {
        public string addsubscription(Subscription subcription)
        {
            string response;
            SubscribeRepository subscribeRepository = new SubscribeRepository();
            try
            {
                subscribeRepository.SavingSubscriptionEmailId(subcription);
                response = "sucess";
            }
            catch (Exception ex)
            {
                response = "failure";
            }
            return response;
        }
    }
}
