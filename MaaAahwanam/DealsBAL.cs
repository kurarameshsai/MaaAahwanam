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
    public class DealsBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public IEnumerable<SP_DEALSLIST_Result> DealsBindingLayoutList(string servicetype)
        {
            return _Repositories.SP_DEALSLIST.ExecuteProcedure_WithParameters("exec SP_DEALSLIST {0},{1}", 1, servicetype).ToList();

        }
    }
}
