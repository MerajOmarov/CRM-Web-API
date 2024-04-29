using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface ICustomerPostRepository
    {
        Task PostCustomerAsync(CustomerWriteModel model,
                               CancellationToken cancellationToken);
    }
}
