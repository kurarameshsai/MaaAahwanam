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
       public VendorsEventOrganiser AddEventOrganiser(VendorsEventOrganiser vendorEventOrganiser, Vendormaster vendorMaster)
        {
            VendormasterRepository vendorMasterRepository = new VendormasterRepository();
            VendorEventOrganiserRepository vendorEventOrganiserRepository = new VendorEventOrganiserRepository();
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
    }
}
