namespace Domain.AdditionalInformation
{
    public class AmbitsToTypes
    {
        public int AmbitId { get; set; }
        public int IncidentTypeId { get; set; }
        public Ambit Ambit { get; set; }
        public IncidentType IncidentType { get; set; }
    }
}
