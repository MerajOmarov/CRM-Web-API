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
    public  class _order_Repository_update:IRepository_order_update
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_order_respons order_Repository_respons;

        public _order_Repository_update(_DbContext_write dbContext_write, IRepository_order_respons order_Repository_respons)
        {
            DbContext_write = dbContext_write;
            this.order_Repository_respons = order_Repository_respons;
        }

        public async Task _order_Method_update(Guid order_oldCode, Guid order_newCode, DateTime order_newDeedline)
        {
            _order_Model_write order = await order_Repository_respons._order_Method_respons(order_oldCode);
            order._order_Code = order_newCode;
            order._order_Deedline = order_newDeedline;
        }
    }
}
