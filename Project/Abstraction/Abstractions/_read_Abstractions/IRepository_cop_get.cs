using Buisness.DTOs.Query;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._read_Abstractions
{
    public interface IRepository_cop_get
    {
        Task<_cop_GetDTO_respons> _cop_Method_get(Guid order_Code);
        Task<IEnumerable<_cop_GetDTO_respons>> _all_cops_Method_get(Guid customer_PIN);
    }
}
