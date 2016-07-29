using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendorCateringRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsCateringList()
        {
            return _dbContext.VendorsCatering.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }

        public VendorsCatering AddCatering(VendorsCatering vendorsCatering)
        {
            _dbContext.VendorsCatering.Add(vendorsCatering);
            _dbContext.SaveChanges();
            return vendorsCatering;
        }

        public VendorsCatering GetVendorsCatering(long id)
        {
            return _dbContext.VendorsCatering.Where(m => m.VendorMasterId == id).FirstOrDefault();
        }

        public VendorsCatering UpdatesCatering(VendorsCatering vendorsCatering, long id)
        {
            var GetVendor = _dbContext.VendorsCatering.SingleOrDefault(m => m.VendorMasterId == id);
            vendorsCatering.Id = GetVendor.Id;
            _dbContext.Entry(GetVendor).CurrentValues.SetValues(vendorsCatering);
            _dbContext.SaveChanges();
            return vendorsCatering;
        }
    }
}
