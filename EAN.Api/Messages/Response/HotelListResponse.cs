namespace EAN.Api.Messages.Response
{
    public class HotelListResponse : CommonResponse
    {
        public CachedSupplierResponse CachedSupplierResponse { get; set; }
        public string CacheKey { get; set; }
        public string CacheLocation { get; set; }
        public HotelList HotelList { get; set; }
        public bool MoreResultsAvailable { get; set; }
        public int NumberOfRoomsRequested { get; set; } 
    }
}
