using Domain.Incidents.IncidentTypes;
using Domain.Incidents.ThreatsAndScenarios;
using Domain.Incidents;
using Domain.Users;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;
namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Incident> Incidents { get; set; }
        DbSet<Threat> Threats { get; set; }
        DbSet<Scenario> Scenarios { get; set; }
        DbSet<Ambit> Ambits { get; set; }
        DbSet<IncidentType> IncidentTypes { get; set; }
        DbSet<Origin> Origins { get; set; }
        DbSet<AmbitsToTypes> AmbitsToTypes { get; set; }
        DbSet<OriginToAmbit> OriginToAmbits { get; set; }

        void Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
