using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IRepository_UnitOfWork
    {
        public Task Save(CancellationToken cancellationToken);
    }
}
