using Application.Incident.Commands.CreateIncident;
using Application.Incident.Commands.ImportIncident;
using Application.Incident.Commands.UpdateIncident;
using AutoMapper;
using System;
using System.Globalization;

namespace Application.Incident.MappingProfiles
{
    public class IncidentCommandMappingProfile : Profile
    {
        public IncidentCommandMappingProfile()
        {
            CreateMap<CreateIncidentModel, Domain.Incident.Incident>();
            CreateMap<UpdateIncidentModel, Domain.Incident.Incident>();
            //CreateMap<ImportIncidentItemModel, Domain.Incident.Incident>()
            //    .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.OpenedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)))
            //    .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.ClosedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)));

        }
    }
}
