using Abstraction.Abstractions.Write.Customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public class CustomerResponseRepository: ICustomerResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public CustomerResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerWriteModel> ResponseCustomerAsync(Guid customerPIN,
                                                                    CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.PIN == customerPIN);

            return customer;
        }
    }
}
