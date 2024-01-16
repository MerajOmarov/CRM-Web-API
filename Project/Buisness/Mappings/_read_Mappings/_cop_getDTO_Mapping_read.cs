using AutoMapper;
using Buisness.DTOs.Query;
using Domen.DTOs.QueryDTO;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapping.Query
{
    public class _cop_getDTO_Mapping_read:Profile
    {
        public _cop_getDTO_Mapping_read()
        {
            CreateMap<_cop_Model_read, _cop_GetDTO_respons>();
        }
    }
}
