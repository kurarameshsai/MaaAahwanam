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
       public VendorVenue AddVenue(VendorVenue vendorVenue, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorVenueRepository vendorVenueRepository = new VendorVenueRepository();
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
    }
}
