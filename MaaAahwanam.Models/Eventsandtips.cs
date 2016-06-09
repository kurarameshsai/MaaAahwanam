using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class Eventsandtips
    {
        public int eventid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Nullable<DateTime> Eventstartdate { get; set; }
        public Nullable<DateTime> Eventenddate { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public string Person { get; set; }
        public string phone { get; set; }
        public string parameter { get; set; }

        public List<MA_EventsandTips> Eventsandtipslist;

        //*************Used in Ui********************//

        public int proceduretype { get; set; }
        public string type { get; set; }
        public string page { get; set; }
        public IEnumerable<SP_EVENT_BEAUTY_HEALTH_LIST_Result> SPEVENTBEAUTYHEALTHLIST;

        //*************Used in Ui********************//

    }
}
