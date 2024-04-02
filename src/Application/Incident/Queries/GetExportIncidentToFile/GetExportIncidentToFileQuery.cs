using Application.Interfaces;
using CsvHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Application.Incident.Queries.GetExportIncidentToFile
{
    public class GetExportIncidentToFileQuery : IRequest<byte[]> { }

    public class GetExportIncidentToFileHandler : IRequestHandler<GetExportIncidentToFileQuery, byte[]>
    {
        private readonly IDatabaseService _database;
        public GetExportIncidentToFileHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<byte[]> Handle(GetExportIncidentToFileQuery request, CancellationToken cancellationToken)
        {
            // Get data from database
            var incidents = await _database.Incidents
                .Include(x => x.Origin)
                .Include(x => x.Ambit)
                .Include(x => x.IncidentType)
                .Include(x => x.Scenario)
                .Include(x => x.Threat)
                .ToListAsync();

            // map data to model
            var incidentDtos = incidents.ConvertAll(i => new ExportIncidentToFileItemModel
            {
                CallCode = i.CallCode,
                SubsystemCode = i.SubsystemCode,
                OpenedDate = i.OpenedDate.ToString(),
                ClosedDate = i.ClosedDate.ToString(),
                RequestType = i.RequestType,
                ApplicationType = i.ApplicationType,
                Urgency = i.Urgency,
                SubCause = i.SubCause,
                Summary = i.Summary,
                Description = i.Description,
                Solution = i.Solution,
                Origin = i.Origin.Name,
                Ambit = i.Ambit.Name,
                IncidentType = i.IncidentType.Name,
                Scenario = i.Scenario.Name,
                Threat = i.Threat.Name
            });

            // create csv file
            var sb = new StringBuilder();
            sb.AppendLine("CallCode,SubsystemCode,OpenedDate,ClosedDate,RequestType," +
                "ApplicationType,Urgency,SubCause,Summary,Description,Solution," +
                "Origin,Ambit,IncidentType,Scenario,Threat");
            foreach (var item in incidentDtos)
            {
                sb.AppendLine($"{item.CallCode},{item.SubsystemCode},{item.OpenedDate},{item.ClosedDate},{item.RequestType},{item.ApplicationType},{item.Urgency},{item.SubCause},{item.Summary},{item.Description},{item.Solution},{item.Origin},{item.Ambit},{item.IncidentType},{item.Scenario},{item.Threat}");
            }
            var csvString = sb.ToString();

            // convert csv string to byte array
            byte[] bytes;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
                    csv.WriteRecords(incidentDtos);
                }
                bytes = memoryStream.ToArray();
            }
            return bytes;

        }
    }
}
