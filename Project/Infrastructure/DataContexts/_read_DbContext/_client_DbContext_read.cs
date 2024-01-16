using Domen.JWTModels;
using Domen.Models.QueryModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContexts.QueryDbContext
{
    public class _client_DbContext_read : IdentityDbContext<_jwt_ApplicationUser>
    {
        public _client_DbContext_read(DbContextOptions<_client_DbContext_read> options)
           : base(options)
        {

        }
        public DbSet<_product_Model_read> All_products_Model_read { get; set; }

    }
}
