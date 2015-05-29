namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class HotelList
    {
        public int ActivePropertyCount { get; set; }
        public int Size { get; set; }
        public List<HotelSummary> HotelSummary { get; set; }
    }
}