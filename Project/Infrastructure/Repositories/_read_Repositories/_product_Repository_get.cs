
using Abstraction.Abstractions._read_Abstractions;
using AutoMapper;
using Azure;
using Domen.DTOs._read_DTOs;
using Domen.DTOs.QueryDTO;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.QueryRepositories
{
    public  class _product_Repository_get: IRepository_product_get
    {
        private readonly _client_DbContext_read client_DbContext_read;
        private readonly IMapper mapper;

        public _product_Repository_get(_client_DbContext_read client_DbContext_read, IMapper mapper)
        {
            this.client_DbContext_read = client_DbContext_read;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<_product_GetDTO_respons>> _all_products_Method_get(double? product_Price)
        {
            List<_product_Model_read> allEntitiesFromDb;
            if (product_Price!=null) 
            {
                allEntitiesFromDb = await client_DbContext_read.All_products_Model_read
               .Where(x=>x._product_Price==product_Price)
               .Select(x => new _product_Model_read
                {
                    _product_Name = x._product_Name,
                    _product_Description = x._product_Description,
                    _product_Price = x._product_Price,
                    _product_Barcode = x._product_Barcode
                })
               .ToListAsync();
            }
            else
            {
               allEntitiesFromDb = await client_DbContext_read.All_products_Model_read
               .Select(x => new _product_Model_read
               {
                   _product_Name = x._product_Name,
                   _product_Description = x._product_Description,
                   _product_Price = x._product_Price,
                   _product_Barcode = x._product_Barcode
               })
              .ToListAsync();
            }
            
            List<_product_GetDTO_respons> allResponses = new();
            _product_GetDTO_respons respons;
            int countOfallEltitiesFromDb = allEntitiesFromDb.Count;
            for (int i = 0; i < countOfallEltitiesFromDb; i++)
            {
                respons = mapper.Map<_product_GetDTO_respons>(allEntitiesFromDb[i]);
                allResponses.Add(respons);
            }

            return allResponses;
        }

        public async Task<_product_detailed_GetDTO_respons> _product_Method_get(Guid product_Barcode)
        {
            _product_detailed_GetDTO_respons respon;
            _product_Model_read entityFromdb= await client_DbContext_read.All_products_Model_read.SingleOrDefaultAsync(x=>x._product_Barcode==product_Barcode);
            respon = mapper.Map<_product_detailed_GetDTO_respons>(entityFromdb);
            return respon;
        }



        
    }
}
