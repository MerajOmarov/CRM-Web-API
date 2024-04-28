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
    public class ProductResponseRepository : IProductResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public ProductResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductWriteModel> ResponseProduct(Guid productBarcode)
        {
            ProductWriteModel product= await _dbContext.Products.SingleOrDefaultAsync(x => x.Barcode == productBarcode);
            return product;
        }

    }
}
