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
        Task<copReadDTO> ReadCOP(Guid order_Code);
        Task<IEnumerable<copReadDTO>> ReadCOPs(Guid customer_PIN);
    }
}
