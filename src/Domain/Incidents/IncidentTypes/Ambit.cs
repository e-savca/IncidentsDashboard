using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents.IncidentTypes
{
    public class Ambit : Entity<int>
    {
        /// <summary>
        /// Ambit of the problem, child of origin.
        /// </summary>
        public string Name { get; set; }
        public List<OriginToAmbit> originToAmbits { get; set; }
        public List<AmbitsToTypes> ambitsToTypes { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
