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
            this.HasRequired(ota => ota.Origin)
                .WithMany(wm => wm.originToAmbits)
                .HasForeignKey(fk => fk.OriginId);

            this.HasRequired(ota => ota.Ambit)
                .WithMany(wm => wm.originToAmbits)
                .HasForeignKey(fk => fk.AmbitId);
        }

    }
}
