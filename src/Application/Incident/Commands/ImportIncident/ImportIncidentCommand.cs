using Application.Interfaces;
using CsvHelper;
using MediatR;
using System;
using System.Collections.Generic;
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

        public ImportIncidentHandler(IDatabaseService database)
        {
            _database = database;
        }

        public async Task<bool> Handle(ImportIncidentCommand request, CancellationToken cancellationToken)
        {
            List<ImportIncidentItemModel> records;
            using (var reader = new StreamReader(request.ImporFile.InputStream))
            {
                var csv = new CsvReader(reader, culture: System.Globalization.CultureInfo.InvariantCulture);
                records = csv.GetRecords<ImportIncidentItemModel>().ToList();
            }

            // map data
            var incidentDtos = records.Select(record => new Domain.Incident.Incident
            {
                CallCode = record.CallCode,
                SubsystemCode = record.SubsystemCode,
                OpenedDate = DateTime.Parse(record.OpenedDate),
                ClosedDate = DateTime.Parse(record.ClosedDate),
                RequestType = record.RequestType,
                ApplicationType = record.ApplicationType,
                Urgency = record.Urgency,
                SubCause = record.SubCause,
                Summary = record.Summary,
                Description = record.Description,
                Solution = record.Solution,
                OriginId = record.OriginId,
                AmbitId = record.AmbitId,
                IncidentTypeId = record.IncidentTypeId,
                ScenarioId = record.ScenarioId,
                ThreatId = record.ThreatId
            }).ToList();

            // import data
            _database.Incidents.AddRange(incidentDtos);

            // save changes            
            bool result = await _database.SaveAsync(cancellationToken) > 0;

            return result;
        }
    }
}