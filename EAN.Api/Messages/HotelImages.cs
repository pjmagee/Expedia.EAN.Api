namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class HotelImages
    {
        public int Size { get; set; }
        public List<HotelImage> HotelImage { get; set; }
    }
}