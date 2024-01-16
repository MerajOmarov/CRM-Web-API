using Domen.DTOs._read_DTOs;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.DTOs.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._read_Abstractions
{
    public interface IRepository_product_get
    {
        Task<IEnumerable<_product_GetDTO_respons>> _all_products_Method_get(double? product_Price);
        Task<_product_detailed_GetDTO_respons> _product_Method_get(Guid product_Barcode);
    }
}
