using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class EventsandtipsService
    {
        public List<EventsandTip> EventsandTipsList()
        {
            EventsandTipRepository eventsandTipRepository = new EventsandTipRepository();
            List<EventsandTip> l1 = eventsandTipRepository.EventsandTipList();
            return l1;
        }
    }
}
