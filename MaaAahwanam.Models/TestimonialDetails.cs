using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class TestimonialDetails
    {
        public int ntype { get; set; }
        public IEnumerable<SP_TESTIMONIALSLIST_Result> testmonialslist;
    }
}
