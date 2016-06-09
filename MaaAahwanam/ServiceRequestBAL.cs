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
    public class ServiceRequestBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public List<SP_ADMIN_Servicerequest_Result> ServiceRequest(string type, int? a)
        {
            if (a == null)
            {
                return _Repositories.SP_ADMIN_Servicerequest.ExecuteProcedure_WithParameters("exec SP_ADMIN_Servicerequest {0},1,null", type).ToList();
            }
            else
            {
                return _Repositories.SP_ADMIN_Servicerequest.ExecuteProcedure_WithParameters("exec SP_ADMIN_Servicerequest {0},2,{1}", type,a).ToList();
            }
        }
    }
}
