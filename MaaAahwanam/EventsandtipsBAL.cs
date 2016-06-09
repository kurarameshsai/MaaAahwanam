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
    public class EventsandtipsBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public void saveeventsandtips(Eventsandtips Eventsandtipsmodel)
        {
            MA_EventsandTips _tbl_Eventsandtips = new MA_EventsandTips();
            if (Eventsandtipsmodel.eventid != 0)
                _tbl_Eventsandtips = _Repositories.Eventsandtips.Get().Where(m => m.EventID == Eventsandtipsmodel.eventid).SingleOrDefault();
            _tbl_Eventsandtips.Title = Eventsandtipsmodel.Title;
            _tbl_Eventsandtips.Description = Eventsandtipsmodel.Description;
            _tbl_Eventsandtips.location = Eventsandtipsmodel.Location;
            _tbl_Eventsandtips.person = Eventsandtipsmodel.Person;
            _tbl_Eventsandtips.image = Eventsandtipsmodel.Image;
            _tbl_Eventsandtips.link = Eventsandtipsmodel.Link;
            _tbl_Eventsandtips.Eventstartdate = Eventsandtipsmodel.Eventstartdate;
            _tbl_Eventsandtips.Eventenddate = Eventsandtipsmodel.Eventenddate;
            _tbl_Eventsandtips.phone = Eventsandtipsmodel.phone;
            _tbl_Eventsandtips.price = Eventsandtipsmodel.Price;
            _tbl_Eventsandtips.Type = Eventsandtipsmodel.Type;
            if (Eventsandtipsmodel.eventid == 0)
                _Repositories.Eventsandtips.Add(_tbl_Eventsandtips);
            _Repositories.SaveChanges();
        }
        public List<MA_EventsandTips> geteventsandtips(String type)
        {
            var eventsandtips = new List<MA_EventsandTips>();
            eventsandtips = _Repositories.Eventsandtips.Get().Where(m => m.Type == type).ToList();
            return eventsandtips;
        }
        public List<MA_EventsandTips> geteventsandtipsitem(int id)
        {
            var eventsandtipsitem = new List<MA_EventsandTips>();
            eventsandtipsitem = _Repositories.Eventsandtips.Get().Where(m => m.EventID == id).ToList();
            return eventsandtipsitem;
        }


        //**************************------code for UI written by prasanna---------*****************************
        #region EventsAndTipsUiCode
        public IEnumerable<SP_EVENT_BEAUTY_HEALTH_LIST_Result> EventsAndTipsBindingList()
        {
            return _Repositories.SP_EVENT_BEAUTY_HEALTH_LIST.ExecuteProcedure_WithParameters("exec SP_EVENT_BEAUTY_HEALTH_LIST {0},{1}", 1, DBNull.Value).ToList();

        }
        #endregion
        #region IndexEventsCount
        public SmartCount CountDetails()
        {
            SmartCount smartcount = new SmartCount();
            smartcount.ticketscount = _Repositories.IssueTickets.GetAll().Count();
            smartcount.eventscount = _Repositories.MAEventDates.GetAll().ToList().Where(m => m.EndDate <= DateTime.Now).Distinct().Count();
            return smartcount;
        }
        #endregion
        //**************************------code for UI written by prasanna---------*****************************
    }
}
