using AutoMapper;
using Domen.DTOs._read_DTOs;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings._read_Mappings
{
    public  class _product_detailed_getDTO_Mapping_read:Profile
    {
        public _product_detailed_getDTO_Mapping_read()
        {
            CreateMap<_product_Model_read,_product_detailed_GetDTO_respons>();
        }
    }
}
