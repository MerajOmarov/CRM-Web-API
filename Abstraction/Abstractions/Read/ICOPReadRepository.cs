using Buisness.DTOs.Query;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._read_Abstractions
{
    public interface ICOPReadRepository
    {
        Task<copReadDTO> GetCOPAsync(Guid orderCode, CancellationToken cancellationToken);
        Task<IEnumerable<copReadDTO>> GetCOPsAsync(Guid customerPIN, CancellationToken cancellationToken);
    }
}
