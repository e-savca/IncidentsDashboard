using Domain.Incidents.IncidentTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
