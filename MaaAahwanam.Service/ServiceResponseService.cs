using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class ServiceResponseService
    {
        public long ServiceResponseCount(ServiceResponse serviceResponse)
        {
            ServiceResponseRepository serviceResponseRepository = new ServiceResponseRepository();
            return serviceResponseRepository.ServiceResponseCount(serviceResponse);
        }

        //public List<dynamic> GetServiceResponseList(ServiceResponse serviceResponse)
        //{
        //    ServiceResponseRepository serviceResponseRepository = new ServiceResponseRepository();
        //    return serviceResponseRepository.ServiceResponseList(serviceResponse);
        //}
        public List<dynamic> GetServiceResponseList(ServiceResponse serviceResponse)
        {
            ServiceResponseRepository serviceResponseRepository = new ServiceResponseRepository();
            return serviceResponseRepository.ServiceResponseList(serviceResponse);
        }
    }
}
