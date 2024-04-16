using Application.Interfaces;
using AutoMapper;
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

namespace Application.Incident.Queries.GetExportIncidentToFile
{
    public class GetExportIncidentToFileQuery : IRequest<byte[]>
    {
        public ExportIncidentToFileFilterModel model { get; set; }
    }

    public class GetExportIncidentToFileHandler : IRequestHandler<GetExportIncidentToFileQuery, byte[]>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;
        public GetExportIncidentToFileHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<byte[]> Handle(GetExportIncidentToFileQuery request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Parse(request.model.StartDate);
            var endDate = DateTime.Parse(request.model.EndDate);            

            // Get data from database
            var incidentsQuery = _database.Incidents
                .Include(x => x.Origin)
                .Include(x => x.Ambit)
                .Include(x => x.IncidentType)
                .Include(x => x.Scenario)
                .Include(x => x.Threat)
                .AsQueryable();


            var incidents = await incidentsQuery.Where(
                i => DateTime.Compare(i.OpenedDate, startDate) >= 0 
                && DateTime.Compare(i.OpenedDate,endDate) <= 0)
                .ToListAsync(cancellationToken);


            // map data to model
            var incidentDtos = _mapper.Map<List<ExportIncidentToFileItemModel>>(incidents);

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
