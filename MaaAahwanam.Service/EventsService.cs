using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class EventsService
    {
        public List<EventInformation> EventInformationList()
        {
            EventInformationRepository eventInformationRepository = new EventInformationRepository();
            List<EventInformation> l1 = eventInformationRepository.EventInformationList();
            return l1;
        }
    }
}
