﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelManagementDBEntities2 : DbContext
    {
        public HotelManagementDBEntities2()
            : base("name=HotelManagementDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<MANAGER> MANAGERs { get; set; }
        public virtual DbSet<OWNER> OWNERs { get; set; }
        public virtual DbSet<RECEPTIONIST> RECEPTIONISTs { get; set; }
        public virtual DbSet<ROLEE> ROLEEs { get; set; }
        public virtual DbSet<STAFF> STAFFs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<INVENTORY> INVENTORies { get; set; }
        public virtual DbSet<SearchRoomViewModel> SearchRoomViewModels { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ROOM> ROOMs { get; set; }
        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<SMTP> SMTPs { get; set; }
    }
}
