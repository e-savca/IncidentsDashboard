using Domain.Incidents.IncidentTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
