using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorInvitationCardsService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorInvitationCardsRepository vendorInvitationCardsRepository = new VendorInvitationCardsRepository();
        public VendorsInvitationCard AddInvitationCard(VendorsInvitationCard vendorInvitationCard, Vendormaster vendorMaster)
       {
           vendorInvitationCard.Status = "Active";
           vendorInvitationCard.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "InvitationCard";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorInvitationCard.VendorMasterId = vendorMaster.Id;
           vendorInvitationCard = vendorInvitationCardsRepository.AddInvitationCards(vendorInvitationCard);
           return vendorInvitationCard;
       }
        public VendorsInvitationCard GetVendorInvitationCard(long id)
        {
            return vendorInvitationCardsRepository.GetVendorsInvitationCard(id);
        }

        public VendorsInvitationCard UpdatesInvitationCard(VendorsInvitationCard vendorsInvitationCard, Vendormaster vendorMaster, long masterid)
        {
            vendorsInvitationCard.Status = "Active";
            vendorsInvitationCard.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "InvitationCard";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsInvitationCard = vendorInvitationCardsRepository.UpdatesInvitationCard(vendorsInvitationCard, masterid);
            return vendorsInvitationCard;
        }
    }
}
