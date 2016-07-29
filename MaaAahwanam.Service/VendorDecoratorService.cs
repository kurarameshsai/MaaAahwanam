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
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorsDecoratorRepository vendorsDecoratorRepository = new VendorsDecoratorRepository();
        public VendorsDecorator AddDecorator(VendorsDecorator vendorsdecorator,Vendormaster vendorMaster)
        {
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

        public VendorsDecorator GetVendorDecorator(long id)
        {
            return vendorsDecoratorRepository.GetVendorDecorator(id);
        }

        public VendorsDecorator UpdateDecorator(VendorsDecorator vendorsDecorator, Vendormaster vendorMaster, long masterid)
        {
            vendorsDecorator.Status = "Active";
            vendorsDecorator.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "Decorators";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsDecorator = vendorsDecoratorRepository.UpdateDecorator(vendorsDecorator, masterid);
            return vendorsDecorator;
        }
    }
}
