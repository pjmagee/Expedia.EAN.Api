namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class Room
    {
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public List<int> ChildAges { get; set; }
        public string RateKey { get; set; }
    }
}