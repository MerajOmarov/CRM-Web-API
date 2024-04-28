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
    public  class CustomerUpdateRepository: ICustomerUpdateRepository
    {
        private readonly ICustomerResponseRepository _response;

        public CustomerUpdateRepository(ICustomerResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateCustomer(Guid oldCustomerPIN, Guid newCustomerPIN)
        {
            var customer = await _response.ResponseCustomer(oldCustomerPIN);
            customer.PIN = newCustomerPIN;
        }
    }
}
