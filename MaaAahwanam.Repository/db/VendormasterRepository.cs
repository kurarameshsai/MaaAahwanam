using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendormasterRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<Vendormaster> VendormasterList()
        {
            return _dbContext.Vendormaster.ToList();
        }

        public Vendormaster AddVendorMaster(Vendormaster vendorMaster)
        {
            _dbContext.Vendormaster.Add(vendorMaster);
            _dbContext.SaveChanges();
            return vendorMaster;
        }

        public Vendormaster GetVendor(long id)
        {
            return _dbContext.Vendormaster.Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
