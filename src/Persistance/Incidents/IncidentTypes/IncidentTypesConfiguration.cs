using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.IncidentTypes
{
    public class IncidentTypesConfiguration : EntityTypeConfiguration<IncidentType>
    {
        public IncidentTypesConfiguration()
        {
            HasKey(it => it.Id);
            Property(it => it.Name).HasMaxLength(50).IsRequired();
        }
    }
}
