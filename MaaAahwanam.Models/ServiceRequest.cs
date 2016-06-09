using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using System.ComponentModel.DataAnnotations;

namespace MaaAahwanam.Models
{
    public class ServiceRequest
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string ServiceType { get; set; }
        public string Preferences { get; set; }
        public string EventAddress { get; set; }
        public string EventLocation { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string ServiceFrom { get; set; }
        public string Creater { get; set; }
        public List<SP_ADMIN_Servicerequest_Result> eventmasterlist;
        public List<SP_ADMIN_Servicerequest_Result> SP_ADMIN_Servicerequest_list;
    }
}
