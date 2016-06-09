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
using System.IO;

namespace MaaAahwanam.Web.Areas.Admin.Controllers
{
    public class GIftdesignsController : Controller
    {
        //
        // GET: /Admin/GIftdesigns/
        public ActionResult Index(GiftdesignModel model, int? id, int? did)
        {
            InviDesignsBal invidesignsbal = new InviDesignsBal();
            GiftdesignsBAL giftdesignsBAL = new GiftdesignsBAL();
            model.Giftlist = giftdesignsBAL.Giftslist();
            if (id != null)
            {
                var giftlist = giftdesignsBAL.Giftdesigns(id ?? 0).FirstOrDefault();
                model.giftid = giftlist.Giftid;
                model.GiftName = giftlist.Giftname;
                model.Description = giftlist.Description;
                model.Category = giftlist.Category;
                model.GiftCost = giftlist.GiftCost;
                model.Image = giftlist.Image;
                model.ImageId = giftlist.ImageId;
                model.VendorID = giftlist.VendorId.ToString();
            }
            VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
            VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
            Vendordetailslist.VendorsList = vendordetailsbal.VendorList("Indexgifts").ToList();
            model.VendorsList = vendordetailsbal.VendorList("Indexgifts").ToList();
            return View("Giftdesign", model);
        }

        //
        // Post: /Admin/GIftdesigns/
        [HttpPost]
        public ActionResult Index(GiftdesignModel model, HttpPostedFileBase file, int? id, int? did)
        {
            try
            {
                string multipleimages = string.Empty;
                UploadFile uploadfile = new UploadFile();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                GiftdesignsBAL giftdesignsbal = new GiftdesignsBAL();
                GIftdesign giftdesign = new GIftdesign();
                Multipleimagesgiftdesings multiimagemodel = new Multipleimagesgiftdesings();
                id = model.giftid;
                if (id != 0) giftdesign.giftid = id ?? 0;
                giftdesign.GiftName = model.GiftName;
                giftdesign.Category = model.Category;
                giftdesign.Description = model.Description;
                giftdesign.GiftCost = model.GiftCost;
                giftdesign.VendorID = model.VendorID;
                if (file != null)
                {
                    string filedetails = uploadfile.Uploadfiles(file, controllerName);
                    string[] words = filedetails.Split('|');
                    giftdesign.ImageId = words[0];
                    giftdesign.Image = words[1];
                }
                int a = giftdesignsbal.SaveInviDesigns(giftdesign);
                List<GIftdesign> fileDetails = new List<GIftdesign>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file1 = Request.Files[i];

                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file1.FileName);
                        string filedetails = uploadfile.Uploadfiles1(file1, controllerName);
                        string[] words = filedetails.Split('|');
                        multiimagemodel.Imageid = words[0];
                        multiimagemodel.Image = words[1];
                        multiimagemodel.giftid = a;
                        //multipleimages = multipleimages + "&&" + words[1];
                        giftdesignsbal.SaveInviDesignsmulti(multiimagemodel);
                    }
                }
                //giftdesign.Image = multipleimages; 

                
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        //deleting the gift details
        public ActionResult Delete(int did)
        {
            try
            {
                GiftdesignsBAL giftdesignsbal = new GiftdesignsBAL();
                giftdesignsbal.deleteGiftdesigns(did);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
    }
}