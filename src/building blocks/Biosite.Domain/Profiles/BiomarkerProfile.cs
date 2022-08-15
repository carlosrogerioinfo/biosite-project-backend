using AutoMapper;
using Biosite.Domain.Commands.Response;
using Biosite.Domain.Entities;

namespace Biosite.Domain.Profiles
{
    public class BiomarkerProfile: Profile
    {
        public BiomarkerProfile()
        {
            CreateMap<Biomarker, BiomarkerResponse>().ReverseMap();
        }
    }
}
