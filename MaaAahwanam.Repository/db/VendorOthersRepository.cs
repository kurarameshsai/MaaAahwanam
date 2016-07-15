using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
   public class VendorOthersRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsOthersList()
        {
            return _dbContext.VendorsOther.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }

        public VendorsOther AddOthers(VendorsOther vendorsOthers)
        {
            _dbContext.VendorsOther.Add(vendorsOthers);
            _dbContext.SaveChanges();
            return vendorsOthers;
        }
    }
}
