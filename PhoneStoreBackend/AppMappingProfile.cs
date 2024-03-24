using AutoMapper;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;

namespace PhoneStoreBackend
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<UserDTO, User>();
        }

    }
}
