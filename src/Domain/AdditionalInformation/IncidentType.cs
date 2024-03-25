using Domain.Common;
using System.Collections.Generic;

namespace Domain.AdditionalInformation
{
    public class IncidentType : Entity<int>
    {
        /// <summary>
        /// Name of IncidentType, child of Name.
        /// </summary>
        public string Name { get; set; }
        public List<AmbitsToTypes> ambitsToTypes { get; set; }
        public List<Incident.Incident> Incidents { get; set; }
    }
}
