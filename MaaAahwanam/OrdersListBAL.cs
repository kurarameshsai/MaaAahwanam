using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class OrdersListBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public List<SP_ADMIN_ORDERS_Result> OrdersListAsPerUser()
        {
            List<SP_ADMIN_ORDERS_Result> list = new List<SP_ADMIN_ORDERS_Result>();
            if (ValidUserUtility.UserType() == "User")
                list = _Repositories.sp_AdminOrders.ExecuteProcedure_WithParameters("exec SP_ADMIN_ORDERS  {0},{1}", 0, ValidUserUtility.ValidUser()).ToList();
            if (ValidUserUtility.UserType() == "Vendor")
                list = _Repositories.sp_AdminOrders.ExecuteProcedure_WithParameters("exec SP_ADMIN_ORDERS  {0},{1}", 1, ValidUserUtility.ValidUser()).ToList();
            return list;
        }
        public List<SP_ADMIN_ORDERDITEMS_USER_Result> OrderDetails(int OrderID)
        {
            List<SP_ADMIN_ORDERDITEMS_USER_Result> OrderList = new List<SP_ADMIN_ORDERDITEMS_USER_Result>();
            return _Repositories.sp_AdminOrderItems.ExecuteProcedure_WithParameters("exec SP_ADMIN_ORDERDITEMS_USER {0}", OrderID).ToList();            
        }
    }
}
