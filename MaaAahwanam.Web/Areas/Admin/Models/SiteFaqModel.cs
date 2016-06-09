using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class SiteFaqModel
    {
        public int FaqId { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public List<MA_SiteFaq> FaqsList;
    }
}