using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class CartItemRepoitory
    {
        readonly ApiContext _dbContext = new ApiContext();
        public List<CartItem> CartItemList()
        {
            return _dbContext.CartItem.ToList();
        }
    }
}
