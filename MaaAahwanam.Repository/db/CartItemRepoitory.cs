using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;
using AutoMapper;

namespace MaaAahwanam.Repository.db
{
    public class CartItemRepoitory
    {
        readonly ApiContext _dbContext = new ApiContext();
        MaaAahwanamEntities maaAahwanamEntities = new MaaAahwanamEntities();
        GetCartItems_ResultModel getCartItems_ResultModel = new GetCartItems_ResultModel();
        public List<GetCartItems_Result> CartItemList(int vid)
        {
            //var cartitems1= maaAahwanamEntities.GetCartItems(vid);
            //Mapper.CreateMap<cartitems1, getCartItems_ResultModel>();
            //getCartItems_ResultModel = Mapper.Map<cartitems1, getCartItems_ResultModel>(cartitems1);
            //return getCartItems_ResultModel;
            return maaAahwanamEntities.GetCartItems(vid).ToList();
        }
        public CartItem AddCartItem(CartItem cartItem)
        {
            cartItem=_dbContext.CartItem.Add(cartItem);
            _dbContext.SaveChanges();
            return cartItem;
        }


    }
}
