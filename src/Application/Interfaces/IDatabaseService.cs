using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Domain.User.User> Users { get; set; }
        DbSet<Domain.User.Role> Roles { get; set; }
        DbSet<Domain.User.UserRole> UserRoles { get; set; }
        DbSet<Domain.Incident.Incident> Incidents { get; set; }
        DbSet<Domain.AdditionalInformation.Threat> Threats { get; set; }
        DbSet<Domain.AdditionalInformation.Scenario> Scenarios { get; set; }
        DbSet<Domain.AdditionalInformation.Ambit> Ambits { get; set; }
        DbSet<Domain.AdditionalInformation.IncidentType> IncidentTypes { get; set; }
        DbSet<Domain.AdditionalInformation.Origin> Origins { get; set; }
        DbSet<Domain.AdditionalInformation.AmbitsToTypes> AmbitsToTypes { get; set; }
        DbSet<Domain.AdditionalInformation.OriginToAmbit> OriginToAmbits { get; set; }

        void Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
