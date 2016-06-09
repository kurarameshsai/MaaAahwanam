//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaaAahwanam.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_Admin_QuotationRequest
    {
        public MA_Admin_QuotationRequest()
        {
            this.MA_Quotation_Orders = new HashSet<MA_Quotation_Orders>();
            this.MA_Quotation_Vendors = new HashSet<MA_Quotation_Vendors>();
        }
    
        public int QuoteID { get; set; }
        public Nullable<int> RequestID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual MA_Budgets_QuotationRequest MA_Budgets_QuotationRequest { get; set; }
        public virtual ICollection<MA_Quotation_Orders> MA_Quotation_Orders { get; set; }
        public virtual ICollection<MA_Quotation_Vendors> MA_Quotation_Vendors { get; set; }
    }
}