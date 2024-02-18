using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Karim_eshop.Data.Entity.Model;
using api.Karim_eshop.Data.Context.Contract;
using System.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using api.Karim_eshop.Data.Entity.Model.OrderAggregate;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace api.Karim_eshop.Data.Entity
{
    public partial class KarimeshopDbContext : IdentityDbContext<User>
    {
        public KarimeshopDbContext()
        {
        }

        public KarimeshopDbContext(DbContextOptions<KarimeshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<UserAddress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            SeedRoles(builder);

            OnModelCreatingPartial(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
