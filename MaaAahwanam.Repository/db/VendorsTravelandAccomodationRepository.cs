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

        public VendorsTravelandAccomodation AddTravelandAccomodation(VendorsTravelandAccomodation vendorsTravelandAccomodation)
        {
            _dbContext.VendorsTravelandAccomodation.Add(vendorsTravelandAccomodation);
            _dbContext.SaveChanges();
            return vendorsTravelandAccomodation;
        }
        public VendorsTravelandAccomodation GetVendorTravelandAccomodation(long id)
        {
            return _dbContext.VendorsTravelandAccomodation.Where(m => m.VendorMasterId == id).FirstOrDefault();
        }

        public VendorsTravelandAccomodation UpdateTravelandAccomodation(VendorsTravelandAccomodation vendorsTravelandAccomodation, long id)
        {
            var GetVendor = _dbContext.VendorsTravelandAccomodation.SingleOrDefault(m => m.VendorMasterId == id);
            vendorsTravelandAccomodation.Id = GetVendor.Id;
            _dbContext.Entry(GetVendor).CurrentValues.SetValues(vendorsTravelandAccomodation);
            _dbContext.SaveChanges();
            return vendorsTravelandAccomodation;
        }
    }
}
