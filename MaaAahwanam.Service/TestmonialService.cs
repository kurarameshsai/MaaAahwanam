using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class TestmonialService
    {
        public List<AdminTestimonial> TestmonialServiceList()
        {
            AdminTestimonialRepository testimonialRepository = new AdminTestimonialRepository();
            List<AdminTestimonial> l1 = testimonialRepository.AdminTestimonialList();
            return l1;
        }
    }
}
