﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankEntities : DbContext
    {
        public BankEntities()
            : base("name=BankEntities")
        {
            this.Configuration.ProxyCreationEnabled = false; // ADD THIS LINE !
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountOffer> AccountOffers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<ScanProfile> ScanProfiles { get; set; }
        public virtual DbSet<Tranzaction> Tranzactions { get; set; }
    }
}