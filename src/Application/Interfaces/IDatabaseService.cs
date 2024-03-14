using Domain.Incidents.IncidentTypes;
using Domain.Incidents.ThreatsAndScenarios;
using Domain.Incidents;
using Domain.Users;
using System.Data.Entity;
using System.Threading.Tasks;
namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<UserRole> UserRoles { get; set; }
        IDbSet<Incident> Incidents { get; set; }
        IDbSet<Threat> Threats { get; set; }
        IDbSet<Scenario> Scenarios { get; set; }
        IDbSet<Ambit> Ambits { get; set; }
        IDbSet<IncidentType> IncidentTypes { get; set; }
        IDbSet<Origin> Origins { get; set; }
        IDbSet<AmbitsToTypes> AmbitsToTypes { get; set; }
        IDbSet<OriginToAmbit> OriginToAmbits { get; set; }

        void Save();
        Task<int> SaveAsync();
    }
}
