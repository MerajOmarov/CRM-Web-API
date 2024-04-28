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
    public class ProductRemoveRepository : IProductRemoveRepository
    {
        private readonly WriteDbContext _dbContext;
        private readonly IProductResponseRepository _response;

        public ProductRemoveRepository(WriteDbContext dbContext, IProductResponseRepository response)
        {
            _dbContext = dbContext;
            _response = response;
        }

        public async Task<ProductWriteModel> RemoveProduct(Guid ProductBarcode)
        {
            ProductWriteModel product = await _response.ResponseProduct(ProductBarcode);

            _dbContext.Products.Remove(product);

            return product;
        }
    }
}
