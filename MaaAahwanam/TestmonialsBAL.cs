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
    public class TestmonialsBAL
    {

        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();

        public IEnumerable<SP_TESTIMONIALSLIST_Result> TestmonialsViewList(int ntype)
        {
            if (ntype == 1)
            {
                return _Repositories.SP_TESTIMONIALSLIST.ExecuteProcedure_WithParameters("exec SP_TESTIMONIALSLIST {0}", 1).ToList();
            }
            else
            {
                return _Repositories.SP_TESTIMONIALSLIST.ExecuteProcedure_WithParameters("exec SP_TESTIMONIALSLIST {0}", 2).ToList();
            }
        }
    }
}
