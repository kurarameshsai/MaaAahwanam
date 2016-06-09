using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class VendorImagesDetailsModel
    {
        public int UserBusiId { get; set; }
        public int UserBusiImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string UserImgId { get; set; }
    }
}