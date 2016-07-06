using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
   public class VendorInvitationCardsRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsInvitationCardsList()
        {
            return _dbContext.VendorsInvitationCard.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }

        public VendorsInvitationCard AddInvitationCards(VendorsInvitationCard vendorsInvitationCards)
        {
            _dbContext.VendorsInvitationCard.Add(vendorsInvitationCards);
            _dbContext.SaveChanges();
            return vendorsInvitationCards;
        }
    }
}
