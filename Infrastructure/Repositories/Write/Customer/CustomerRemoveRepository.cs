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
    public  class CustomerRemoveRepository: ICustomerRemoveRepository
    {
        private readonly WriteDbContext _dbContext;
        private readonly ICustomerResponseRepository _response;

        public CustomerRemoveRepository(WriteDbContext dbContext, ICustomerResponseRepository response)
        {
            _dbContext = dbContext;
            _response = response;
        }

        public async Task<CustomerWriteModel> RemoveCustomer(Guid customerPIN)
        {
            CustomerWriteModel customer = await _response.ResponseCustomer(customerPIN);
            _dbContext.Customers.Remove(customer);
            return customer;
        }
    }
}
