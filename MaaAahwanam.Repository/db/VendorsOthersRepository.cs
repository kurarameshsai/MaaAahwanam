using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Models;
using System.Data.SqlClient;

namespace MaaAahwanam.Repository.db
{
    public class VendorsOthersRepository
    {
        readonly ApiContext _dbContext = new ApiContext();
        MaaAahwanamEntities3 maaAahwanamEntities = new MaaAahwanamEntities3();
        public List<GetProducts_Result> GetProducts_Results(string parameters)
        {
            return maaAahwanamEntities.GetProducts(parameters).ToList();
        }

        //Product info page
        public GetProductsInfo_Result getProductsInfo(int vid,string servicetype)
        {
            var a= maaAahwanamEntities.GetProductsInfo(vid,servicetype).FirstOrDefault();
            return a;
        }
    }
}
