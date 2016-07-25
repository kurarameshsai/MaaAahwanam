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
        VendorImageRepository vendorImageRepository = new VendorImageRepository();
        public VendorImage AddVendorImage(VendorImage vendorImage, Vendormaster vendorMaster)
       {
           vendorImage.Status = "Active";
           vendorImage.UpdatedDate = DateTime.Now;
           vendorImage.VendorMasterId = vendorMaster.Id;
           vendorImage = vendorImageRepository.AddVendorImage(vendorImage);
           return vendorImage;
       }

        public List<string> GetVendorImagesService(long id)
        {
            return vendorImageRepository.GetVendorImages(id);
        }
        public string DeleteImage(VendorImage vendorImage)
        {
            return vendorImageRepository.DeleteImage(vendorImage);
        }
    }
}
