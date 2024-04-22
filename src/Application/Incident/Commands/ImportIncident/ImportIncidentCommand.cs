using Application.Interfaces;
using AutoMapper;
using CsvHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Application.Incident.Commands.ImportIncident
{
    public class ImportIncidentCommand : IRequest<bool>
    {
        public HttpPostedFileBase ImporFile { get; set; }
    }

    public class ImportIncidentHandler : IRequestHandler<ImportIncidentCommand, bool>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public ImportIncidentHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ImportIncidentCommand request, CancellationToken cancellationToken)
        {
            List<ImportIncidentItemModel> records;
            using (var reader = new StreamReader(request.ImporFile.InputStream))
            {
                var csv = new CsvReader(reader, culture: System.Globalization.CultureInfo.InvariantCulture);
                records = csv.GetRecords<ImportIncidentItemModel>().ToList();
            }

            // get additional information 
            var origins = await _database.Origins.ToListAsync(cancellationToken);
            var ambits = await _database.Ambits.ToListAsync(cancellationToken);
            var incidentTypes = await _database.IncidentTypes.ToListAsync(cancellationToken);
            var scenarios = await _database.Scenarios.ToListAsync(cancellationToken);
            var threats = await _database.Threats.ToListAsync(cancellationToken);

            // map data
            //var incidentDtos = records
            records = records
                .Where(record =>
                    origins.Any(x => x.Name.Equals(record.Origin)) &&
                    ambits.Any(x => x.Name.Equals(record.Ambit)) &&
                    incidentTypes.Any(x => x.Name.Equals(record.IncidentType)) &&
                    scenarios.Any(x => x.Name.Equals(record.Scenario))).ToList();

            //List<Domain.Incident.Incident> incidentDtos;

            //try
            //{
            //    //incidentDtos = _mapper.Map<Domain.Incident.Incident>();
            //    incidentDtos = records.Select(r => _mapper.Map<Domain.Incident.Incident>(r)).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            var incidentDtos = records
                .Select(record =>
                    new Domain.Incident.Incident
                    {
                        CallCode = record.CallCode,
                        SubsystemCode = record.SubsystemCode,
                        OpenedDate =DateTime.ParseExact(record.OpenedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        ClosedDate = DateTime.ParseExact(record.ClosedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        RequestType = record.RequestType,
                        ApplicationType = record.ApplicationType,
                        Urgency = record.Urgency,
                        SubCause = record.SubCause,
                        Summary = record.Summary,
                        Description = record.Description,
                        Solution = record.Solution,
                        OriginId = origins.FirstOrDefault(x => x.Name.Equals(record.Origin)).Id,
                        AmbitId = ambits.FirstOrDefault(x => x.Name.Equals(record.Ambit)).Id,
                        IncidentTypeId = incidentTypes.FirstOrDefault(x => x.Name.Equals(record.IncidentType)).Id,
                        ScenarioId = scenarios.FirstOrDefault(x => x.Name.Equals(record.Scenario)).Id,
                        ThreatId = threats.FirstOrDefault(x => x.Name.Equals(record.Threat)).Id
                    }).ToList();

            // import data
            _database.Incidents.AddRange(incidentDtos);

            // save changes            
            bool result = await _database.SaveAsync(cancellationToken) > 0;

            return result;
        }
    }
}