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
        CartItemRepoitory cartItemRepoitory = new CartItemRepoitory();

        public List<CartItem> CartItemsList()
        {
            List<CartItem> l1 = cartItemRepoitory.CartItemList();
            return l1;
        }
        public int CartItemsCount(int UserId)
        {
            var l1 = 0;
            if (UserId != 0)
                l1 = cartItemRepoitory.CartItemList().Where(i => i.Orderedby == UserId).Count();
            return l1;
        }
        public string AddCartItem(CartItem cartItem)
        {
            string message = "";
            cartItem = cartItemRepoitory.AddCartItem(cartItem);
            if(cartItem!=null)
            {
                message="Success";
            }
            else
            {
                message = "Failed";
            }
            return message;
        }
    }
}
