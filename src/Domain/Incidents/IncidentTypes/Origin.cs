using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents.IncidentTypes
{
    public class Origin : Entity<int>
    {
        /// <summary>
        /// Origin of the problem.
        /// </summary>
        public string Name { get; set; }
        public List<OriginToAmbit> originToAmbits { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
