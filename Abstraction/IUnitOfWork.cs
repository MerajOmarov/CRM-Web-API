using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IUnitOfWork
    {
        public Task SaveAsync(CancellationToken cancellationToken);
    }
}
