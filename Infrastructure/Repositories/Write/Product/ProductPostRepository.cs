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
    public class ProductPostRepository : IProductPostRepository
    {
        private readonly WriteDbContext _dbContext;

        public ProductPostRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostProduct(ProductWriteModel product)
        {
            var response = await _dbContext.Products.SingleOrDefaultAsync(x => x.Barcode == product.Barcode);

            if (response!= null)
                throw new Exception("ResponsProduct Error: The product with this guid have already exists in database, use different guid");

            await _dbContext.Products.AddAsync(product);
        }
    }
}
