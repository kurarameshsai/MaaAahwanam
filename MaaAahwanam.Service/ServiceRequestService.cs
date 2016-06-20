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
        public string SaveService(ServiceRequest serviceRequest)
        {
            string Response;
            try
            {
            ServiceRequestRepository serviceRequestRepository = new ServiceRequestRepository();
            serviceRequestRepository.SaveQuotation(serviceRequest);
            Response = "Success";
            }
            catch
            {
                Response = "Failed";
            }
            return Response;
        }
    }
}
