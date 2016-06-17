using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendorsBeautyServiceRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsBeautyServiceList()
        {
            return _dbContext.VendorsBeautyService.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }
    }
}
