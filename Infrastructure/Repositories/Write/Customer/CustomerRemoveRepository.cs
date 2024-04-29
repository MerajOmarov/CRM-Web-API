using Abstraction.Abstractions.Write.Customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;

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

        public async Task<CustomerWriteModel> RemoveCustomerAsync(Guid customerPIN,
                                                                  CancellationToken cancellationToken)
        {
            CustomerWriteModel customer = await _response.ResponseCustomerAsync(customerPIN, cancellationToken);

            _dbContext.Customers.Remove(customer);

            return customer;
        }
    }
}
