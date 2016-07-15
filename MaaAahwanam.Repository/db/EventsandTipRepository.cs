using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class EventsandTipRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<EventsandTip> EventsandTipList()
        {
            return _dbContext.EventsandTip.ToList();
        }

        public EventsandTip AddEventsAndTip(EventsandTip eventAndTip)
        {
            _dbContext.EventsandTip.Add(eventAndTip);
            _dbContext.SaveChanges();
            return eventAndTip;
        }

        public long EventIdCount()
        {
            var EventIdCount = _dbContext.EventsandTip.DefaultIfEmpty().Max(r => r == null ? 0 : r.EventId);
            if (EventIdCount == 0)
            {
                return EventIdCount + 1;
            }
            return EventIdCount + 1;
        }
    }
}
