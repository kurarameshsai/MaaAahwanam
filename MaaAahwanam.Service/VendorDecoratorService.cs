using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class VendorDecoratorService
    {
        public VendorsDecorator AddDecorator(VendorsDecorator vendorsdecorator,Vendormaster vendorMaster)
        {
            VendormasterRepository vendorMasterRepository = new VendormasterRepository();
            VendorsDecoratorRepository vendorsDecoratorRepository = new VendorsDecoratorRepository();
            vendorMaster.ServicType = "Decorators";
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorsdecorator.Status = "Active";
            vendorsdecorator.UpdatedDate = DateTime.Now;
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorsdecorator.VendorMasterId = vendorMaster.Id;
            vendorsdecorator = vendorsDecoratorRepository.AddDecorator(vendorsdecorator);
            return vendorsdecorator;
        } 
    }
}
