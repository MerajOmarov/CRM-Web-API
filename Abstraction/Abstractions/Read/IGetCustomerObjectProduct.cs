using Buisness.DTOs.Query;

namespace Abstraction.Abstractions.Read
{
    public interface IGetCustomerObjectProduct
    {
        Task<GetCustomerOrderProductDto> GetCOPAsync(int id,
                                     CancellationToken cancellationToken);
        Task<IEnumerable<GetCustomerOrderProductDto>> GetCOPsAsync(int id,
                                                   CancellationToken cancellationToken);
    }
}
