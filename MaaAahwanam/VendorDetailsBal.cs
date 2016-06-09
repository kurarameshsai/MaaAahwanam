using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;

namespace MaaAahwanam.Bal
{
    public class VendorDetailsBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public void RegisterVendorDetails(VendorDetails vendormodel, VendorImagesDetails vendorimgmodel, int vendorid, string command, int UserBusiAminitiesId)
        {
            MA_User_Vendor uservendor = new MA_User_Vendor();
            MA_Vendor_Packages vendorpackages = new MA_Vendor_Packages();
            MA_Vendor_Aminities VAminities = new MA_Vendor_Aminities();
            MA_Vendor_Images VendorImages = new MA_Vendor_Images();
            MA_User_Login userlogin = new MA_User_Login();
            MA_User_Details userdetails = new MA_User_Details();
            switch (command)
            {
                case "General":
                    if (vendorid == 0)
                    {
                        userlogin.UserName = vendormodel.BusinessEmail;
                        userlogin.Password = Encrypt_and_DecryptUtility.Encrypt(vendormodel.BusinessLocation + "1$");
                        userlogin.RegDate = DateTime.Now;
                        userlogin.UserType = "Vendor";
                        userlogin.Status = "1";
                        _Repositories.UserLoginDetails.Add(userlogin);
                        _Repositories.SaveChanges();
                        userdetails.FirstName = vendormodel.BusinessName;
                        userdetails.UserLoginId = userlogin.UserLoginId;
                        userdetails.UserPhone = vendormodel.BusinessPhone;
                        _Repositories.UserDetails.Add(userdetails);
                        _Repositories.SaveChanges();

                        uservendor.UserLoginId = userlogin.UserLoginId;
                        uservendor.BusinessName = vendormodel.BusinessName;
                        uservendor.BusinessDesc = vendormodel.BusinessDesc;
                        uservendor.BusinessEstDate = vendormodel.BusinessEstDate;
                        uservendor.BusinessPhone = vendormodel.BusinessPhone;
                        uservendor.BusinessPhLand = vendormodel.BusinessPhLand;
                        uservendor.BusinessAddress = vendormodel.BusinessAddress;
                        uservendor.BusinessLocation = vendormodel.BusinessLocation;
                        uservendor.BusinessCity = vendormodel.BusinessCity;
                        uservendor.BusinessZIP = vendormodel.BusinessZIP;
                        uservendor.ServiceType = vendormodel.ServiceType;
                        uservendor.Experience = vendormodel.Experience;
                        uservendor.BusinessUrl = vendormodel.BusinessUrl;
                        uservendor.BusinessStatus = "Active";
                        uservendor.BusinessState = vendormodel.BusinessState;
                        uservendor.TermsandConditions = vendormodel.TermsandConditions;
                        uservendor.BusinessEmail = vendormodel.BusinessEmail;
                        uservendor.Experience = vendormodel.Experience;
                        uservendor.Requestdate = DateTime.Now;
                        uservendor.BookNow = vendormodel.BookNow;
                        uservendor.Quotation = vendormodel.Quotation;
                        uservendor.Bidding = vendormodel.Bidding;
                        _Repositories.VendorDetails.Add(uservendor);
                        _Repositories.SaveChanges();
                    }
                    if (vendorid != 0)
                    {
                        uservendor = _Repositories.VendorDetails.Get().Where(i => i.UserBusiId == vendorid).First();
                        uservendor.UserLoginId = vendormodel.UserLoginId;
                        uservendor.BusinessName = vendormodel.BusinessName;
                        uservendor.BusinessDesc = vendormodel.BusinessDesc;
                        uservendor.BusinessEstDate = vendormodel.BusinessEstDate;
                        uservendor.BusinessPhone = vendormodel.BusinessPhone;
                        uservendor.BusinessPhLand = vendormodel.BusinessPhLand;
                        uservendor.BusinessAddress = vendormodel.BusinessAddress;
                        uservendor.BusinessLocation = vendormodel.BusinessLocation;
                        uservendor.BusinessCity = vendormodel.BusinessCity;
                        uservendor.BusinessZIP = vendormodel.BusinessZIP;
                        uservendor.ServiceType = vendormodel.ServiceType;
                        uservendor.Experience = vendormodel.Experience;
                        uservendor.BusinessUrl = vendormodel.BusinessUrl;
                        uservendor.BusinessStatus = vendormodel.BusinessStatus;
                        uservendor.BusinessState = vendormodel.BusinessState;
                        uservendor.TermsandConditions = vendormodel.TermsandConditions;
                        uservendor.BusinessEmail = vendormodel.BusinessEmail;
                        uservendor.BookNow = vendormodel.BookNow;
                        uservendor.Quotation = vendormodel.Quotation;
                        uservendor.Bidding = vendormodel.Bidding;
                        uservendor.Requestdate = DateTime.Now;
                        _Repositories.SaveChanges();

                    }
                    break;
                case "Amenities":
                    if (vendorid != 0 && UserBusiAminitiesId == 0)
                    {
                        VAminities.UserBusiId = vendormodel.UserBusiId;
                        VAminities.UserAminitiesType = vendormodel.UserAminitiesType;
                        _Repositories.VendorAminitiesDetails.Add(VAminities);
                        _Repositories.SaveChanges();

                    }
                    else if (vendorid != 0 && UserBusiAminitiesId != 0)
                    {
                        VAminities = _Repositories.VendorAminitiesDetails.Get().Where(i => i.UserBusiId == vendorid).First();
                        VAminities.UserBusiId = vendormodel.UserBusiId;
                        VAminities.UserAminitiesType = vendormodel.UserAminitiesType;
                        _Repositories.SaveChanges();
                    }
                    break;
                case "Save":

                    VendorImages.UserBusiId = _Repositories.VendorDetails.Get().Where(i => i.UserBusiId == vendorid).Select(i => i.UserBusiId).SingleOrDefault();
                    VendorImages.ImageName = vendorimgmodel.ImageName;
                    VendorImages.ImageType = vendorimgmodel.ImageType;
                    VendorImages.UserImgId = vendorimgmodel.UserImgId;
                    _Repositories.VendorImagesDetails.Add(VendorImages);
                    _Repositories.SaveChanges();
                    break;
            }
        }

        public List<MA_User_Vendor> VendorList(string ControllerAction)
        {
            var UserVendor = new List<MA_User_Vendor>();
            switch (ControllerAction)
            {
                case "Index":
                    UserVendor = _Repositories.VendorDetails.Get().ToList();

                    break;
                case "Activevendors":
                    UserVendor = _Repositories.VendorDetails.Get().ToList().Where(p => p.BusinessStatus == "Active").ToList();
                    break;
                case "Suspenvendors":
                    UserVendor = _Repositories.VendorDetails.Get().ToList().Where(p => p.BusinessStatus == "Suspended").ToList();
                    break;
                case "Pendingvendors":
                    UserVendor = _Repositories.VendorDetails.Get().ToList().Where(p => p.BusinessStatus == "Pending").ToList();
                    break;
                case "Indexgifts":
                    UserVendor = _Repositories.VendorDetails.Get().Where(x => x.ServiceType == "Gifts Vendor").ToList();
                    break;
                case "Indexinvitations":
                    UserVendor = _Repositories.VendorDetails.Get().Where(x => x.ServiceType == "Invitation Cards").ToList();
                    break;
            }
            return UserVendor;
        }

        public List<sp_vendorlist_Result> VendorDetailslist(int VendorId)
        {
            return _Repositories.sp_vendorlist.ExecuteProcedure_WithParameters("exec sp_vendorlist  {0},{1}", 1, VendorId).ToList();
        }

        public List<VendorImagesDetails> VendorImagesDetailslist(int VendorId)
        {
            var VendorImage = new List<MA_Vendor_Images>();
            List<VendorImagesDetails> test1 = new List<VendorImagesDetails>();
            if (VendorId != 0)
                VendorImage = _Repositories.VendorImagesDetails.Get().ToList().Where(p => p.UserBusiId == VendorId).OrderByDescending(p => p.UserBusiImageId).ToList();
            foreach (var item in VendorImage)
            {
                var addUser = new VendorImagesDetails()
                {
                    UserBusiId = item.UserBusiId,
                    ImageName = item.ImageName,
                    ImageType = item.ImageType,
                    UserImgId = item.UserImgId,
                    UserBusiImageId = item.UserBusiImageId
                };
                test1.Add(addUser);
            }

            return test1.ToList();
        }

        //sai
        public List<MA_Vendor_Packages> vendorpackagedetailslist(int VendorId)
        {
            return _Repositories.Vendorpackages.Get().Where(p => p.UserBusiId == VendorId).OrderByDescending(p => p.Packagename).ToList();
        }
        public List<MA_Vendor_Packages> vendorpackagedetailsItem(int packageID)
        {
            return _Repositories.Vendorpackages.Get().Where(p => p.VendorPackageId == packageID).ToList();
        }


        public void Delete_VendorInformation(int VendorId)
        {
            if (VendorId != 0)
            {

                MA_User_Vendor uservendor = new MA_User_Vendor();
                List<MA_Vendor_Images> VendorImagesList = new List<MA_Vendor_Images>();
                List<MA_Vendor_Aminities> VAminities = new List<MA_Vendor_Aminities>();
                MA_User_Login userlogin = new MA_User_Login();
                MA_User_Details userdetails = new MA_User_Details();
                uservendor = _Repositories.VendorDetails.Get().Where(i => i.UserBusiId == VendorId).First();
                int userlogid = int.Parse(uservendor.UserLoginId.ToString());
                if (userlogid != 0)
                {
                    VendorImagesList = _Repositories.VendorImagesDetails.Get().Where(i => i.UserBusiId == VendorId).ToList();
                    if (VendorImagesList.Count != 0)
                    {
                        foreach (var data in VendorImagesList)
                        {
                            _Repositories.VendorImagesDetails.Delete(data);
                            _Repositories.SaveChanges();
                        }
                    }

                    VAminities = _Repositories.VendorAminitiesDetails.Get().Where(i => i.UserBusiId == VendorId).ToList();
                    if (VAminities.Count != 0)
                    {
                        foreach (var data in VAminities)
                        {
                            _Repositories.VendorAminitiesDetails.Delete(data);
                            _Repositories.SaveChanges();
                        }
                    }

                    _Repositories.VendorDetails.Delete(uservendor);
                    _Repositories.SaveChanges();

                    userdetails = _Repositories.UserDetails.Get().Where(i => i.UserLoginId == userlogid).First();
                    _Repositories.UserDetails.Delete(userdetails);
                    _Repositories.SaveChanges();

                    userlogin = _Repositories.UserLoginDetails.Get().Where(i => i.UserLoginId == userlogid).First();
                    _Repositories.UserLoginDetails.Delete(userlogin);
                    _Repositories.SaveChanges();

                }
            }
        }

        public bool VendorImg_Delete(int id)
        {
            bool Value;
            if (id != 0)
            {
                MA_Vendor_Images VendorImages = new MA_Vendor_Images();
                VendorImages = _Repositories.VendorImagesDetails.Get().Where(p => p.UserBusiImageId == id).First();
                _Repositories.VendorImagesDetails.Delete(VendorImages);
                _Repositories.SaveChanges();
                Value = true;
            }
            else
            {
                Value = false;
            }
            return Value;
        }

        public string AminitiesTypes(string servicetype)
        {
            string str = string.Empty;
            var UserVendor = _Repositories.VendorDetails.Get().ToList().Where(p => p.ServiceType == servicetype).Select(p => p.UserBusiId).ToList();
            for (int i = 0; i < UserVendor.Count; i++)
            {
                var quary = _Repositories.VendorAminitiesDetails.Get().ToList().Where(p => p.UserBusiId == UserVendor[i]).Select(p => p.UserAminitiesType).Distinct().ToList();
                if (quary.Count != 0)
                    str += "," + quary.First();
            }
            string ReturnStr = str;
            string temp = "";
            ReturnStr.Split(',').Distinct().ToList().ForEach(k => temp += k + ",");
            ReturnStr = temp.Trim(',');
            return ReturnStr;
        }

        public void vendorpackages(VendorDetails VendorCreatelistitem, string command, int vendorid)
        {
            MA_Vendor_Packages vendorpackages = new MA_Vendor_Packages();
            switch (command)
            {
                case "Savepkg":
                    vendorpackages.UserBusiId = VendorCreatelistitem.UserBusiId;
                    vendorpackages.Packagename = VendorCreatelistitem.packagename;
                    vendorpackages.PackageDesc = VendorCreatelistitem.description;
                    vendorpackages.PackageStartDate = VendorCreatelistitem.PackageStartDate;
                    vendorpackages.PackageEndDate = VendorCreatelistitem.PackageEndDate;
                    vendorpackages.actualamount = VendorCreatelistitem.actualamount;
                    vendorpackages.sellingamount = VendorCreatelistitem.sellingamount;
                    vendorpackages.dealamount = VendorCreatelistitem.dealamount;
                    vendorpackages.discount = VendorCreatelistitem.discount;
                    vendorpackages.tax = VendorCreatelistitem.tax;
                    _Repositories.Vendorpackages.Add(vendorpackages);
                    _Repositories.SaveChanges();
                    break;
            }
        }

        public void vendorpackagesupdate(VendorPackagedetails Item4, string command, int packageid)
        {
            MA_Vendor_Packages vendorpackages = new MA_Vendor_Packages();
            switch (command)
            {
                case "updatepkg":
                    vendorpackages = _Repositories.Vendorpackages.Get().Where(p => p.VendorPackageId == packageid).SingleOrDefault();
                    vendorpackages.UserBusiId = Item4.UserBusiId;
                    vendorpackages.VendorPackageId = Item4.vendorpackageID;
                    vendorpackages.Packagename = Item4.packagename;
                    vendorpackages.PackageDesc = Item4.description;
                    vendorpackages.PackageStartDate = Item4.PackageStartDate;
                    vendorpackages.PackageEndDate = Item4.PackageEndDate;
                    vendorpackages.actualamount = Item4.actualamount;
                    vendorpackages.sellingamount = Item4.sellingamount;
                    vendorpackages.dealamount = Item4.dealamount;
                    vendorpackages.discount = Item4.discount;
                    vendorpackages.tax = Item4.tax;
                    _Repositories.SaveChanges();
                    break;
            }
        }

        public List<string> GetServiceList()
        {          
            return _Repositories.VendorDetails.Get().Select(m => m.ServiceType).Distinct().ToList();
        }

        public List<string> Locationsearch()
        {
            //return _Repositories.VendorDetails.Get().ToList().Where(m => m.BusinessLocation.ToLower().Contains(term.ToLower())).Distinct().Select(m => m.BusinessLocation).ToList();
            return _Repositories.VendorDetails.Get().Select(m => m.BusinessLocation).ToList();
        }
    }
}
