using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.ProductMapping
{
    public  class _product_deleteDTO_Mapping_write:Profile
    {
        public _product_deleteDTO_Mapping_write()
        {
            CreateMap<_product_DeleteDTO_request, _product_Model_write>();
            CreateMap<_product_Model_write, _product_DeleteDTO_respons>();
        }
    }
}
