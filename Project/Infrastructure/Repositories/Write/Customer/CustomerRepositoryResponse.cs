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
    public class CustomerRepositoryResponse: ICustomerRepositoryResponse
    {
        private readonly DbContextwrite _DbContext;

        public CustomerRepositoryResponse(DbContextwrite dbContext_write)
        {
            _DbContext = dbContext_write;
        }

        public async Task<CustomerModelwrite> ResponseCustomer(Guid CustomerPIN)
        {
            CustomerModelwrite? customer;
            customer = await _DbContext.Customers.SingleOrDefaultAsync(x => x.PIN == CustomerPIN);
            return customer;
        }

      
    }
}
