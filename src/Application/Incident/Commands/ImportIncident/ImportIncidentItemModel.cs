namespace Application.Incident.Commands.ImportIncident
{
    public class ImportIncidentItemModel
    {
        public string CallCode { get; set; }
        public string SubsystemCode { get; set; }
        public string OpenedDate { get; set; }
        public string ClosedDate { get; set; }
        public string RequestType { get; set; }
        public string ApplicationType { get; set; }
        public string Urgency { get; set; }
        public string SubCause { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public string Origin { get; set; }
        public string Ambit { get; set; }
        public string IncidentType { get; set; }
        public string Scenario { get; set; }
        public string Threat { get; set; }
    }
}
