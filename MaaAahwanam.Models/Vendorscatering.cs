using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
    
    public class VendorsCatering
    {
        [Key]
        public long Id { get; set; }
        public long VendorMasterId { get; set; }
        public string CuisineType { get; set; }
        public string Veg { get; set; }
        public string NonVeg { get; set; }
        public int MinOrder { get; set; }
        public int MaxOrder { get; set; }
        public string MineralWaterIncluded { get; set; }
        public string Menuitems { get; set; }
        public string LiveCookingStation { get; set; }
        public string Status { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
