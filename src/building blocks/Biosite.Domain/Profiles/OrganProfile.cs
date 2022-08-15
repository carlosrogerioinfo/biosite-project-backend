using AutoMapper;
using Biosite.Domain.Commands.Response;
using Biosite.Domain.Entities;

namespace Biosite.Domain.Profiles
{
    public class OrganProfile: Profile
    {
        public OrganProfile()
        {
            CreateMap<Organ, OrganResponse>().ReverseMap();
        }
    }
}
