using Domen.DTOs.Write.Customer;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Customer
{
    public interface IDeleteCustomer
    {
        Task<CustomerWriteModel> DeleteCustomerAsync(DeleteCustomerRequest request, CancellationToken cancellationToken);
    }
}
