using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.ThreatAndScenarios
{
    public class ScenarioConfiguration : EntityTypeConfiguration<Scenario>
    {
        public ScenarioConfiguration()
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.Name).IsRequired().HasMaxLength(50);
            this.Property(u => u.Code).IsRequired().HasMaxLength(50);
        }
    }
}
