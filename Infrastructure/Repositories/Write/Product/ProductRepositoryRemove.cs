using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductRepositoryRemove : IProductRepositoryRemove
    {
        private readonly WriteDbContext _DbContext;
        private readonly IProductRepositoryResponse _Response;

        public ProductRepositoryRemove(WriteDbContext dbContext_write, IProductRepositoryResponse product_Repository_respons)
        {
            _DbContext = dbContext_write;
            _Response = product_Repository_respons;
        }

        public async Task<ProductWriteModel> RemoveProduct(Guid ProductBarcode)
        {
            ProductWriteModel product = await _Response.ResponseProduct(ProductBarcode);
            _DbContext.Products.Remove(product);
            return product;
        }
    }
}
