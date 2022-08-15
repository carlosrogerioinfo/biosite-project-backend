using AutoMapper;
using Biosite.Core.Commands.Response;
using Biosite.Domain.Entities;

namespace Biosite.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.PlanResponse, opt => opt.MapFrom(src => src.Plan))
                .ReverseMap();

            CreateMap<User, ProfileResponse>()
                .ForMember(dest => dest.PlanResponse, opt => opt.MapFrom(src => src.Plan))
                .ReverseMap();
        }
    }
}
