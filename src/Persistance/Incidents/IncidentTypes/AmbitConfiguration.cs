using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.IncidentTypes
{
    public class AmbitConfiguration : EntityTypeConfiguration<Ambit>
    {
        public AmbitConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Name).HasMaxLength(50).IsRequired();
        }
    }
}
