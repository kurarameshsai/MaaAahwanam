using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using System.ComponentModel.DataAnnotations;

namespace MaaAahwanam.Models
{
    public class CartViewItemDetails
    {
      public int cartlistcount { get; set; }
      [DisplayFormat(DataFormatString = "{0:F2}")]
      public decimal TotalPrice { get; set; }

      public  IEnumerable<SP_CART_ITEMSVIEW_Result> cartlist;
    }
}
