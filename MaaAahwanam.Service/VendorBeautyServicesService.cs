using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorBeautyServicesService
    {
        public VendorsBeautyService AddBeautyService(VendorsBeautyService vendorBeautyService,Vendormaster vendorMaster)
        {
            VendormasterRepository vendorMasterRepository = new VendormasterRepository();
            VendorsBeautyServiceRepository vendorBeautyServiceRespository = new VendorsBeautyServiceRepository();
            
            vendorBeautyService.UpdatedDate = DateTime.Now;
            vendorBeautyService.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.ServicType = "Beauty Services";
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorBeautyService.VendorMasterId = vendorMaster.Id;
            vendorBeautyService = vendorBeautyServiceRespository.AddBeautyService(vendorBeautyService);
            return vendorBeautyService;
        }
    }
}
