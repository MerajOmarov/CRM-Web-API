using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class _customer_Repository_update: IRepository_customer_update
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_customer_respons customer_Repository_respons;

        public _customer_Repository_update(_DbContext_write dbContext_write, IRepository_customer_respons customer_Repository_respons)
        {
            DbContext_write = dbContext_write;
            this.customer_Repository_respons = customer_Repository_respons;
        }

        public async Task _customer_Method_update(Guid customer_oldPIN, Guid customer_newPIN)
        {
            _customer_Model_write customer = await customer_Repository_respons._customer_Method_respons(customer_oldPIN);
            customer._customer_PIN = customer_newPIN;
        }
    }
}
