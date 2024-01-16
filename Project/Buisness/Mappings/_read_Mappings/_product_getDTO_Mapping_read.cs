using AutoMapper;
using Domen.DTOs.QueryDTO;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.QueryMapping
{
    public  class _product_getDTO_Mapping_read:Profile
    {
        public _product_getDTO_Mapping_read()
        {
            CreateMap<_product_Model_read, _product_GetDTO_respons>();
        }
    }
}
