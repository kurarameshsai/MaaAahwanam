using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class AdminTestimonialRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> AdminTestimonialList()
        {
            var list = (from p in _dbContext.AdminTesimonial
                        join r in _dbContext.AdminTestimonialPath
                         on p.Id equals r.Id
                        select new
                        {
                            id = p.Id,
                            name = p.Name,
                            email = p.Email,
                            Description = p.Description,
                            image = r.ImagePath
                        }).Take(1).ToList<dynamic>();
            //List<GetTestimonials> list1 = new List<GetTestimonials>();
            //foreach (var item in list)
            //{
                //list1 = item.Id;
            //}
            return list;

            //return _dbContext.AdminTesimonial.ToList<dynamic>();
        }
        public AdminTestimonial SaveAdminTestimonial(AdminTestimonial adminTestimonial)
        {
            _dbContext.AdminTesimonial.Add(adminTestimonial);
            _dbContext.SaveChanges();
            return adminTestimonial;
        }
    }
}
