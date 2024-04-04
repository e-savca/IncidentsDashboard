using Application.Interfaces;
using AutoMapper;
using Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Queries.GetIncidentsList
{
    public class GetIncidentsListQuery : IRequest<DataTableResponseModel<IncidentsListItemModel>>
    {
        public string Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public string SortColumnName { get; set; }
        public string SortDirection { get; set; }
    }
    public class GetIncidentsListHandler : IRequestHandler<GetIncidentsListQuery, DataTableResponseModel<IncidentsListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetIncidentsListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<DataTableResponseModel<IncidentsListItemModel>> Handle(GetIncidentsListQuery request, CancellationToken cancellationToken)
        {

            // Get data from database as IQueryable for better query composition and deferred execution
            var incidentsQuery = _database.Incidents.AsQueryable();

            int _recordsTotal = incidentsQuery.Count();

            // search
            if (!string.IsNullOrEmpty(request.Search))
            {
                incidentsQuery = incidentsQuery.Where(x =>
                    x.CallCode.ToLower().Contains(request.Search.ToLower())
                    || x.SubsystemCode.ToLower().Contains(request.Search.ToLower())
                    || x.OpenedDate.ToString().ToLower().Contains(request.Search.ToLower())
                    || x.ClosedDate.ToString().ToLower().Contains(request.Search.ToLower())
                    || x.RequestType.ToLower().Contains(request.Search.ToLower())
                    || x.ApplicationType.ToLower().Contains(request.Search.ToLower())
                    || x.Urgency.ToLower().Contains(request.Search.ToLower())
                    || x.SubCause.ToLower().Contains(request.Search.ToLower())
                    || x.Summary.ToLower().Contains(request.Search.ToLower())
                    || x.Description.ToLower().Contains(request.Search.ToLower())
                    || x.Solution.ToLower().Contains(request.Search.ToLower())
                    || x.Origin.Name.ToLower().Contains(request.Search.ToLower())
                    || x.Ambit.Name.ToLower().Contains(request.Search.ToLower())
                    || x.IncidentType.Name.ToLower().Contains(request.Search.ToLower())
                    || x.Scenario.Name.ToLower().Contains(request.Search.ToLower())
                    || x.Threat.Name.ToLower().Contains(request.Search.ToLower())
                );
            }

            // sort
            if (!string.IsNullOrEmpty(request.SortColumnName) && !string.IsNullOrEmpty(request.SortDirection))
            {
                incidentsQuery = incidentsQuery.OrderBy($"{request.SortColumnName} {request.SortDirection}");
            }
            else
            {
                incidentsQuery = incidentsQuery.OrderByDescending(x => x.OpenedDate);
            }

            int _recordsFiltered = incidentsQuery.Count();

            // paging
            var incidents = await incidentsQuery.Skip(request.Start).Take(request.Length).ToListAsync(cancellationToken);

            var response = new DataTableResponseModel<IncidentsListItemModel>
            {
                draw = request.Draw,
                recordsTotal = _recordsTotal,
                recordsFiltered = _recordsFiltered,
                data = _mapper.Map<List<IncidentsListItemModel>>(incidents)
            };

            return response;
        }
    }
}