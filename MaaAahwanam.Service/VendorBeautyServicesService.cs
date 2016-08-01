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
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorsBeautyServiceRepository vendorBeautyServiceRespository = new VendorsBeautyServiceRepository();
        public VendorsBeautyService AddBeautyService(VendorsBeautyService vendorBeautyService,Vendormaster vendorMaster)
        {
            vendorBeautyService.UpdatedDate = DateTime.Now;
            vendorBeautyService.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.ServicType = "BeautyServices";
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorBeautyService.VendorMasterId = vendorMaster.Id;
            vendorBeautyService = vendorBeautyServiceRespository.AddBeautyService(vendorBeautyService);
            return vendorBeautyService;
        }
        public VendorsBeautyService GetVendorBeautyService(long id)
        {
            return vendorBeautyServiceRespository.GetVendorsBeautyService(id);
        }

        public VendorsBeautyService UpdatesBeautyService(VendorsBeautyService vendorsBeautyService, Vendormaster vendorMaster, long masterid)
        {
            vendorsBeautyService.Status = "Active";
            vendorsBeautyService.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "BeautyServices";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsBeautyService = vendorBeautyServiceRespository.UpdatesBeautyService(vendorsBeautyService, masterid);
            return vendorsBeautyService;
        }
    }
}
