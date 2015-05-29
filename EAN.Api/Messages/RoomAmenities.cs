namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class RoomAmenities
    {
        public int Size { get; set; }
        public List<RoomAmenity> RoomAmenity { get; set; }
    }
}