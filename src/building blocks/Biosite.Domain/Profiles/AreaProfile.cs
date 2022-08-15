using AutoMapper;
using Biosite.Core.Commands.Response;
using Biosite.Domain.Entities;

namespace Biosite.Domain.Profiles
{
    public class AreaProfile: Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaResponse>().ReverseMap();
        }
    }
}
