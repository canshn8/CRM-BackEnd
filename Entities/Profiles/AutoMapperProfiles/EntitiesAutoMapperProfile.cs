using AutoMapper;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;

namespace Entities.Profiles.AutoMapperProfiles
{
    public class EntitiesAutoMapperProfile : Profile
    {
        public EntitiesAutoMapperProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<StudentContactDto, StudentContact>();
            CreateMap<StudentStartingDto, StudentStarting>();
            CreateMap<UserDto, User>();
        }
    }
}
