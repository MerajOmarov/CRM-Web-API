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
    public class ProductRepositoryPost : IProductRepositoryPost
    {
        private readonly DbContextwrite _DbContext;

        public ProductRepositoryPost(DbContextwrite dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task PostProduct(ProductModelwrite product)
        {
            var response = await _DbContext.Products.SingleOrDefaultAsync(x => x.Barcode == product.Barcode);
            if (response!= null)
            {
                throw new Exception("ResponsProduct Error: The product with this guid have already exists in database, use different guid");
            }
            await _DbContext.Products.AddAsync(product);
        }
    }
}
