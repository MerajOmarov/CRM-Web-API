using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface IGetCustomer
    {
        Task<CustomerWriteModel> ResponseCustomerAsync(Guid customerPIN,
                                                       CancellationToken cancellationToken);
    }
}
