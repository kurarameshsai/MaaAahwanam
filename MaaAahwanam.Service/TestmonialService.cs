using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;
using AutoMapper;

namespace MaaAahwanam.Service
{
    public class TestmonialService
    {
        AdminTestimonialRepository testimonialRepository = new AdminTestimonialRepository();
        AdminTestimonialPathRepository testimonialpathRepository = new AdminTestimonialPathRepository();

        public List<GetTestimonials> TestmonialServiceList()
        {
            List<dynamic> l1 = testimonialRepository.AdminTestimonialList();
            //Mapper.CreateMap<l1, GetTestimonials>();
            //Mapper.Map<l1, GetTestimonials>(l1);
            var testFile = Mapper.Map<GetTestimonials>(l1.First());
            return testFile;
        }
        public AdminTestimonial Savetestimonial(AdminTestimonial adminTestimonial)
        {
            testimonialRepository.SaveAdminTestimonial(adminTestimonial);
            return adminTestimonial;
        }
        public void Savetestimonialpath(AdminTestimonialPath adminTestimonialPath)
        {
            testimonialpathRepository.SaveAdminTestimonial(adminTestimonialPath);
        }
    }
}
