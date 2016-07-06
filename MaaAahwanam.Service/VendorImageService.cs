using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorImageService
    {
       public VendorImage AddVendorImage(VendorImage vendorImage, Vendormaster vendorMaster)
       {
           //VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorImageRepository vendorImageRepository = new VendorImageRepository();
           vendorImage.Status = "Active";
           vendorImage.UpdatedDate = DateTime.Now;
           //vendorMaster.Status = "Active";
           //vendorMaster.UpdatedDate = DateTime.Now;
           //vendorMaster.ServicType = "Other";
           //vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorImage.VendorMasterId = vendorMaster.Id;
           vendorImage = vendorImageRepository.AddVendorImage(vendorImage);
           return vendorImage;
       }
    }
}
