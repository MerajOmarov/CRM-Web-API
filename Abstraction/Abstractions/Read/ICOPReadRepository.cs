using Buisness.DTOs.Query;

namespace Abstraction.Abstractions.Read
{
    public interface ICOPReadRepository
    {
        Task<COPReadDTO> GetCOPAsync(Guid orderCode,
                                     CancellationToken cancellationToken);
        Task<IEnumerable<COPReadDTO>> GetCOPsAsync(Guid customerPIN,
                                                   CancellationToken cancellationToken);
    }
}
