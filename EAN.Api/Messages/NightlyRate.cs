namespace EAN.Api.Messages
{
    public class NightlyRate
    {
        public bool Promo { get; set; }
        public double BaseRate { get; set; }
        public double Rate { get; set; }
    }
}