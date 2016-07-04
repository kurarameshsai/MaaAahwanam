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
            //VendorsDecorator vendorsdecorator = new VendorsDecorator();
            _dbContext.VendorsDecorator.Add(vendorsdecorator);
            _dbContext.SaveChanges();
            return vendorsdecorator;
        }
    }
}
