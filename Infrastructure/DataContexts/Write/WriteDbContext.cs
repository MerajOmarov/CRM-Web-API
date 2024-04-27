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
    public class WriteDbContext : IdentityDbContext<JwtApplicationUser>
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options)
         : base(options)
        {

        }
        public DbSet<CustomerWriteModel> Customers { get; set; }
        public DbSet<OrderWriteModel> Orders { get; set; }
        public DbSet<ProductWriteModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomerWriteModel>()
                   .HasMany(t => t.OrdersOfCustomer)
                   .WithOne(s => s.Customer)
                   .HasForeignKey(s => s.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductWriteModel>()
                   .ToTable(tb => tb.HasTrigger("_product_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Update_Trigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Remove_Trigger"))
                   .HasMany(t => t.OrdersOfproduct)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.productID)
                   .OnDelete(DeleteBehavior.Cascade);
         
            builder.Entity<OrderWriteModel>()
                   .ToTable(tb => tb.HasTrigger("_order_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("_order_UpdateTrigger"))
                   .ToTable(tb => tb.HasTrigger("_order_RemoveTrigger"));
        


        }
    }
}
