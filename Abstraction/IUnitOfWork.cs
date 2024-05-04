using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IUnitOfWork
    {
        public Task SaveAsync(CancellationToken cancellationToken);
        public Task BeginTransactionAsync(IsolationLevel isolationLevel,CancellationToken cancellationToken);
        public Task CommitTransactionAsync(CancellationToken cancellationToken);
        public Task RollbackTransactionAsycn(CancellationToken cancellationToken);
    }
}
