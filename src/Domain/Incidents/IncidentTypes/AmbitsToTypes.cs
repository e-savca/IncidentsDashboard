using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents.IncidentTypes
{
    public class AmbitsToTypes
    {
        public int AmbitId { get; set; }
        public int IncidentTypeId { get; set; }
        public Ambit Ambit { get; set; }
        public IncidentType IncidentType { get; set; }
    }
}
