using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class VendorImageRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<VendorImage> VendorImageList(VendorImage vendorImage)
        {
            return _dbContext.VendorImage.ToList();
        }

        public VendorImage AddVendorImage(VendorImage vendorImage)
        {
            _dbContext.VendorImage.Add(vendorImage);
            _dbContext.SaveChanges();
            return vendorImage;
        }
    }
}
