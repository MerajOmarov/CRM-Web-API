using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class _customer_Repository_remove: IRepository_customer_remove
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_customer_respons customer_Repositoty_respons;

        public _customer_Repository_remove(_DbContext_write dbContext_write, IRepository_customer_respons customer_Repositoty_respons)
        {
            DbContext_write = dbContext_write;
            this.customer_Repositoty_respons = customer_Repositoty_respons;
        }

        public async Task<_customer_Model_write> _customer_Method_remove(Guid customer_PIN)
        {
            _customer_Model_write customer = await customer_Repositoty_respons._customer_Method_respons(customer_PIN);
            DbContext_write.All_customers_Model_write.Remove(customer);
            return customer;
        }
    }
}
