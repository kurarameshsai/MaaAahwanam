using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
   public class ServiceResponseRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public long ServiceResponseCount(ServiceResponse serviceResponse)
        {
            return _dbContext.ServiceResponse.Where(m => m.RequestId == serviceResponse.RequestId).Count();
        }

        public List<dynamic> ServiceResponseList(ServiceResponse serviceResponse)
        {
            //return _dbContext.ServiceResponse.Where(m => m.RequestId == serviceResponse.RequestId).Join(_dbContext.Vendormaster, i => i.ResponseBy, p => p.Id, (i, p) => new { p = p, i = i }).ToList<ServiceResponse>();
            //return _dbContext.ServiceResponse.Where(m => m.RequestId == serviceResponse.RequestId).ToList();
            List<dynamic> records = (from data1 in _dbContext.ServiceResponse 
                                            join data2 in _dbContext.Vendormaster 
                                            on data1.ResponseBy equals data2.Id 
                                            where data1.RequestId == serviceResponse.RequestId
                                     select new { data2.Id, data2.BusinessName, data1.VendorType, data1.Description, data1.Amount, data1.UpdatedDate,data1.RequestId,data2.Address }).ToList<dynamic>();
            return records;
        }
    }
}
