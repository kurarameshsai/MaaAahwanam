using MaaAahwanam.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Bal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;
using System.Web.Security;
using MaaAahwanam.Dal;
using System.Net;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class VendorController : Controller
    {
        LogsUtility logs = new LogsUtility();
        public string Type = string.Empty;
        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            try
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                int uservalidity = userlogindetailsbal.checkuservalidity();
                if (uservalidity != 0)
                {
                    VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
                    Vendordetailslist.VendorsList = vendordetailsbal.VendorList(actionName).ToList();
                    logs.LogEvents("Viewing AllVendorslist ", "Vendor/Index");
                    return View(Vendordetailslist);
                }
                else
                {
                    return RedirectToAction("Index", "Login", new { Area = "Admin" });
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }
            return View();
        }

        public ActionResult VendorPhotoDet()
        {
            try
            {
                int vendorid = Convert.ToInt32(HttpContext.Request.Params.Get("id"));
                int packageID = Convert.ToInt32(HttpContext.Request.Params.Get("pkgid"));
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                List<VendorDetailsModel> Vendorlistitem = new List<VendorDetailsModel>();
                List<VendorImagesDetailsModel> Vendorimglistitem = new List<VendorImagesDetailsModel>();
                List<VendorPackagedetailsModel> vendorpackagedetailslist = new List<VendorPackagedetailsModel>();

                List<VendorPackagedetailsModel> vendorpackagedetailslistitem = new List<VendorPackagedetailsModel>();
                if (vendorid != 0)
                {
                    var Vendorlist = vendordetailsbal.VendorDetailslist(vendorid).ToList();
                    foreach (var item in Vendorlist)
                    {
                        var addreqUser = new VendorDetailsModel()
                        {
                            UserBusiId = item.UserBusiId,
                            UserLoginId = item.UserLoginId,
                            BusinessName = item.BusinessName,
                            BusinessDesc = item.BusinessDesc,
                            BusinessEstDate = Convert.ToDateTime(item.BusinessEstDate),
                            BusinessAddress = item.BusinessAddress,
                            BusinessLocation = item.BusinessLocation,
                            BusinessCity = item.BusinessCity,
                            BusinessState = item.BusinessState,
                            BusinessZIP = item.BusinessZIP,
                            BusinessPhone = item.BusinessPhone,
                            BusinessPhLand = item.BusinessPhLand,
                            BusinessEmail = item.BusinessEmail,
                            BusinessUrl = item.BusinessUrl,
                            ServiceType = item.ServiceType,
                            BusinessStatus = item.BusinessStatus,
                            TermsandConditions = item.TermsandConditions,
                            UserAminitiesType = item.UserAminitiesType,
                            UserBusiAminitiesId = Convert.ToInt32(item.UserBusiAminitiesId),
                            Experience = item.Experience ?? 0,
                            BookNow = item.BookNow ?? false,
                            Quotation = item.Quotation ?? false,
                            Bidding = item.Bidding ?? false
                        };
                        Vendorlistitem.Add(addreqUser);
                    }

                    var VendorImglist = vendordetailsbal.VendorImagesDetailslist(vendorid).ToList();
                    foreach (var item in VendorImglist)
                    {
                        var addreqUser = new VendorImagesDetailsModel()
                        {
                            UserBusiId = item.UserBusiId,
                            ImageName = item.ImageName,
                            ImageType = item.ImageType,
                            UserImgId = item.UserImgId,
                            UserBusiImageId = item.UserBusiImageId
                        };
                        ViewBag.Tabname = "Images";
                        Vendorimglistitem.Add(addreqUser);
                    }

                    var vendorpackagelist = vendordetailsbal.vendorpackagedetailslist(vendorid).ToList();
                    var vendorpackagelistItem = vendordetailsbal.vendorpackagedetailsItem(packageID).ToList();
                    foreach (var item in vendorpackagelist)
                    {
                        var addreqUser = new VendorPackagedetailsModel()
                        {
                            UserBusiId = item.UserBusiId,
                            packagename = item.Packagename,
                            description = item.PackageDesc,
                            PackageStartDate = item.PackageStartDate,
                            PackageEndDate = item.PackageEndDate,
                            actualamount = item.actualamount ?? 0.0m,
                            sellingamount = item.sellingamount ?? 0.0m,
                            dealamount = item.dealamount ?? 0.0m,
                            discount = item.discount ?? 0.0m,
                            vendorpackageID = item.VendorPackageId,
                            tax = item.tax ?? 0.0m,
                        };
                        vendorpackagedetailslist.Add(addreqUser);
                    }
                    //if (vendorpackagelistItem.Count!=0)
                    //{ 
                    foreach (var item in vendorpackagelistItem)
                    {
                        ViewBag.Tabname = "Packages";
                        var addreqUser1 = new VendorPackagedetailsModel()
                        {
                            UserBusiId = item.UserBusiId,
                            packagename = item.Packagename,
                            description = item.PackageDesc,
                            PackageStartDate = item.PackageStartDate,
                            PackageEndDate = item.PackageEndDate,
                            actualamount = item.actualamount ?? 0.0m,
                            sellingamount = item.sellingamount ?? 0.0m,
                            dealamount = item.dealamount ?? 0.0m,
                            discount = item.discount ?? 0.0m,
                            vendorpackageID = item.VendorPackageId,
                            tax = item.tax ?? 0.0m,
                        };
                        vendorpackagedetailslistitem.Add(addreqUser1);
                    }
                    var VendordetailslistModel = Vendorlistitem.FirstOrDefault();
                    var VendordetailsimglistModel = Vendorimglistitem.ToList();
                    var vendorpackageslistModel = vendorpackagedetailslist.ToList();
                    var Vendorpackageslistitem = vendorpackagedetailslistitem.FirstOrDefault();
                    var tupleModel = new Tuple<VendorDetailsModel, List<VendorImagesDetailsModel>, List<VendorPackagedetailsModel>, VendorPackagedetailsModel>(VendordetailslistModel, VendordetailsimglistModel, vendorpackageslistModel, Vendorpackageslistitem);
                    logs.LogEvents("Viewing Vendorlist ", "Vendor/VendorPhotoDet");
                    return View(tupleModel);
                }
                else
                {
                    var tupleModel = new Tuple<VendorDetailsModel, List<VendorImagesDetailsModel>, List<VendorPackagedetailsModel>, VendorPackagedetailsModel>(Vendorlistitem.FirstOrDefault(), Vendorimglistitem, vendorpackagedetailslist, vendorpackagedetailslistitem.FirstOrDefault());
                    return View(tupleModel);
                }
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorPhotoDet(VendorDetailsModel Item1, VendorPackagedetails Item4, string command, HttpPostedFileBase file, FormCollection collection)
        {
            try
            {

                var arrCheckbox = collection["Delete"];
                string str = string.Empty;
                UserLoginDetalsBal userlogindetailsbal = new UserLoginDetalsBal();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                UploadFile uploadfile = new UploadFile();
                VendorDetails VendorCreatelistitem = new VendorDetails();
                VendorImagesDetails vendorimgupdate = new VendorImagesDetails();
                VendorPackagedetails vendorpackagedetails = new VendorPackagedetails();
                int vendorid = Convert.ToInt32(Item1.UserBusiId.ToString());
                int packageid = Convert.ToInt32(Item4.vendorpackageID.ToString());
                int UserBusiAminitiesId = Convert.ToInt32(Item1.UserBusiAminitiesId.ToString());
                if (command == "Click To Validate GeneralInformation" && ((arrCheckbox == "off") || (arrCheckbox == null)))
                {
                    Type = "General";
                }
                else if (command == "Click To Validate GeneralInformation" && arrCheckbox == "on")
                {
                    Type = "Delete";
                }
                else if (command == "Click To Validate Amenities")
                {
                    Type = "Amenities";
                }
                else if (command == "Click To Save")
                {
                    Type = "Save";
                }
                else if (command == "Save Package")
                {
                    Type = "Savepkg";
                }
                else if (command == "Update Package")
                {
                    Type = "updatepkg";
                }
                switch (Type)
                {
                    case "General":
                        VendorCreatelistitem.UserLoginId = Item1.UserLoginId;
                        VendorCreatelistitem.BusinessName = Item1.BusinessName;
                        VendorCreatelistitem.BusinessAddress = Item1.BusinessAddress;
                        VendorCreatelistitem.BusinessCity = Item1.BusinessCity;
                        VendorCreatelistitem.BusinessDesc = Item1.BusinessDesc;
                        VendorCreatelistitem.BusinessEstDate = Item1.BusinessEstDate;
                        VendorCreatelistitem.BusinessLocation = Item1.BusinessLocation;
                        VendorCreatelistitem.BusinessPhLand = Item1.BusinessPhLand;
                        VendorCreatelistitem.BusinessPhone = Item1.BusinessPhone;
                        VendorCreatelistitem.BusinessUrl = Item1.BusinessUrl;
                        VendorCreatelistitem.BusinessEmail = Item1.BusinessEmail;
                        VendorCreatelistitem.BusinessZIP = Item1.BusinessZIP;
                        VendorCreatelistitem.ServiceType = Item1.ServiceType;
                        VendorCreatelistitem.BusinessState = Item1.BusinessState;
                        VendorCreatelistitem.BusinessStatus = Item1.BusinessStatus;
                        VendorCreatelistitem.TermsandConditions = Item1.TermsandConditions;
                        VendorCreatelistitem.Experience = Item1.Experience;
                        VendorCreatelistitem.BookNow = Item1.BookNow;
                        VendorCreatelistitem.Quotation = Item1.Quotation;
                        VendorCreatelistitem.Bidding = Item1.Bidding;
                        vendordetailsbal.RegisterVendorDetails(VendorCreatelistitem, vendorimgupdate, vendorid, Type, UserBusiAminitiesId);
                        if (vendorid != 0)
                        {
                            logs.LogEvents("Vendor Profile Updating ", "Vendor/VendorPhotoDet");
                            str = "<script language='javascript' type='text/javascript'>alert('Vendor Updated Successfully');location.href='/Admin/Vendor/VendorPhotoDet/?id=" + vendorid + "'</script>";
                        }
                        else
                        {
                            logs.LogEvents("Vendor Profile Saving ", "Vendor/VendorPhotoDet");
                            str = "<script language='javascript' type='text/javascript'>alert('Vendor Registered Successfully');location.href='/Admin/Vendor/Index'</script>";
                        }
                        break;
                    case "Amenities":
                        VendorCreatelistitem.UserBusiId = Item1.UserBusiId;
                        VendorCreatelistitem.UserExperiance = Item1.UserExperiance;
                        VendorCreatelistitem.UserAminitiesType = Item1.UserAminitiesType;
                        VendorCreatelistitem.Category = Item1.Category;
                        VendorCreatelistitem.PostWedding = Item1.PostWedding;
                        VendorCreatelistitem.PreWedding = Item1.PreWedding;
                        vendordetailsbal.RegisterVendorDetails(VendorCreatelistitem, vendorimgupdate, vendorid, Type, UserBusiAminitiesId);
                        if (vendorid != 0)
                        {
                            logs.LogEvents("VendorAmenities Updating ", "Vendor/VendorPhotoDet");
                            str = "<script language='javascript' type='text/javascript'>alert('Vendor Updated Successfully');location.href='/Admin/Vendor/VendorPhotoDet/?id=" + vendorid + "'</script>";
                        }
                        else
                        {
                            logs.LogEvents("VendorAmenities Saving ", "Vendor/VendorPhotoDet");
                            str = "<script language='javascript' type='text/javascript'>alert('VendorAmenities Registered Successfully');location.href='/Admin/Vendor/Index'</script>";
                        }
                        break;
                    case "Save":
                        if (file != null)
                        {
                            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                            string filedetails = uploadfile.Uploadfiles(file, actionName);
                            string[] words = filedetails.Split('|');
                            vendorimgupdate.UserImgId = words[0];
                            vendorimgupdate.ImageName = words[1];
                            vendorimgupdate.ImageType = words[2];
                            vendorimgupdate.UserBusiId = Item1.UserBusiId;
                            vendordetailsbal.RegisterVendorDetails(VendorCreatelistitem, vendorimgupdate, vendorid, Type, UserBusiAminitiesId);
                            logs.LogEvents("VendorImage Uploded ", "Vendor/VendorPhotoDet");
                            str = "<script language='javascript' type='text/javascript'>alert('VendorImage Uploded Successfully');location.href='/Admin/Vendor/VendorPhotoDet/?id=" + vendorid + "'</script>";
                        }
                        break;
                    case "Savepkg":
                        VendorCreatelistitem.UserBusiId = Item1.UserBusiId;
                        VendorCreatelistitem.packagename = Item1.packagename;
                        VendorCreatelistitem.description = Item1.description;
                        VendorCreatelistitem.actualamount = Item1.actualamount;
                        VendorCreatelistitem.sellingamount = Item1.sellingamount;
                        VendorCreatelistitem.dealamount = Item1.dealamount;
                        VendorCreatelistitem.discount = Item1.discount;
                        VendorCreatelistitem.tax = Item1.tax;
                        VendorCreatelistitem.PackageStartDate = Item1.PackageStartDate;
                        VendorCreatelistitem.PackageEndDate = Item1.PackageEndDate;
                        vendordetailsbal.vendorpackages(VendorCreatelistitem, Type, vendorid);
                        str = "<script language='javascript' type='text/javascript'>alert('Vendor Packages saved Successfully');location.href='/Admin/Vendor/VendorPhotoDet?id=" + vendorid + "#'</script>";
                        break;
                    case "updatepkg":
                        // int packageID = Convert.ToInt32(HttpContext.Request.Params.Get("pkgid"));

                        vendorpackagedetails.UserBusiId = Item4.UserBusiId;
                        vendorpackagedetails.vendorpackageID = Item4.vendorpackageID;
                        vendorpackagedetails.packagename = Item4.packagename;
                        vendorpackagedetails.description = Item4.description;
                        vendorpackagedetails.actualamount = Item4.actualamount;
                        vendorpackagedetails.sellingamount = Item4.sellingamount;
                        vendorpackagedetails.dealamount = Item4.dealamount;
                        vendorpackagedetails.discount = Item4.discount;
                        vendorpackagedetails.tax = Item4.tax;
                        vendorpackagedetails.PackageStartDate = Item4.PackageStartDate;
                        vendorpackagedetails.PackageEndDate = Item4.PackageEndDate;
                        vendordetailsbal.vendorpackagesupdate(vendorpackagedetails, Type, packageid);

                        str = "<script language='javascript' type='text/javascript'>alert('Vendor Packages Updated Successfully');location.href='/Admin/Vendor/VendorPhotoDet?id=" + vendorid + "#'</script>";
                        break;
                    case "Delete":
                        vendordetailsbal.Delete_VendorInformation(vendorid);
                        logs.LogEvents("Deleting Vendorlist ", "Vendor/VendorPhotoDet/");
                        str = "<script language='javascript' type='text/javascript'>alert('Vendor Profile Delete Successfully');location.href='/Admin/Vendor/Index'</script>";
                        break;
                }
                ViewBag.Tabname = Type;
                return Content(str);
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }

        }

        public JsonResult DeleteImg(int Imgid)
        {
            VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
            bool value = vendordetailsbal.VendorImg_Delete(Imgid);
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Activevendors()
        {
            try
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
                Vendordetailslist.VendorsList = vendordetailsbal.VendorList(actionName).ToList();
                logs.LogEvents("Viewing ActiveVendorslist ", "Vendor/Activevendors");
                return View(Vendordetailslist);
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }
        }
        public ActionResult Suspenvendors()
        {
            try
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
                Vendordetailslist.VendorsList = vendordetailsbal.VendorList(actionName).ToList();
                logs.LogEvents("Viewing SuspenVendorslist ", "Vendor/Suspenvendors");
                return View(Vendordetailslist);
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }
        }
        public ActionResult Pendingvendors()
        {
            try
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
                VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
                Vendordetailslist.VendorsList = vendordetailsbal.VendorList(actionName).ToList();
                logs.LogEvents("Viewing PendingVendorslist ", "Vendor/Pendingvendors");
                return View(Vendordetailslist);
            }
            catch (Exception exception)
            {
                logs.LogTheExceptions(exception, "DashBoard/dashboard");
                return Content("<script language='javascript' type='text/javascript'>alert('Exception as occurred!');location.href='" + @Url.Action("dashboard", "DashBoard", new { Area = "Admin" }) + "'</script>");
            }
        }


    }
}