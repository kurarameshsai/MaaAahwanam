using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam.Bal
{
    public class InviDesignsBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public int DesignID(InviDesigns invidesigns)
        {
            if (invidesigns.CreatedBy != 0)
            {
                invidesigns.CreatedBy = _Repositories.InviDesigns.Get().Where(i => i.DesignName == invidesigns.DesignName && i.Category == invidesigns.Category).Select(i => i.CreatedBy).SingleOrDefault();
            }
            else
            {
                invidesigns.CreatedBy = _Repositories.InviDesigns.Get().Where(i => i.DesignName == invidesigns.DesignName).Select(i => i.CreatedBy).SingleOrDefault();
            }
            return invidesigns.DesignId;
        }
        public int SaveInviDesigns(InviDesigns invidesigns)
        {
            MaaAahwanam.Dal.MA_Invi_Designs designs = new MA_Invi_Designs();
            if (invidesigns.DesignId != 0) designs = _Repositories.InviDesigns.Get().SingleOrDefault(i => i.DesignId == invidesigns.DesignId);
            designs.DesignName = invidesigns.DesignName;
            designs.Description = invidesigns.Description;
            designs.Category = invidesigns.Category;
            designs.CardCost = invidesigns.CardCost;
            designs.VendorId = Convert.ToInt32(invidesigns.VendorID);
            if (invidesigns.Image != null)
            {
                designs.Image = invidesigns.Image;
                designs.ImageId = invidesigns.ImageId;
            }
            designs.CreatedBy = ValidUserUtility.ValidUser();
            designs.CreatedDate = DateTime.Now;
            if (invidesigns.DesignId == 0) _Repositories.InviDesigns.Add(designs);
            _Repositories.SaveChanges();
            return designs.DesignId;
        }

        // multiple image save functionality 
        public void SaveInviDesignsmulti(MultipleImagesforInvitations multigiftimagemodel)
        {
            MA_Admin_Invitationdesigns_multiimages multipleimages = new MA_Admin_Invitationdesigns_multiimages();
            multipleimages.Invitaitonid = multigiftimagemodel.Invitaitonid;
            if (multigiftimagemodel.image != null)
            {
                multipleimages.image = multigiftimagemodel.image;
                multipleimages.imageid = multigiftimagemodel.imageid;
            }
            _Repositories.Invitationdesigns_multiimages.Add(multipleimages);
            _Repositories.SaveChanges();
        }

        public List<MA_Invi_Designs> Designslist()
        {
            var InviDesigns = new List<MA_Invi_Designs>();
            InviDesigns = _Repositories.InviDesigns.Get().ToList();
            return InviDesigns;
        }
        public List<MA_Invi_Designs> InviDesigns(int id)
        {
            List<MA_Invi_Designs> designdetail = _Repositories.InviDesigns.Get().Where(p => p.DesignId == id).ToList();
            return designdetail;
        }
        public List<MA_Invi_Designs> Designs(InvitationRequest invitationrequest)
        {
            var designs = new List<MA_Invi_Designs>();
            if (invitationrequest.Category != null)
                designs = _Repositories.InviDesigns.Get().Where(i => i.Category == invitationrequest.Category).ToList();
            else
                designs = _Repositories.InviDesigns.Get().ToList();
            return designs;
        }

        public List<MA_User_AddBook> AddressBook(InvitationRequest invitationrequest)
        {
            var addbook = new List<MA_User_AddBook>();
            addbook = _Repositories.UserAddBook.Get().Where(i => i.UserLoginId == invitationrequest.UserLoginId).ToList();
            return addbook.ToList();
        }
    }
}
