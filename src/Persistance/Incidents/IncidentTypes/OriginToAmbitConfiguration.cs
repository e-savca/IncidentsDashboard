using Domain.AdditionalInformation;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.Incidents.IncidentTypes
{
    public class OriginToAmbitConfiguration : EntityTypeConfiguration<OriginToAmbit>
    {
        public OriginToAmbitConfiguration()
        {
            this.HasKey(oa => new { oa.OriginId, oa.AmbitId });

            this.HasRequired(oa => oa.Origin)
                .WithMany(wm => wm.originToAmbits)
                .HasForeignKey(fk => fk.OriginId);

            this.HasRequired(oa => oa.Ambit)
                .WithMany(wm => wm.originToAmbits)
                .HasForeignKey(fk => fk.AmbitId);
        }

    }
}
