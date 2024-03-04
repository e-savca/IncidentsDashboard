using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents.IncidentTypes
{
    public class IncidentType : Entity<int>
    {
        /// <summary>
        /// Name of IncidentType, child of Name.
        /// </summary>
        public string Name { get; set; }
        public List<AmbitsToTypes> ambitsToTypes { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
