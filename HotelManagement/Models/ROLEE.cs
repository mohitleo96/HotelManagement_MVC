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
    
    public partial class ROLEE
    {
        public int Role_ID { get; set; }
        public int ID { get; set; }
        public string Role { get; set; }
    
        public virtual STAFF STAFF { get; set; }
    }
}
