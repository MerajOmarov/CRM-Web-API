
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
    public class CustomerRepositoryPost :ICustomerRepositoryPost
    {
        private readonly DbContextwrite _DbContext;
        public CustomerRepositoryPost(DbContextwrite DbContext)
        {
            _DbContext = DbContext;
        }


        public async Task PostCustomer(CustomerWriteModel Customer)
        {
            //CustomerWriteModel? customer;
            var result = await _DbContext.Customers.SingleOrDefaultAsync(x => x.PIN == Customer.PIN);
            if (result != null)
            {
                throw new Exception("ResponsCustomer Error: The customer with this guid have already exists in database, use different guid");
            }
            await _DbContext.Customers.AddAsync(Customer);
        }
    }

    

}
