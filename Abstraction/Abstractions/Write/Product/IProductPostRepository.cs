using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductPostRepository
    {
        Task PostProductAsync(ProductWriteModel model);
    }
}
