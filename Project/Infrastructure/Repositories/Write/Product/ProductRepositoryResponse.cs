using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductRepositoryResponse : IProductRepositoryResponse
    {
        private readonly DbContextwrite _DbContext;

        public ProductRepositoryResponse(DbContextwrite dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ProductModelwrite> ResponseProduct(Guid ProductBarcode)
        {
            ProductModelwrite product= await _DbContext.Products.SingleOrDefaultAsync(x => x.Barcode == ProductBarcode);
            return product;
        }

    }
}
