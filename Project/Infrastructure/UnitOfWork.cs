using Abstraction;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IRepository_UnitOfWork
    {
        private readonly _DbContext_write DbContext_write;

        public UnitOfWork(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public Task Save(CancellationToken cancellationToken)
        {
            return DbContext_write.SaveChangesAsync(cancellationToken);
        }

        
    }
}
