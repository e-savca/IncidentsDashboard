using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Commands.DeleteIncident
{
    public class DeleteIncidentCommand : IRequest
    {
        public int IncidentId { get; set; }
    }

    public class DeleteIncidentHandler : IRequestHandler<DeleteIncidentCommand>
    {
        private readonly IDatabaseService _database;
        public DeleteIncidentHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<Unit?> Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            if (request.IncidentId == 0) {
                return null;
            }
            int incidentId = request.IncidentId;

            // Get the incident from the database
            var incident = await _database.Incidents.FindAsync(cancellationToken, incidentId);

            if (incident == null)
                return null; 

            _database.Incidents.Remove(incident);
            
            await _database.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
