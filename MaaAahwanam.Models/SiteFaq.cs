using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class SiteFaq
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
