using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorVenueService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorVenueRepository vendorVenueRepository = new VendorVenueRepository();
        public VendorVenue AddVenue(VendorVenue vendorVenue, Vendormaster vendorMaster)
       {
           vendorVenue.Status = "Active";
           vendorVenue.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "Venue";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorVenue.VendorMasterId = vendorMaster.Id;
           vendorVenue = vendorVenueRepository.AddVenue(vendorVenue);
           return vendorVenue;
       }

        public VendorVenue GetVendorVenue(long id)
        {
            return vendorVenueRepository.GetVendorVenue(id);
        }

        public VendorVenue UpdateVenue(VendorVenue vendorVenue, Vendormaster vendorMaster, VendorVenue GetVendor, Vendormaster GetMaster)
        {
            vendorVenue.Status = "Active";
            vendorVenue.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Venue";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster,GetMaster);
            vendorVenue.VendorMasterId = vendorMaster.Id;
            vendorVenue = vendorVenueRepository.UpdateVenue(vendorVenue,GetVendor);
            return vendorVenue;
        }
    }
}
