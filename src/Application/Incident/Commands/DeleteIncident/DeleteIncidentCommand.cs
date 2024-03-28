using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Commands.DeleteIncident
{
    public class DeleteIncidentCommand : IRequest<bool>
    {
        public int IncidentId { get; set; }
    }

    public class DeleteIncidentHandler : IRequestHandler<DeleteIncidentCommand, bool>
    {
        private readonly IDatabaseService _database;
        public DeleteIncidentHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<bool> Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            if (request.IncidentId == 0)
            {
                return false;
            }

            int incidentId = request.IncidentId;

            // Get the incident from the database
            var incident = await _database.Incidents.FindAsync(cancellationToken, incidentId);

            if (incident == null)
            {
                return false;
            }

            _database.Incidents.Remove(incident);

            bool deleted = await _database.SaveAsync(cancellationToken) > 0;

            return deleted ? deleted : false;
        }
    }
}
