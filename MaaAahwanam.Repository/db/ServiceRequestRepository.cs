using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class ServiceRequestRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public ServiceRequest SaveQuotation(ServiceRequest serviceRequest)
        {
            _dbContext.ServiceRequest.Add(serviceRequest);
            _dbContext.SaveChanges();
            return serviceRequest;
        }

        public List<ServiceRequest> ServiceRequestList(ServiceRequest serviceRequest)
        {
            return _dbContext.ServiceRequest.Where(m => m.Type == serviceRequest.Type).ToList();
        }

        public List<ServiceRequest> ServiceRequestRecord(ServiceRequest serviceRequest)
        {
            return _dbContext.ServiceRequest.Where(m => m.RequestId == serviceRequest.RequestId).ToList();
        }
    }
}
