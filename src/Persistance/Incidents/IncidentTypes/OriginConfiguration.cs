using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.IncidentTypes
{
    public class OriginConfiguration : EntityTypeConfiguration<Origin>
    {
        public OriginConfiguration()
        {
            HasKey(o => o.Id);
            Property(o => o.Name).HasMaxLength(50).IsRequired();
        }
    }
}
