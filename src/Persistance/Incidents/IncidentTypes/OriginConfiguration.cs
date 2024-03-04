using Domain.Incidents.IncidentTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
