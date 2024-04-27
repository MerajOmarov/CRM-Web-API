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
    public class ClientDbContextread : IdentityDbContext<JwtApplicationUser>
    {
        public ClientDbContextread(DbContextOptions<ClientDbContextread> options)
           : base(options)
        {

        }
        public DbSet<ProductReadModel> Products { get; set; }

    }
}
