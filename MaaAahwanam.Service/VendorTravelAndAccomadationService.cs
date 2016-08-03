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
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorsTravelandAccomodationRepository vendorsTravelandAccomodationRepository = new VendorsTravelandAccomodationRepository();
        public VendorsTravelandAccomodation AddTravelAndAccomadation(VendorsTravelandAccomodation vendorsTravelandAccomodation, Vendormaster vendorMaster)
       {
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

        public VendorsTravelandAccomodation GetVendorTravelandAccomodation(long id)
        {
            return vendorsTravelandAccomodationRepository.GetVendorTravelandAccomodation(id);
        }

        public VendorsTravelandAccomodation UpdateTravelandAccomodation(VendorsTravelandAccomodation vendorTravelandAccomodation, Vendormaster vendorMaster, long masterid)
        {
            vendorTravelandAccomodation.Status = "Active";
            vendorTravelandAccomodation.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Travel&Accomadation";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorTravelandAccomodation = vendorsTravelandAccomodationRepository.UpdateTravelandAccomodation(vendorTravelandAccomodation, masterid);
            return vendorTravelandAccomodation;
        }
    }
}
