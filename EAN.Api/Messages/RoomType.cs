namespace EAN.Api.Messages
{
    public class RoomType
    {
        public long RoomTypeId { get; set; }
        public string RoomCode { get; set; }
        public string Description { get; set; }
        public string DescriptionLong { get; set; }
        public RoomAmenities RoomAmenities { get; set; }
    }
}