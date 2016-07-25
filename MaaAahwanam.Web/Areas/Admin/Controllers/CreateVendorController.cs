using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaaAahwanam.Service;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class CreateVendorController : Controller
    {
        VendorImageService vendorImageService = new VendorImageService();
        VendorMasterService vendorMasterService = new VendorMasterService();
        const string imagepath = @"/vendorimages/";
        //public CreateVendorController(IAccommodationService accommodationService)
        //{ }
        public ActionResult Images()
        {
            return View();
        }

        public ActionResult BeautyServices()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BeautyServices([Bind(Prefix = "Item2")] VendorsBeautyService vendorsBeautyService, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorBeautyServicesService vendorBeautyServicesService = new VendorBeautyServicesService();
            vendorsBeautyService.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsBeautyService = vendorBeautyServicesService.AddBeautyService(vendorsBeautyService, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsBeautyService.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "BeautyService_" + vendorsBeautyService.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsBeautyService.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("BeautyServices", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("BeautyServices", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult Catering()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Catering([Bind(Prefix = "Item2")] VendorsCatering vendorsCatering, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorCateringService vendorCateringService = new VendorCateringService();
            vendorsCatering.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsCatering = vendorCateringService.AddCatering(vendorsCatering, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsCatering.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Catering_" + vendorsCatering.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsCatering.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Catering", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Catering", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult Decorator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Decorator([Bind(Prefix = "Item2")] VendorsDecorator vendorsDecorator, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorDecoratorService vendorDecoratorService = new VendorDecoratorService();
            vendorsDecorator.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsDecorator = vendorDecoratorService.AddDecorator(vendorsDecorator,vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsDecorator.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Decorator_" + vendorsDecorator.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsDecorator.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Decorator", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Decorator", "CreateVendor") + "'</script>");
            }
            return View();
        }

        public ActionResult Entertainment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entertainment([Bind(Prefix = "Item2")] VendorsEntertainment vendorsEntertainment, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorEntertainmentService vendorEntertainmentService = new VendorEntertainmentService();
            vendorsEntertainment.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsEntertainment = vendorEntertainmentService.AddEntertainment(vendorsEntertainment, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsEntertainment.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Entertainment_" + vendorsEntertainment.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsEntertainment.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Entertainment", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Entertainment", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult EventOrganisers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventOrganisers([Bind(Prefix = "Item2")] VendorsEventOrganiser vendorsEventOrganisers, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorEventOrganiserService vendorEventOrganiserService = new VendorEventOrganiserService();
            vendorsEventOrganisers.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsEventOrganisers = vendorEventOrganiserService.AddEventOrganiser(vendorsEventOrganisers, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsEventOrganisers.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "EventOrganisers_" + vendorsEventOrganisers.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsEventOrganisers.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("EventOrganisers", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("EventOrganisers", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult Gifts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Gifts([Bind(Prefix = "Item2")] VendorsGift vendorsGift, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorGiftService vendorGiftService = new VendorGiftService();
            vendorsGift.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsGift = vendorGiftService.AddGift(vendorsGift, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsGift.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Gift_" + vendorsGift.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsGift.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Gifts", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Gifts", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult InvitationCards()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvitationCards([Bind(Prefix = "Item2")] VendorsInvitationCard vendorsInvitationCard, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorInvitationCardsService vendorInvitationCardsService = new VendorInvitationCardsService();
            vendorsInvitationCard.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsInvitationCard = vendorInvitationCardsService.AddInvitationCard(vendorsInvitationCard, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsInvitationCard.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "InvitationCard_" + vendorsInvitationCard.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsInvitationCard.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("InvitationCards", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("InvitationCards", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult Photography()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Photography([Bind(Prefix = "Item2")] VendorsPhotography vendorsPhotography, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorPhotographyService vendorPhotographyService = new VendorPhotographyService();
            vendorsPhotography.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsPhotography = vendorPhotographyService.AddPhotography(vendorsPhotography, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsPhotography.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();

            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Photography_" + vendorsPhotography.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsPhotography.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Photography", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Photography", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult TravelAccomodation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TravelAccomodation([Bind(Prefix = "Item2")] VendorsTravelandAccomodation vendorsTravelandAccomodation, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorTravelAndAccomadationService vendorTravelAndAccomadationService = new VendorTravelAndAccomadationService();
            vendorsTravelandAccomodation.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsTravelandAccomodation = vendorTravelAndAccomadationService.AddTravelAndAccomadation(vendorsTravelandAccomodation, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsTravelandAccomodation.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename = "TravelandAccomodation_" + vendorsTravelandAccomodation.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsTravelandAccomodation.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("TravelAccomodation", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("TravelAccomodation", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult WeddingCollection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WeddingCollection([Bind(Prefix = "Item2")] VendorsWeddingCollection vendorsWeddingCollection, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorWeddingCollectionService vendorWeddingCollectionService = new VendorWeddingCollectionService();
            vendorsWeddingCollection.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsWeddingCollection = vendorWeddingCollectionService.AddWeddingCollection(vendorsWeddingCollection, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsWeddingCollection.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "WeddingCollection_" + vendorsWeddingCollection.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsWeddingCollection.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("WeddingCollection", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("WeddingCollection", "CreateVendor") + "'</script>");
            }
            return View();
        }
        public ActionResult Venue(string id, [Bind(Prefix = "Item2")] VendorVenue vendorVenue, [Bind(Prefix = "Item1")] Vendormaster vendorMaster)
        {
            VendorVenueService vendorVenueService = new VendorVenueService();
            if (id!=null)
            {
                vendorVenue = vendorVenueService.GetVendorVenue(long.Parse(id)); 
                vendorMaster = vendorMasterService.GetVendor(long.Parse(id)); 
                var a = new Tuple<Vendormaster, VendorVenue>(vendorMaster, vendorVenue);
                ViewBag.images = vendorImageService.GetVendorImagesService(long.Parse(id));
                ViewBag.masterid = id;
                return View(a);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Venue([Bind(Prefix = "Item2")] VendorVenue vendorVenue, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            VendorVenueService vendorVenueService = new VendorVenueService();
            vendorVenue.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorVenue = vendorVenueService.AddVenue(vendorVenue, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorVenue.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count <= 10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i + 1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Venue_" + vendorVenue.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorVenue.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Venue", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Venue", "CreateVendor") + "'</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Others()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Others([Bind(Prefix = "Item2")] VendorsOther vendorsOther, [Bind(Prefix = "Item1")] Vendormaster vendorMaster, HttpPostedFileBase file, string Command)
        {
            string fileName = string.Empty;
            string ImagesURL = string.Empty;
            VendorOthersService vendorOthersService = new VendorOthersService();
            vendorsOther.UpdatedBy = ValidUserUtility.ValidUser();
            vendorMaster.UpdatedBy = ValidUserUtility.ValidUser();
            vendorsOther = vendorOthersService.AddOther(vendorsOther, vendorMaster);
            VendorImage vendorImage = new VendorImage();
            vendorImage.VendorId = vendorsOther.Id;
            vendorImage.UpdatedBy = ValidUserUtility.ValidUser();
            //const string imagepath = @"/vendorimages";
            if (Request.Files.Count<=10)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    int j = i+1;
                    
                        var file1 = Request.Files[i];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            string path = System.IO.Path.GetExtension(file.FileName);
                            var filename =  "Others_" + vendorsOther.VendorMasterId + "_" + j + path;
                            fileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(imagepath + filename));
                            file1.SaveAs(fileName);
                            vendorImage.ImageName = filename;
                            vendorImage = vendorImageService.AddVendorImage(vendorImage, vendorMaster);
                        }
                    
                }
            }
            if (vendorsOther.Id != 0 && vendorImage.ImageId != 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registered Successfully');location.href='" + @Url.Action("Others", "CreateVendor") + "'</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Registration Failed');location.href='" + @Url.Action("Others", "CreateVendor") + "'</script>");
            }
            return View();
        }
        //public JsonResult images(string ids)
        //{
        //    var images = vendorImageService.GetVendorImagesService(long.Parse(ids));
        //    return Json(images);
        //}

        public JsonResult DeleteImage(string imgsrc, string ids)
        {
            //var images = entities.TempVenueDetails.Where(s => s.ID == id).SingleOrDefault();
            //string path = images.Images.ToString().TrimEnd(',') + ",";
            //images.Images = path.Replace(imgsrc + ",", "");
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(@"~/CSSWeb/Uploadedimages"));
            //FileInfo oFileInfo = new FileInfo(Server.MapPath(@"~/CSSWeb/Uploadedimages/" + imgsrc));
            //oFileInfo.Delete();
            //oFileInfo.Refresh();
            //entities.SaveChanges();
            return Json("success");
        }
    }
}