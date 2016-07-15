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
       public VendorsInvitationCard AddInvitationCard(VendorsInvitationCard vendorInvitationCard, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorInvitationCardsRepository vendorInvitationCardsRepository = new VendorInvitationCardsRepository();
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
    }
}
