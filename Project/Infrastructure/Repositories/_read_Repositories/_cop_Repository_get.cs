using Abstraction.Abstractions._read_Abstractions;
using AutoMapper;
using Buisness.DTOs.Query;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.QueryRepositories
{
    public class _cop_Repository_get : IRepository_cop_get
    {
        private readonly _company_DbContext_read company_DbContext_read;
        private readonly IMapper mapper;

        public _cop_Repository_get(_company_DbContext_read company_DbContext_read, IMapper mapper)
        {
            this.company_DbContext_read = company_DbContext_read;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<_cop_GetDTO_respons>> _all_cops_Method_get(Guid customer_PIN)
        {
            List<_cop_Model_read> allEltitiesFromDb = await company_DbContext_read.All_cops_Model_read.Where(x => x._cop_customer_PIN == customer_PIN).ToListAsync();
            List<_cop_GetDTO_respons> allRespons = new();
            _cop_GetDTO_respons respons;
            int countOfallEltitiesFromDb = allEltitiesFromDb.Count;
            for (int i = 0; i < countOfallEltitiesFromDb; i++)
            {
                respons = mapper.Map<_cop_GetDTO_respons>(allEltitiesFromDb[i]);
                allRespons.Add(respons);
            }

            return allRespons;
        }

        public async Task<_cop_GetDTO_respons> _cop_Method_get(Guid order_Code)
        {
            //Validation
            BeAnGuid(order_Code);

            //Entity from database 
            _cop_Model_read? customerOrderProductFromdb = await company_DbContext_read.All_cops_Model_read.SingleOrDefaultAsync(x => x._cop_order_Code == order_Code);
            if (customerOrderProductFromdb == null)
            {
                throw new Exception("CustomerOrderProduct Error: The CustomerOrderProduct dose not exist");
            }

            // Mapping Entity to DTO
            var respons = mapper.Map<_cop_GetDTO_respons>(customerOrderProductFromdb);

            return respons;

        }

        private void BeAnGuid(Guid guid)
        {
            if(guid==null)
            {
                throw new Exception("Validation Error: The order_Code field can not be null");
            }
            if(!(guid.GetType() == typeof(Guid)))
            {
                throw new Exception("Validation Error: The order_Code field must be guid");
            }
        }

    }
}
