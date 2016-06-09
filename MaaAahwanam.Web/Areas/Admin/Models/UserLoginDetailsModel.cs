using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MaaAahwanam.Dal;


namespace MaaAahwanam.Web.Areas.Admin.Models
{
    public class UserLoginDetailsModel
    {
        public int UserLoginId { get; set; }
        public int UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string UserType { get; set; }
        public System.DateTime RegDate { get; set; }
        public string Status { get; set; }
        public string UserPhone { get; set; }

        public string Url { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string UserImgId { get; set; }
        public string UserImgName { get; set; }        

        public List<dynamic> OrderRequestList;

    }
}