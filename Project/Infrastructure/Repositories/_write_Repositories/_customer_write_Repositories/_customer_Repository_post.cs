
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public class _customer_Repository_post :IRepository_customer_post
    {
        private readonly _DbContext_write DbContext_write;
        public _customer_Repository_post(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }


        public async Task _customer_Method_post(_customer_Model_write customer_model_write)
        {
            _customer_Model_write? customer;
            customer = await DbContext_write.All_customers_Model_write.SingleOrDefaultAsync(x => x._customer_PIN == customer_model_write._customer_PIN);
            if (customer != null)
            {
                throw new Exception("ResponsCustomer Error: The customer with this guid have already exists in database, use different guid");
            }
            await DbContext_write.All_customers_Model_write.AddAsync(customer_model_write);
        }
    }

    

}
