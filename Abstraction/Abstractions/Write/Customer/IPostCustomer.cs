using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface IPostCustomer
    {
        Task<CustomerWriteModel> PostCustomerAsync(CustomerWriteModel customer, CancellationToken cancellationToken);
    }
}
