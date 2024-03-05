using Domain.Incidents;
using Domain.Incidents.IncidentTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
