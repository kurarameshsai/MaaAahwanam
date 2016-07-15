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
           VendorImageRepository vendorImageRepository = new VendorImageRepository();
           vendorImage.Status = "Active";
           vendorImage.UpdatedDate = DateTime.Now;
           vendorImage.VendorMasterId = vendorMaster.Id;
           vendorImage = vendorImageRepository.AddVendorImage(vendorImage);
           return vendorImage;
       }
    }
}
