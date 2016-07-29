using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendorsDecoratorRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsDecoratorList()
        {
            return _dbContext.VendorsDecorator.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();
        }

        public VendorsDecorator AddDecorator(VendorsDecorator vendorsdecorator)
        {
            _dbContext.VendorsDecorator.Add(vendorsdecorator);
            _dbContext.SaveChanges();
            return vendorsdecorator;
        }
        public VendorsDecorator GetVendorDecorator(long id)
        {
            return _dbContext.VendorsDecorator.Where(m => m.VendorMasterId == id).FirstOrDefault();
        }

        public VendorsDecorator UpdateDecorator(VendorsDecorator vendorsDecorator, long id)
        {
            var GetVendor = _dbContext.VendorsDecorator.SingleOrDefault(m => m.VendorMasterId == id);
            vendorsDecorator.Id = GetVendor.Id;
            _dbContext.Entry(GetVendor).CurrentValues.SetValues(vendorsDecorator);
            _dbContext.SaveChanges();
            return vendorsDecorator;
        }
    }
}
