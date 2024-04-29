using Abstraction.Abstractions.Write.Customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public class CustomerPostRepository :ICustomerPostRepository
    {
        private readonly WriteDbContext _dbContext;
        public CustomerPostRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostCustomerAsync(CustomerWriteModel customer, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Customers.SingleOrDefaultAsync(x => x.PIN == customer.PIN);

            if (result != null)
                throw new Exception("ResponsCustomer Error: The customer with this guid have already exists in database, use different guid");

            await _dbContext.Customers.AddAsync(customer);
        }
    }
}
