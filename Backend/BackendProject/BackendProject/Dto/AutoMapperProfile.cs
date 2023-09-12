using AutoMapper;
using BackendProject.Dto.UserD;
using BackendProject.Model;

namespace BackendProject.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDtoAdd>();
            CreateMap<UserDtoAdd, User>();
            CreateMap<User, UserDtoPut>();
            CreateMap<UserDtoPut, User>();
        }
    }
}
