using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    class VendorVenues
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public long VendorMasterId { get; set; }
        public string VenueType { get; set; }
        public string MinOrder { get; set; }
        public string MaxOrder { get; set; }
        public string DecorationAllowed { get; set; }
        public string HallType { get; set; }
        public string Wifi { get; set; }
        public string Menuwiththenoofitems { get; set; }
        public string Distancefrommainplaceslike { get; set; }
        public string LiveCookingStation { get; set; }
        public string Status { get; set; }
        public int SeatingCapacity { get; set; }
        public int DiningCapacity { get; set; }
        public int Minimumseatingcapacity { get; set; }
        public int Maximumcapacity { get; set; }
        public decimal VegLunchCost { get; set; }
        public decimal NonVegLunchCost { get; set; }
        public decimal VegDinnerCost { get; set; }
        public decimal NonVegDinnerCost { get; set; }
    }
}
