namespace EAN.Api.Messages
{
    public class RoomType
    {
        public long RoomTypeId { get; set; }
        public string RoomCode { get; set; }
        
        /// <summary>
        /// Replaces roomTypeDescription element. Must display on individual room pages as well as any booking and booking confirmation pages.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// More detailed room description, if available.
        /// </summary>
        public string DescriptionLong { get; set; }

        /// <summary>
        /// List of room amenities if available (same content and structure as listed in the hotel information response)
        /// </summary>
        public RoomAmenities RoomAmenities { get; set; }

        /// <summary>
        /// Hotel Description Content (same content and structure as listed in the hotel information response)
        /// </summary>
        public HotelDetails HotelDetails { get; set; }

        /// <summary>
        /// Hotel Amenities Information (same content and structure as listed in the hotel information response)
        /// </summary>
        public PropertyAmenities PropertyAmenities { get; set; }

        /// <summary>
        /// Hotel Image Information (same content and structure as listed in the hotel information response)
        /// </summary>
        public HotelImages HotelImages { get; set; }
    }
}