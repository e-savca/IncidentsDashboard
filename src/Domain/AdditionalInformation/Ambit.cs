using Domain.Common;
using System.Collections.Generic;

namespace Domain.AdditionalInformation
{
    public class Ambit : Entity<int>
    {
        /// <summary>
        /// Ambit of the problem, child of origin.
        /// </summary>
        public string Name { get; set; }
        public List<OriginToAmbit> originToAmbits { get; set; }
        public List<AmbitsToTypes> ambitsToTypes { get; set; }
        public List<Incident.Incident> Incidents { get; set; }
    }
}
