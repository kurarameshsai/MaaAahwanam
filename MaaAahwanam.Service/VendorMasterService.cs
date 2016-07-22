using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class VendorMasterService
    {
        VendormasterRepository vendormasterRepository = new VendormasterRepository();
        public Vendormaster GetVendor(long id)
        {
            return vendormasterRepository.GetVendor(id);
        }
    }
}
