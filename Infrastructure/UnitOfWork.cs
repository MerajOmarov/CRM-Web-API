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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextwrite _DbContext_write;

        public UnitOfWork(DbContextwrite dbContext_write)
        {
            _DbContext_write = dbContext_write;
        }

        public Task Save(CancellationToken cancellationToken)
        {
            return _DbContext_write.SaveChangesAsync(cancellationToken);
        }

        
    }
}
