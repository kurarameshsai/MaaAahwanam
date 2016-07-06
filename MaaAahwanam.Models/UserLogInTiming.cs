using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaAahwanam.Models
{
    
    public class UserLogInTiming
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}