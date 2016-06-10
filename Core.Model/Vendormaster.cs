using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Core.API
{
    public class Vendormaster
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Businessname { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Description { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public int Experience { get; set; }
        public string Url { get; set; }
        public string EstablishedYear { get; set; }
        public string ServicType { get; set; }
        public string Status { get; set; }
    }
}