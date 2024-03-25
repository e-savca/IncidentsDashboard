using Domain.Incident;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Incidents
{
    public class IncidentConfiguration : EntityTypeConfiguration<Incident>
    {
        public IncidentConfiguration()
        {
            this.HasRequired(incident => incident.Threat)
                .WithMany(wm => wm.Incidents)
                .HasForeignKey(fk => fk.ThreatId);

            this.HasRequired(incident => incident.Scenario)
                .WithMany(wm => wm.Incidents)
                .HasForeignKey(fk => fk.ScenarioId);
            
            this.HasRequired(incident => incident.Origin)
                .WithMany(wm => wm.Incidents)
                .HasForeignKey(fk => fk.OriginId);
            
            this.HasRequired(incident => incident.Ambit)
                .WithMany(wm => wm.Incidents)
                .HasForeignKey(fk => fk.AmbitId);

            this.HasRequired(incident => incident.IncidentType)
                .WithMany(wm => wm.Incidents)
                .HasForeignKey(fk => fk.IncidentTypeId);


        }
    }
}
