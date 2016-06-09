using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class DealsDetails
    {
        public string Servicetype { get; set; }
       public IEnumerable<SP_DEALSLIST_Result> deallist;
    }
}
