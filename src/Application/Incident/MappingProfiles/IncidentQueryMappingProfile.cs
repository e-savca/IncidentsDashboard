using Application.Incident.Queries.GetExportIncidentToFile;
using Application.Incident.Queries.GetIncidentById;
using Application.Incident.Queries.GetIncidentDetailsById;
using Application.Incident.Queries.GetIncidentsList;
using AutoMapper;

namespace Application.Incident.MappingProfiles
{
    public class IncidentQueryMappingProfile : Profile
    {
        public IncidentQueryMappingProfile()
        {
            CreateMap<Domain.Incident.Incident, ExportIncidentToFileItemModel>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.Origin.Name))
                .ForMember(dest => dest.Ambit, opt => opt.MapFrom(src => src.Ambit.Name))
                .ForMember(dest => dest.IncidentType, opt => opt.MapFrom(src => src.IncidentType.Name))
                .ForMember(dest => dest.Scenario, opt => opt.MapFrom(src => src.Scenario.Name))
                .ForMember(dest => dest.Threat, opt => opt.MapFrom(src => src.Threat.Name))
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => src.OpenedDate.ToString("dd-MM-yyyy HH:mm")))
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate.ToString("dd-MM-yyyy HH:mm")));

            CreateMap<Domain.Incident.Incident, IncidentByIdModel>()
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => src.OpenedDate.ToString("yyyy-MM-ddTHH:mm")))
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate.ToString("yyyy-MM-ddTHH:mm")));

            CreateMap<Domain.Incident.Incident, IncidentDetailsByIdModel>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.Origin.Name))
                .ForMember(dest => dest.Ambit, opt => opt.MapFrom(src => src.Ambit.Name))
                .ForMember(dest => dest.IncidentType, opt => opt.MapFrom(src => src.IncidentType.Name))
                .ForMember(dest => dest.Scenario, opt => opt.MapFrom(src => src.Scenario.Name))
                .ForMember(dest => dest.Threat, opt => opt.MapFrom(src => src.Threat.Name))
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => src.OpenedDate.ToString("dd-MM-yyyy HH:mm")))
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate.ToString("dd-MM-yyyy HH:mm")));

            CreateMap<Domain.Incident.Incident, IncidentsListItemModel>()
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => src.OpenedDate.ToString("dd-MM-yyyy HH:mm")))
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate.ToString("dd-MM-yyyy HH:mm")));
        }
    }
}
