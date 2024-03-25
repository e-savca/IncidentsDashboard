using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.IncidentTypes
{
    public class AmbitsToTypesConfiguration : EntityTypeConfiguration<AmbitsToTypes>
    {
        public AmbitsToTypesConfiguration()
        {
            this.HasKey(ota => new { ota.AmbitId, ota.IncidentTypeId });

            this.HasRequired(ota => ota.Ambit)
                .WithMany(wm => wm.ambitsToTypes)
                .HasForeignKey(fk => fk.AmbitId);

            this.HasRequired(ota => ota.IncidentType)
                .WithMany(wm => wm.ambitsToTypes)
                .HasForeignKey(fk => fk.IncidentTypeId);
        }
    }
}
