using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
   public class VendorGiftsRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<dynamic> VendorsGiftsList()
        {
            return _dbContext.VendorsGift.Join(_dbContext.Vendormaster, i => i.VendorMasterId, p => p.Id, (i, p) => new { p = p, i = i }).ToList<dynamic>();

        }

        public VendorsGift AddGifts(VendorsGift vendorsGift)
        {
            _dbContext.VendorsGift.Add(vendorsGift);
            _dbContext.SaveChanges();
            return vendorsGift;
        }
    }
}
