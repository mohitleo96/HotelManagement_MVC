//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILL
    {
        public int Billing_Number { get; set; }
        public string Transaction_Type { get; set; }
        public Nullable<int> Day { get; set; }
        public int Reservation_ID { get; set; }
        public decimal Total_Bill { get; set; }
    
        public virtual Reservation Reservation { get; set; }
    }
}