using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class _order_Repository_remove : IRepository_order_remove
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_order_respons order_Repository_respons;

        public _order_Repository_remove(_DbContext_write dbContext_write, IRepository_order_respons order_Repository_respons)
        {
            DbContext_write = dbContext_write;
            this.order_Repository_respons = order_Repository_respons;
        }

        public async Task<_order_Model_write> _order_Method_remove(Guid order_Code)
        {
            _order_Model_write order = await order_Repository_respons._order_Method_respons(order_Code);
            DbContext_write.All_orders_Model_write.Remove(order);
            return order;
        }
    }
}
