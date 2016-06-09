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

    public class InviDesignsController : Controller
    {
        LogsUtility logs = new LogsUtility();

        public ActionResult InvitationDesigns(InviDesignsModel model, int? id)
        {
            InviDesignsBal invidesignsbal = new InviDesignsBal();
            model.DesignsList = invidesignsbal.Designslist();
            if (id != null)
            {
                var designlist = invidesignsbal.InviDesigns(id ?? 0).FirstOrDefault();
                model.DesignId = designlist.DesignId;
                model.DesignName = designlist.DesignName;
                model.Description = designlist.Description;
                model.Category = designlist.Category;
                model.CardCost = designlist.CardCost;
                model.Image = designlist.Image;
                model.ImageId = designlist.ImageId;
                model.VendorID = designlist.VendorId.ToString();
            }
            VendorDetailsModel Vendordetailslist = new VendorDetailsModel();
            VendorDetailsBal vendordetailsbal = new VendorDetailsBal();
            Vendordetailslist.VendorsList = vendordetailsbal.VendorList("Indexinvitations").ToList();
            model.VendorsList = vendordetailsbal.VendorList("Indexinvitations").ToList();
            return View(model);
        }


        public ActionResult save(InviDesignsModel model, HttpPostedFileBase file, int? id)
        {

            try
            {
                UploadFile uploadfile = new UploadFile();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                InviDesignsBal invidesignsbal = new InviDesignsBal();
                InviDesigns invidesigns = new InviDesigns();
                MultipleImagesforInvitations multipleimagesforinvitations = new MultipleImagesforInvitations();
                id = model.DesignId;
                if (id != 0) invidesigns.DesignId = id ?? 0;
                invidesigns.DesignName = model.DesignName;
                invidesigns.Category = model.Category;
                invidesigns.Description = model.Description;
                invidesigns.CardCost = model.CardCost;
                invidesigns.VendorID = model.VendorID;
                if (file != null)
                {
                    string filedetails = uploadfile.Uploadfiles(file, controllerName);
                    string[] words = filedetails.Split('|');
                    invidesigns.ImageId = words[0];
                    invidesigns.Image = words[1];
                }
                int a=invidesignsbal.SaveInviDesigns(invidesigns);

                List<InviDesigns> fileDetails = new List<InviDesigns>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file1 = Request.Files[i];

                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file1.FileName);
                        string filedetails = uploadfile.Uploadfiles1(file1, controllerName);
                        string[] words = filedetails.Split('|');
                        multipleimagesforinvitations.imageid = words[0];
                        multipleimagesforinvitations.image = words[1];
                        multipleimagesforinvitations.Invitaitonid = a;
                        //multipleimages = multipleimages + "&&" + words[1];
                        invidesignsbal.SaveInviDesignsmulti(multipleimagesforinvitations);
                    }
                }

                logs.LogEvents("DesignSaved successfully", "InviDesigns/InvitationDesigns", ValidUserUtility.ValidUser());}
            catch (Exception ex)
            {

            }
            return RedirectToAction("InvitationDesigns");
        }

    }
}
