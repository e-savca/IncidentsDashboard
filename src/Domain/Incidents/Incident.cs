using Domain.Common;
using Domain.Incidents.ThreatsAndScenarios;
using Domain.Incidents.IncidentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Incidents
{
    /// <summary>
    /// Represents a row of information taken from a HelpDesk.
    /// Contains additional information taken from various data sources and then manually selected by an administrator.
    /// </summary>
    public class Incident : Entity<int>
    {
        /// <summary>
        /// Unique alphanumeric code of the request in helpdesk, maximum 17 characters.
        /// </summary>
        public string CallCode { get; set; }

        /// <summary>
        /// Text code of subsystems, maximum 2 characters.
        /// </summary>
        public string SubsystemCode { get; set; }

        /// <summary>
        /// Date when the request was created.
        /// </summary>
        public DateTime OpenedDate { get; set; }

        /// <summary>
        /// Date when the request was closed.
        /// </summary>
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// RequestType of request, there are 3 possible variants.
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// RequestType of application, alphanumeric.
        /// </summary>
        public string ApplicationType { get; set; }

        /// <summary>
        /// The urgency with which the request must be resolved.
        /// </summary>
        public string Urgency { get; set; }

        /// <summary>
        /// The sub-cause.
        /// </summary>
        public string SubCause { get; set; }

        /// <summary>
        /// The summary of the request.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The description of the request.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The description of the solution.
        /// </summary>
        public string Solution { get; set; }
        public int OriginId { get; set; }
        public int AmbitId { get; set; }
        public int IncidentTypeId { get; set; }
        public int ScenarioId { get; set; }
        public int ThreatId { get; set; }
        public Origin Origin { get; set; }
        public Ambit Ambit { get; set; }
        public IncidentType IncidentType { get; set; }
        /// <summary>
        /// Navegation property.
        /// </summary>
        public Scenario Scenario { get; set; }   

        /// <summary>
        /// Navigation property.
        /// </summary>
        public Threat Threat { get; set; }
    }

}
