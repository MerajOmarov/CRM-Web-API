using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_product
{
    public interface IProductRepositoryResponse
    {
        Task<ProductWriteModel> ResponseProduct(Guid product_Barcode);
    }
}
