﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace acessos_trilha_auditoria.Model
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AuditoriaContext : DbContext
    {
        public AuditoriaContext()
            : base("name=AuditoriaContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<change> change { get; set; }
        public virtual DbSet<log> log { get; set; }
    }
}