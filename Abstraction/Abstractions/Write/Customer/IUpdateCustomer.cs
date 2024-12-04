using Buisness.DTOs.Command.Customer;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface IUpdateCustomer
    {
        Task<CustomerWriteModel> UpdateCustomerAsync(UpdateCustomerRequest request, CancellationToken cancellationToken);
    }
}
