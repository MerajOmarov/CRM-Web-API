using AutoMapper;
using Buisness.DTOs.Query;
using Domen.Models.QueryModel;

namespace Buisness.Mapping.Read
{
    public class COPGetDTOReadMapper:Profile
    {
        public COPGetDTOReadMapper()
        {
            CreateMap<COPReadModel, copReadDTO>();
        }
    }
}
