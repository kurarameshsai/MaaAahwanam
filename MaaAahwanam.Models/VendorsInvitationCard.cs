using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
    public  class VendorsInvitationCard
    {
        [Key]
        public long Id { get; set; }
        public long VendorMasterId { get; set; }
        public string CardType { get; set; }
        public string DesignName { get; set; }
        public string CardCost { get; set; }
        public string CardCostWithPrint { get; set; }
        public string MinOrder { get; set; }
        public string Status { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
