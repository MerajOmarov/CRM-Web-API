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
    public class CustomerResponseRepository: ICustomerResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public CustomerResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerWriteModel> ResponseCustomer(Guid customerPIN)
        {
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.PIN == customerPIN);
            return customer;
        }

      
    }
}
