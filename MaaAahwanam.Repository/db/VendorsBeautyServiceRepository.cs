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

        public VendorsBeautyService AddBeautyService(VendorsBeautyService vendorsBeautyService)
        {
            _dbContext.VendorsBeautyService.Add(vendorsBeautyService);
            _dbContext.SaveChanges();
            return vendorsBeautyService;
        }

        public VendorsBeautyService GetVendorsBeautyService(long id)
        {
            return _dbContext.VendorsBeautyService.Where(m => m.VendorMasterId == id).FirstOrDefault();
        }

        public VendorsBeautyService UpdatesBeautyService(VendorsBeautyService vendorsBeautyService, long id)
        {
            var GetVendor = _dbContext.VendorsBeautyService.SingleOrDefault(m => m.VendorMasterId == id);
            vendorsBeautyService.Id = GetVendor.Id;
            _dbContext.Entry(GetVendor).CurrentValues.SetValues(vendorsBeautyService);
            _dbContext.SaveChanges();
            return vendorsBeautyService;
        }
    }
}
