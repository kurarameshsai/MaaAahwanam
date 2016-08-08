using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class DashboardService
    {
        DashboardRepository dashboardRepository = new DashboardRepository();

        public int VendorsCountService()
        {
            return dashboardRepository.VendorsCount();
        }

        public int CommentsCountService()
        {
            return dashboardRepository.CommentsCount();
        }

        public int TicketsCountService()
        {
            return dashboardRepository.TicketsCount();
        }

        public int OrdersCountService()
        {
            return dashboardRepository.OrdersCount();
        }

        public UserDetail AdminNameService(long id)
        {
            return dashboardRepository.AdminName(id);
        }
    }
}
