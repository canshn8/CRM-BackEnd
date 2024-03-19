using AutoMapper;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Profiles.AutoMapperProfiles
{
    public class EntitiesAutoMapperProfile : Profile
    {
        public EntitiesAutoMapperProfile()
        {
            CreateMap<StudentDto, Student>();
        }
    }
}
