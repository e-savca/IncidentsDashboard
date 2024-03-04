﻿using Domain.Common;
using System.Collections.Generic;

namespace Domain.Incidents.ThreatsAndScenarios
{
    public class Scenario : Entity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
