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
    public class AdminDashboardBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public List<MA_Admin_dashboardcounts_Result> dashboardcounts()
        {
            return _Repositories.MA_Admin_Dashboardcounts.ExecuteProcedure("exec MA_Admin_dashboardcounts").ToList();
        }
    }
}
