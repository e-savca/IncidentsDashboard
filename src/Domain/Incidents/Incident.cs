using Domain.Common;
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
    public class Incident : Entity<Guid>
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
        public DateTime ProblemStart { get; set; }

        /// <summary>
        /// Date when the request was closed.
        /// </summary>
        public DateTime ProblemEnd { get; set; }

        /// <summary>
        /// Type of request, there are 3 possible variants.
        /// </summary>
        public RequestType Type { get; set; }

        /// <summary>
        /// Type of application, alphanumeric.
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
        public string ProblemSummary { get; set; }

        /// <summary>
        /// The description of the request.
        /// </summary>
        public string ProblemDescription { get; set; }

        /// <summary>
        /// The description of the solution.
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// Scenario code.
        /// </summary>
        public string ScenarioCode { get; set; }

        /// <summary>
        /// Scenario name.
        /// </summary>
        public string ScenarioName { get; set; }

        /// <summary>
        /// Threat code.
        /// </summary>
        public string ThreatCode { get; set; }

        /// <summary>
        /// Threat name.
        /// </summary>
        public string ThreatName { get; set; }

        /// <summary>
        /// Origin of the problem.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Scope of the problem, child of origin.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Type of the problem, child of scope.
        /// </summary>
        public string ProblemType { get; set; }

        /// <summary>
        /// Name of the responsible entity.
        /// </summary>
        public string ResponsibleEntity { get; set; }
    }

}
