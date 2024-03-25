using Domain.Common;
using System.Collections.Generic;

namespace Domain.AdditionalInformation
{
    public class Threat : Entity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Incident.Incident> Incidents { get; set; }
    }
}
