using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;

namespace MaaAahwanam.Service
{
   public class VendorBeautyServicesService
    {
        RandomPassword randomPassword = new RandomPassword();
        UserLoginRepository userLoginRepository = new UserLoginRepository();
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorsBeautyServiceRepository vendorBeautyServiceRespository = new VendorsBeautyServiceRepository();
        UserLogin userLogin = new UserLogin();
        public VendorsBeautyService AddBeautyService(VendorsBeautyService vendorBeautyService,Vendormaster vendorMaster)
        {
            vendorBeautyService.UpdatedDate = DateTime.Now;
            vendorBeautyService.Status = "Active";
            vendorMaster.UpdatedDate = userLogin.RegDate = userLogin.UpdatedDate = DateTime.Now;
            vendorMaster.Status =  userLogin.Status= "Active";
            vendorMaster.ServicType = "BeautyServices";
            vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
            vendorBeautyService.VendorMasterId = vendorMaster.Id;
            vendorBeautyService = vendorBeautyServiceRespository.AddBeautyService(vendorBeautyService);
            userLogin.UserName = vendorMaster.EmailId;
            userLogin.Password = randomPassword.GenerateString();
            userLogin.UserType = "Vendor";
            userLogin.UpdatedBy = 2;
            userLogin = userLoginRepository.AddVendorUserLogin(userLogin);
            if (vendorMaster.Id != 0 && vendorBeautyService.Id != 0 && userLogin.UserLoginId != 0)
            {
                return vendorBeautyService;
            }
            else
            {
                vendorBeautyService.Id = 0;
                return vendorBeautyService;
            }
        }
        public VendorsBeautyService GetVendorBeautyService(long id)
        {
            return vendorBeautyServiceRespository.GetVendorsBeautyService(id);
        }

        public VendorsBeautyService UpdatesBeautyService(VendorsBeautyService vendorsBeautyService, Vendormaster vendorMaster, long masterid)
        {
            vendorsBeautyService.Status = "Active";
            vendorsBeautyService.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "BeautyServices";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsBeautyService = vendorBeautyServiceRespository.UpdatesBeautyService(vendorsBeautyService, masterid);
            return vendorsBeautyService;
        }
    }
}
