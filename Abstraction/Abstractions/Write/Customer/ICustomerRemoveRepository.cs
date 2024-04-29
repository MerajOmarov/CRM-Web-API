using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface ICustomerRemoveRepository
    {
        Task<CustomerWriteModel> RemoveCustomerAsync(Guid customerPIN,
                                                     CancellationToken cancellationToken);
    }
}
