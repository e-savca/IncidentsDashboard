using Domain.Common;
using System.Collections.Generic;

namespace Domain.AdditionalInformation
{
    public class Origin : Entity<int>
    {
        /// <summary>
        /// Origin of the problem.
        /// </summary>
        public string Name { get; set; }
        public List<OriginToAmbit> originToAmbits { get; set; }
        public List<Incident.Incident> Incidents { get; set; }
    }
}
