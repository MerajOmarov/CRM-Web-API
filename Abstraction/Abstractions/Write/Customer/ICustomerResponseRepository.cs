using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface ICustomerResponseRepository
    {
        Task<CustomerWriteModel> ResponseCustomerAsync(Guid customerPIN,
                                                       CancellationToken cancellationToken);
    }
}
