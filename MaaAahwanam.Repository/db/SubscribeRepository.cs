using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class SubscribeRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public void SavingSubscriptionEmailId(Subscription subscription)
        {
            _dbContext.Subscription.Add(subscription);
            _dbContext.SaveChanges();
        }
    }
}
