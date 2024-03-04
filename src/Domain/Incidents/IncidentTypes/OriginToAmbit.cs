using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents.IncidentTypes
{
    public class OriginToAmbit
    {
        public int OriginId { get; set; }
        public int AmbitId { get; set; }
        public Origin Origin { get; set; }
        public Ambit Ambit { get; set; }
    }
}
