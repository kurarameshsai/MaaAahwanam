using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class ServiceRequestService
    {
        public ServiceRequest SaveService(ServiceRequest serviceRequest)
        {
            ServiceRequestRepository serviceRequestRepository = new ServiceRequestRepository();
            serviceRequest = serviceRequestRepository.SaveQuotation(serviceRequest);
            return serviceRequest;
        }
    }
}
