using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductUpdateRepository
    {
        Task UpdateProductAsync(Guid productOldBarcode, Guid? productNewpBarcode, double? productNewPrice);
    }
}
