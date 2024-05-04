using Abstraction;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _dbContext;

        public UnitOfWork(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel,CancellationToken cancellationToken)
        {
            await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsycn(CancellationToken cancellationToken)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
