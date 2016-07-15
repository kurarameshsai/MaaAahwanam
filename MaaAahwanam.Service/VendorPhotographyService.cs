using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorPhotographyService
    {
       public VendorsPhotography AddPhotography(VendorsPhotography vendorPhotography, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorsPhotographyRepository vendorsPhotographyRepository = new VendorsPhotographyRepository();
           vendorPhotography.Status = "Active";
           vendorPhotography.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "Photography";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorPhotography.VendorMasterId = vendorMaster.Id;
           vendorPhotography = vendorsPhotographyRepository.AddPhotography(vendorPhotography);
           return vendorPhotography;
       }
    }
}
