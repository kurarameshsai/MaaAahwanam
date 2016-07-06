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
       public VendorsGift AddGift(VendorsGift vendorGift, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorGiftsRepository vendorGiftsRepository = new VendorGiftsRepository();
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
    }
}
