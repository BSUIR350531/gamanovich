﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChooseYourBike.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BikeSiteDBEntities : DbContext
    {
        public BikeSiteDBEntities()
            : base("name=BikeSiteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accesories> Accesories { get; set; }
        public virtual DbSet<Brakes> Brakes { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Fork> Fork { get; set; }
        public virtual DbSet<Frame> Frame { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Pedals> Pedals { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Saddle> Saddle { get; set; }
        public virtual DbSet<Shifters> Shifters { get; set; }
        public virtual DbSet<StrWheel> StrWheel { get; set; }
        public virtual DbSet<Transmission> Transmission { get; set; }
        public virtual DbSet<Wheels> Wheels { get; set; }
        public virtual DbSet<Advertising> Advertising { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Image> Image { get; set; }
    }
}
