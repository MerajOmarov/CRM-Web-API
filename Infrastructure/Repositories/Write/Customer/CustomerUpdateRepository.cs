using Abstraction.Abstractions.Write.Customer;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class CustomerUpdateRepository: ICustomerUpdateRepository
    {
        private readonly ICustomerResponseRepository _response;

        public CustomerUpdateRepository(ICustomerResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateCustomerAsync(Guid oldCustomerPIN,
                                              Guid newCustomerPIN,
                                              CancellationToken cancellationToken)
        {
            var customer = await _response.ResponseCustomerAsync(oldCustomerPIN, cancellationToken);

            customer.PIN = newCustomerPIN;
        }
    }
}
