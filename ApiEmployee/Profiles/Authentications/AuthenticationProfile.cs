using ApiEmployee.Domain.Models;
using ApiEmployee.Dtos.Authentications;
using AutoMapper;

namespace ApiEmployee.Profiles.Authentications
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<SignInDTO, InputSignIn>();
            CreateMap<OutputSignIn, ResponseAuthDTO>();
        }
    }
}
