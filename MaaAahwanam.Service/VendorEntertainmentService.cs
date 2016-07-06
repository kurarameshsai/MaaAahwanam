using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorEntertainmentService
    {
        public VendorsEntertainment AddEntertainment(VendorsEntertainment vendorEntertainment, Vendormaster vendorMaster)
        {
            VendormasterRepository vendorMasterRepository = new VendormasterRepository();
            VendorEntertainmentRepository vendorEntertainmentRespository = new VendorEntertainmentRepository();
            vendorEntertainment.Status = "Active";
            vendorEntertainment.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Entertainment";
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorEntertainment.VendorMasterId = vendorMaster.Id;
            vendorEntertainment = vendorEntertainmentRespository.AddEntertainment(vendorEntertainment);
            return vendorEntertainment;
        }
    }
}
