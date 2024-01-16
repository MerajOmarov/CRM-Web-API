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
    public  class _order_Repository_post:IRepository_order_post
    {
        private readonly _DbContext_write DbContext_write;

        public _order_Repository_post(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public async Task _order_Method_post(_order_Model_write order_model_write)
        {
            _order_Model_write? order;
            order = await DbContext_write.All_orders_Model_write.SingleOrDefaultAsync(x => x._order_Code == order_model_write._order_Code);
            if(order != null)
            {
                throw new Exception("ResponsOrder Error: The order with this guid have already exists in database, use different guid");
            }
            await DbContext_write.All_orders_Model_write.AddAsync(order_model_write);
        }
    }
}
