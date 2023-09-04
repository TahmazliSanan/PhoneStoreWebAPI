using DataAccessLayer.Entities;
using DTOLayer.Dtos;

namespace ServiceLayer.Abstracts
{
    public interface IPhoneService : IBaseService<PhoneDto, Phone, PhoneDto>
    {
    }
}