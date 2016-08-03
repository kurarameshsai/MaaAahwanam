using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorEventOrganiserService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorEventOrganiserRepository vendorEventOrganiserRepository = new VendorEventOrganiserRepository();
        public VendorsEventOrganiser AddEventOrganiser(VendorsEventOrganiser vendorEventOrganiser, Vendormaster vendorMaster)
        {
            vendorEventOrganiser.Status = "Active";
            vendorEventOrganiser.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "EventOrganiser";
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorEventOrganiser.VendorMasterId = vendorMaster.Id;
            vendorEventOrganiser = vendorEventOrganiserRepository.AddEventOrganiser(vendorEventOrganiser);
            return vendorEventOrganiser;
        }
        public VendorsEventOrganiser GetVendorEventOrganiser(long id)
        {
            return vendorEventOrganiserRepository.GetVendorEventOrganiser(id);
        }

        public VendorsEventOrganiser UpdateEventOrganiser(VendorsEventOrganiser vendorsEventOrganiser, Vendormaster vendorMaster, long masterid)
        {
            vendorsEventOrganiser.Status = "Active";
            vendorsEventOrganiser.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "EventOrganiser";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsEventOrganiser = vendorEventOrganiserRepository.UpdateEventOrganiser(vendorsEventOrganiser, masterid);
            return vendorsEventOrganiser;
        }
    }
}
