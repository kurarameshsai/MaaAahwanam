using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendorsTravelandAccomodationRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsTravelandAccomodationList()
        {
            return _dbContext.VendorsTravelandAccomodation.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }
    }
}
