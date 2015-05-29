namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class Surcharges
    {
        public int Size { get; set; }
        public List<Surcharge> Surcharge { get; set; }
    }
}