﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apimvcproje.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManavEntities : DbContext
    {
        public ManavEntities()
            : base("name=ManavEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Görevli> Görevli { get; set; }
        public virtual DbSet<Manavlar> Manavlars { get; set; }
        public virtual DbSet<Meyveler> Meyvelers { get; set; }
        public virtual DbSet<Sebzeler> Sebzelers { get; set; }
    }
}
