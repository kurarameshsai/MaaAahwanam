using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam.Bal
{
   public class CartViewBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();

        public IEnumerable<SP_CART_ITEMSVIEW_Result> CartItemsViewList(int userid)
        {
            return _Repositories.SP_CART_ITEMSVIEW.ExecuteProcedure_WithParameters("exec SP_CART_ITEMSVIEW {0},{1}", userid, 1).ToList();
        }
        public decimal CartItemsViewListtotalPrice(int userid)
        {
            var t = _Repositories.SP_CART_ITEMSVIEW.ExecuteProcedure_WithParameters("exec SP_CART_ITEMSVIEW {0},{1}", userid, 1).ToList().Select(m => m.TotalPrice).FirstOrDefault();

            return Convert.ToDecimal(t);
        }
    }
}
