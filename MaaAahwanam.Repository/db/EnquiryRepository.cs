using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class EnquiryRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public Enquiry SaveEnquiries(Enquiry enquiry)
        {
            _dbContext.Enquiry.Add(enquiry);
            _dbContext.SaveChanges();
            return enquiry;
        }
    }
}
