using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class _order_Repository_respons : IRepository_order_respons
    {
        private readonly _DbContext_write DbContext_write;

        public _order_Repository_respons(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public async Task<_order_Model_write> _order_Method_respons(Guid order_Code)
        {
            _order_Model_write order;
            order = await DbContext_write.All_orders_Model_write.SingleOrDefaultAsync(x => x._order_Code == order_Code);
            return order;
        }
    }
}
