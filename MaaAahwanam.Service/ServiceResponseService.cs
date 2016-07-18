using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;
using MaaAahwanam.Repository;
using System.Data.SqlClient;

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
        public List<MaaAahwanam_Services_Bidding_Result> GetServiceResponseList(long id)
        {
            ServiceResponseRepository serviceResponseRepository = new ServiceResponseRepository();
            return serviceResponseRepository.ServiceResponseList(id);
        }

        public List<ServiceResponse> GetQuotationList(ServiceResponse serviceResponse)
        {
            ServiceResponseRepository serviceResponseRepository = new ServiceResponseRepository();
            return serviceResponseRepository.GetQuotationList(serviceResponse);
        }
    }
}
