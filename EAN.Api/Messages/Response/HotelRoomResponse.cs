namespace EAN.Api.Messages.Response
{
    /// <summary>
    /// Each node contains rates and details for an individual room at the hotel. 
    /// The JSON response format of this array may cause issues in Axis.
    /// 
    /// Well I don't use Apache Axis, so i guess im lucky :)
    /// </summary>
    public class HotelRoomResponse : CommonResponse
    {
        public long RateCode { get; set; }
        public string RateDescription { get; set; }
        public RoomType RoomType { get; set; }
        public SupplierType SupplierType { get; set; }
        public string OtherInformation { get; set; }
        public bool ImmediateChargeRequired { get; set; }
        public int PropertyId { get; set; }
        public string SmokingPreferences { get; set; }
        public int MinGuestAge { get; set; }
        public int MaxRoomOccupancy { get; set; }
        public int QuotedOccupancy { get; set; }
        public int RateOccupancyPerRoom { get; set; }
        public string DeepLink { get; set; }
        public BedTypes BedTypes { get; set; }
        public ValueAdds ValueAdds { get; set; }
        public RoomImages RoomImages { get; set; }
        public RateInfos RateInfos { get; set; }
    }
}