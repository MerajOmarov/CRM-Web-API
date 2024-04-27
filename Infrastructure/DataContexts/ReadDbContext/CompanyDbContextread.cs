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

namespace Infrastructure.DataContexts.QueryDbContext
{
    public class CompanyDbContextread : IdentityDbContext<JwtApplicationUser>
    {
        public CompanyDbContextread(DbContextOptions<CompanyDbContextread> options)
            : base(options)
        {

        }
        public DbSet<COPReadModel> ClientOrderProducts { get; set; }


    }
}
