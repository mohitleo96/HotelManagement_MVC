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
    
    public partial class INVENTORY
    {
        public int Invertory_ID { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int Manager_ID { get; set; }
    
        public virtual MANAGER MANAGER { get; set; }
    }
}
