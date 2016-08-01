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
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorsPhotographyRepository vendorsPhotographyRepository = new VendorsPhotographyRepository();
        public VendorsPhotography AddPhotography(VendorsPhotography vendorPhotography, Vendormaster vendorMaster)
       {
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
        public VendorsPhotography GetVendorPhotography(long id)
        {
            return vendorsPhotographyRepository.GetVendorsPhotography(id);
        }

        public VendorsPhotography UpdatesPhotography(VendorsPhotography vendorsPhotography, Vendormaster vendorMaster, long masterid)
        {
            vendorsPhotography.Status = "Active";
            vendorsPhotography.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Photography";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsPhotography =  vendorsPhotographyRepository.UpdatesPhotography(vendorsPhotography, masterid);
            return vendorsPhotography;
        }
    }
}
