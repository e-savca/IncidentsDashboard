namespace Application.Incident.Queries.GetIncidentsList
{
    public class IncidentsListItemModel
    {
        public int Id { get; set; }
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
        public int OriginId { get; set; }
        public int AmbitId { get; set; }
        public int IncidentTypeId { get; set; }
        public int ScenarioId { get; set; }
        public int ThreatId { get; set; }
    }
}
