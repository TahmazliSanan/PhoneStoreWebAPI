using AutoMapper;
using DataAccessLayer.Entities;
using DTOLayer.Dtos;

namespace ServiceLayer.Configs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Phone, PhoneDto>();
            CreateMap<PhoneDto, Phone>();
        }
    }
}