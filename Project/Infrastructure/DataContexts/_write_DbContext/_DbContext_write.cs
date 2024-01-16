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
    public class _DbContext_write : IdentityDbContext<_jwt_ApplicationUser>
    {
        public _DbContext_write(DbContextOptions<_DbContext_write> options)
         : base(options)
        {

        }
        public DbSet<_customer_Model_write> All_customers_Model_write { get; set; }
        public DbSet<_order_Model_write> All_orders_Model_write { get; set; }
        public DbSet<_product_Model_write> All_products_Model_write { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<_customer_Model_write>()
                   .HasMany(t => t._orders_Of_customer_)
                   .WithOne(s => s._order_Customer)
                   .HasForeignKey(s => s._customer_ID)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<_product_Model_write>()
                   .ToTable(tb => tb.HasTrigger("_product_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Update_Trigger"))
                   .ToTable(tb => tb.HasTrigger("_product_Remove_Trigger"))
                   .HasMany(t => t._orders_Of_product_)
                   .WithOne(s => s._order_Product)
                   .HasForeignKey(s => s._product_ID)
                   .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<_order_Model_write>()
                   .ToTable(tb => tb.HasTrigger("order_InsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("order_DeleteTrigger"))
                   .ToTable(tb => tb.HasTrigger("product_InsertTrigger"));
        


        }
    }
}
