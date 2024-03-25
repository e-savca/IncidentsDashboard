namespace Domain.AdditionalInformation
{
    public class OriginToAmbit
    {
        public int OriginId { get; set; }
        public int AmbitId { get; set; }
        public Origin Origin { get; set; }
        public Ambit Ambit { get; set; }
    }
}
