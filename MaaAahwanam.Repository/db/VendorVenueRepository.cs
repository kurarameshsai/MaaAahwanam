using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
   public class VendorVenueRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsVenueList()
        {
            return _dbContext.VendorVenue.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }

        public VendorVenue AddVenue(VendorVenue vendorsVenue)
        {
            _dbContext.VendorVenue.Add(vendorsVenue);
            _dbContext.SaveChanges();
            return vendorsVenue;
        }

        public VendorVenue GetVendorVenue(long id)
        {
            return _dbContext.VendorVenue.Where(m => m.VendorMasterId == id).FirstOrDefault();
        }

        public VendorVenue UpdateVenue(VendorVenue vendorsVenue,long id)
        {
            var GetVendor = _dbContext.VendorVenue.SingleOrDefault(m => m.VendorMasterId == id);
            vendorsVenue.Id = GetVendor.Id;
            _dbContext.Entry(GetVendor).CurrentValues.SetValues(vendorsVenue);
            _dbContext.SaveChanges();
            return vendorsVenue;
        }
    }
}
