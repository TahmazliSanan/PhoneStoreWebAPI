using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DTOLayer.Dtos;
using ServiceLayer.Abstracts;

namespace ServiceLayer.Implementations
{
    public class PhoneService : BaseService<PhoneDto, Phone, PhoneDto>, IPhoneService
    {
        public PhoneService(IMapper mapper, WebAppDatabaseContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}