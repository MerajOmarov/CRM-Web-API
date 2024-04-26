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
    public  class CustomerRepositoryUpdate: ICustomerRepositoryUpdate
    {
        private readonly ICustomerRepositoryResponse _Response;

        public CustomerRepositoryUpdate(ICustomerRepositoryResponse response)
        {
            _Response = response;
        }

        public async Task UpdateCustomer(Guid OldCustomerPIN, Guid NewCustomerPIN)
        {
            CustomerModelwrite customer = await _Response.ResponseCustomer(OldCustomerPIN);
            customer.PIN = NewCustomerPIN;
        }
    }
}
