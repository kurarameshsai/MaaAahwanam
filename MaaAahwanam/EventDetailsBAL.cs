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
    public class EventDetailsBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public List<SP_EVENTDETAILSANDEVENTDATES_Result> EventsListAsPerEventID(int EventID)
        {
            return _Repositories.sp_EventDetailsAndEventDates.ExecuteProcedure_WithParameters("exec SP_EVENTDETAILSANDEVENTDATES  {0}", 0).ToList();
        }
        public List<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result> CountsOfEventsAndNotifications()
        {
            return _Repositories.sp_CountsOfTicketsAndNotifications.ExecuteProcedure_WithParameters("exec SP_COUNTS_TICKETS_AND_NOTIFICATIONS  {0}", ValidUserUtility.ValidUser()).ToList();
        }
    }
}
