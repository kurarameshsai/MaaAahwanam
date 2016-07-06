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
        public VendorsCatering AddCatering(VendorsCatering vendorCatering, Vendormaster vendorMaster)
        {
            VendormasterRepository vendorMasterRepository = new VendormasterRepository();
            VendorCateringRepository vendorCateringRespository = new VendorCateringRepository();
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
    }
}
