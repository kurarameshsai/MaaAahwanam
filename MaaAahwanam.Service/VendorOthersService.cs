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
       public VendorsOther AddOther(VendorsOther vendorOther, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorOthersRepository vendorOthersRepository = new VendorOthersRepository();
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
    }
}
