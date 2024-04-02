using Application.Incident.Commands.CreateIncident;
using Application.Incident.Commands.ImportIncident;
using Application.Incident.Commands.UpdateIncident;
using AutoMapper;

namespace Application.Incident.MappingProfiles
{
    public class IncidentCommandMappingProfile : Profile
    {
        public IncidentCommandMappingProfile()
        {
            CreateMap<CreateIncidentModel, Domain.Incident.Incident>();
            CreateMap<ImportIncidentItemModel, Domain.Incident.Incident>();
            CreateMap<UpdateIncidentModel, Domain.Incident.Incident>();
        }
    }
}
