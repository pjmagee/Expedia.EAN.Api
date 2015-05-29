namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class NightlyRatesPerRoom
    {
        public int Size { get; set; }
        public List<NightlyRate> NightlyRate { get; set; }
    }
}