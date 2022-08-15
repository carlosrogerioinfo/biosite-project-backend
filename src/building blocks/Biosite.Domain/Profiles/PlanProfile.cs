using AutoMapper;
using Biosite.Core.Commands.Response;
using Biosite.Domain.Entities;

namespace Biosite.Domain.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<Plan, PlanResponse>().ReverseMap();
        }
    }
}
