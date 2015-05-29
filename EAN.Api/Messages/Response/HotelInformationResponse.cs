namespace EAN.Api.Messages.Response
{
    public class HotelInformationResponse
    {
        public long HotelId { get; set; }
        public string CustomerSessionId { get; set; }
        public HotelSummary HotelSummary { get; set; }
        public HotelDetails HotelDetails { get; set; }
        public Suppliers Suppliers { get; set; }
        public RoomTypes RoomTypes { get; set; }
        public PropertyAmenities PropertyAmenities { get; set; }
        public HotelImages HotelImages { get; set; }
        public EanWsError EanWsError { get; set; }
    }
}
