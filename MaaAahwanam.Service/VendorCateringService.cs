using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorCateringService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorCateringRepository vendorCateringRespository = new VendorCateringRepository();
        public VendorsCatering AddCatering(VendorsCatering vendorCatering, Vendormaster vendorMaster)
        {
            vendorCatering.Status = "Active";
            vendorCatering.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Catering";
                vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
                vendorCatering.VendorMasterId = vendorMaster.Id;
                vendorCatering = vendorCateringRespository.AddCatering(vendorCatering);
            return vendorCatering;
        }
        public VendorsCatering GetVendorCatering(long id)
        {
            return vendorCateringRespository.GetVendorsCatering(id);
        }

        public VendorsCatering UpdatesCatering(VendorsCatering vendorsCatering, Vendormaster vendorMaster, long masterid)
        {
            vendorsCatering.Status = "Active";
            vendorsCatering.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Catering";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsCatering = vendorCateringRespository.UpdatesCatering(vendorsCatering, masterid);
            return vendorsCatering;
        }
    }
}
