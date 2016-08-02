using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorGiftService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorGiftsRepository vendorGiftsRepository = new VendorGiftsRepository();
        public VendorsGift AddGift(VendorsGift vendorGift, Vendormaster vendorMaster)
       {
           vendorGift.Status = "Active";
           vendorGift.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "Gifts";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorGift.VendorMasterId = vendorMaster.Id;
           vendorGift = vendorGiftsRepository.AddGifts(vendorGift);
           return vendorGift;
       }
        public VendorsGift GetVendorGift(long id)
        {
            return vendorGiftsRepository.GetVendorsGift(id);
        }

        public VendorsGift UpdatesGift(VendorsGift vendorsGift, Vendormaster vendorMaster, long masterid)
        {
            vendorsGift.Status = "Active";
            vendorsGift.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Gifts";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsGift = vendorGiftsRepository.UpdatesGift(vendorsGift, masterid);
            return vendorsGift;
        }
    }
}
