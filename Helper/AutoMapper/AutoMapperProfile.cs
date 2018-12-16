using AutoMapper;
using Code.Controllers.Resources.Http.ResponseResources;
using Code.Core.Models;

namespace Code.Helper.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {


            // ------- From Domain to Resource
            CreateMap<User, UserResponseResource>();
        }
    }
}