using Application.AdditionalInformation.Queries.GetAmbitListByOriginId;
using Application.AdditionalInformation.Queries.GetIncidentTypeListByAmbitId;
using Application.AdditionalInformation.Queries.GetOriginList;
using Application.AdditionalInformation.Queries.GetScenarioList;
using Application.AdditionalInformation.Queries.GetThreatList;
using AutoMapper;

namespace Application.AdditionalInformation.MappingProfiles
{
    public class AdditionalInformationQueryMappingProfile : Profile
    {
        public AdditionalInformationQueryMappingProfile()
        {
            CreateMap<Domain.AdditionalInformation.Ambit, AmbitListByOriginIdItemModel>();
            CreateMap<Domain.AdditionalInformation.IncidentType, IncidentTypeListByAmbitIdItemModel>();
            CreateMap<Domain.AdditionalInformation.Origin, OriginListItemModel>();
            CreateMap<Domain.AdditionalInformation.Scenario, ScenarioListItemModel>();
            CreateMap<Domain.AdditionalInformation.Threat, ThreatListItemModel>();
        }
    }
}
