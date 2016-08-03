using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorOthersService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorOthersRepository vendorOthersRepository = new VendorOthersRepository();
        public VendorsOther AddOther(VendorsOther vendorOther, Vendormaster vendorMaster)
       {
           vendorOther.Status = "Active";
           vendorOther.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "Other";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorOther.VendorMasterId = vendorMaster.Id;
           vendorOther = vendorOthersRepository.AddOthers(vendorOther);
           return vendorOther;
       }

        public VendorsOther GetVendorOther(long id)
        {
            return vendorOthersRepository.GetVendorOthers(id);
        }

        public VendorsOther UpdateOther(VendorsOther vendorOther, Vendormaster vendorMaster, long masterid)
        {
            vendorOther.Status = "Active";
            vendorOther.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Other";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorOther = vendorOthersRepository.UpdateOthers(vendorOther, masterid);
            return vendorOther;
        }
    }
}
