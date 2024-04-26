using Domen.JWTModels;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContexts.CommandDbContext
{
    public class DbContextwrite : IdentityDbContext<JwtApplicationUser>
    {
        public DbContextwrite(DbContextOptions<DbContextwrite> options)
         : base(options)
        {

        }
        public DbSet<CustomerModelwrite> Customers { get; set; }
        public DbSet<OrderModelwrite> Orders { get; set; }
        public DbSet<ProductModelwrite> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomerModelwrite>()
                   .HasMany(t => t.OrdersOfCustomer)
                   .WithOne(s => s.Customer)
                   .HasForeignKey(s => s.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductModelwrite>()
                   .ToTable(tb => tb.HasTrigger("_product_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Update_Trigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Remove_Trigger"))
                   .HasMany(t => t.OrdersOfproduct)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.productID)
                   .OnDelete(DeleteBehavior.Cascade);
         
            builder.Entity<OrderModelwrite>()
                   .ToTable(tb => tb.HasTrigger("_order_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("_order_UpdateTrigger"))
                   .ToTable(tb => tb.HasTrigger("_order_RemoveTrigger"));
        


        }
    }
}
