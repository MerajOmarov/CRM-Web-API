using Domen.JWTModels;
using Domen.Models.CommandModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                   .ToTable(tb => tb.HasTrigger("ProductInsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("ProductUpdateTrigger"))
                   .ToTable(tb => tb.HasTrigger("ProductRemoveTrigger"))
                   .HasMany(t => t.OrdersOfproduct)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductID)
                   .OnDelete(DeleteBehavior.Cascade);
         
            builder.Entity<OrderWriteModel>()
                   .ToTable(tb => tb.HasTrigger("OrderInsertTrigger"))
                   .ToTable(tb => tb.HasTrigger("OrderUpdateTrigger"))
                   .ToTable(tb => tb.HasTrigger("OrderRemoveTrigger"));

        }
    }
}
