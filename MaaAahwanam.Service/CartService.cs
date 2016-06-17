using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class CartService
    {
        public List<CartItem> CartItemsList()
        {
            CartItemRepoitory cartItemRepoitory = new CartItemRepoitory();
            List<CartItem> l1 = cartItemRepoitory.CartItemList();
            return l1;
        }
        public int CartItemsCount(int UserId)
        {
            CartItemRepoitory cartItemRepoitory = new CartItemRepoitory();
            var l1 = 0;
            if (UserId != 0)
                l1 = cartItemRepoitory.CartItemList().Where(i => i.Orderedby == UserId).Count();
            return l1;
        }
    }
}
