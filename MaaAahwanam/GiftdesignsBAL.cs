using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class GiftdesignsBAL
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public int SaveInviDesigns(GIftdesign Giftdesigns)
        { 
            // hai
            MaaAahwanam.Dal.MA_Giftdesigns Gifts = new MA_Giftdesigns();
            if (Giftdesigns.giftid != 0) Gifts = _Repositories.Giftdesigns.Get().SingleOrDefault(i => i.Giftid == Giftdesigns.giftid);
            Gifts.Giftname = Giftdesigns.GiftName;
            Gifts.Description = Giftdesigns.Description;
            Gifts.Category = Giftdesigns.Category;
            Gifts.GiftCost = Giftdesigns.GiftCost;
            Gifts.VendorId =Convert.ToInt32(Giftdesigns.VendorID);
            if (Giftdesigns.Image != null)
            {
                Gifts.Image = Giftdesigns.Image;
                Gifts.ImageId = Giftdesigns.ImageId;
            }
            Gifts.CreatedBy = ValidUserUtility.ValidUser();
            Gifts.CreatedDate = DateTime.Now;
            if (Giftdesigns.giftid == 0) _Repositories.Giftdesigns.Add(Gifts);
            _Repositories.SaveChanges();
            return Gifts.Giftid;
        }
        public void SaveInviDesignsmulti(Multipleimagesgiftdesings multigiftimagemodel)
        {
            MA_Admin_giftdesigns_multipleimages multipleimages = new MA_Admin_giftdesigns_multipleimages();
            multipleimages.giftid = multigiftimagemodel.giftid;
            if (multigiftimagemodel.Image != null)
            {
                multipleimages.Image = multigiftimagemodel.Image;
                multipleimages.Imageid = multigiftimagemodel.Imageid;
            }
            _Repositories.giftdesigns_multipleimages.Add(multipleimages);
            _Repositories.SaveChanges();
        }

        public List<MA_Giftdesigns> Giftslist()
        {
            var Giftdesigns = new List<MA_Giftdesigns>();
            Giftdesigns = _Repositories.Giftdesigns.Get().ToList();
            return Giftdesigns;
        }
        public List<MA_Giftdesigns> Giftdesigns(int id)
        {
            var Giftlist = new List<MA_Giftdesigns>();
            Giftlist = _Repositories.Giftdesigns.Get().Where(p => p.Giftid == id).ToList();
            return Giftlist;
        }
        
        public void deleteGiftdesigns(int did)
        {
            var Giftlist = _Repositories.Giftdesigns.Get().Where(p => p.Giftid == did).FirstOrDefault();
            _Repositories.Giftdesigns.Delete(Giftlist);
            _Repositories.SaveChanges();
        }
    }
}
