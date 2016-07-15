using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorTravelAndAccomadationService
    {
       public VendorsTravelandAccomodation AddTravelAndAccomadation(VendorsTravelandAccomodation vendorsTravelandAccomodation, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorsTravelandAccomodationRepository vendorsTravelandAccomodationRepository = new VendorsTravelandAccomodationRepository();
           vendorsTravelandAccomodation.Status = "Active";
           vendorsTravelandAccomodation.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "Travel&Accomadation";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorsTravelandAccomodation.VendorMasterId = vendorMaster.Id;
           vendorsTravelandAccomodation = vendorsTravelandAccomodationRepository.AddTravelandAccomodation(vendorsTravelandAccomodation);
           return vendorsTravelandAccomodation;
       }
    }
}
