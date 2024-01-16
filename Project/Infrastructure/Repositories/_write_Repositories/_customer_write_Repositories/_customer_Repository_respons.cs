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
    public  class _customer_Repository_respons: IRepository_customer_respons
    {
        private readonly _DbContext_write DbContext_write;

        public _customer_Repository_respons(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public async Task<_customer_Model_write> _customer_Method_respons(Guid _customer_PIN)
        {
            _customer_Model_write? customer;
            customer = await DbContext_write.All_customers_Model_write.SingleOrDefaultAsync(x => x._customer_PIN == _customer_PIN);
            try
            {
                
            }
            catch (Exception)
            {

                throw new Exception("ResponsCustomer Error: The customer with this guid have already exists in database, use different guid");
            }

            
            return customer;
        }

      
    }
}
