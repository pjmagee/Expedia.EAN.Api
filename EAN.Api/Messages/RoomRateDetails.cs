namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class RoomRateDetails
    {
        public int RoomTypeCode { get; set; }
        public long RateCode { get; set; }
        public int MaxRoomOccupancy { get; set; }
        public int QuotedRoomOccupancy { get; set; }
        public long ExpediaPropertyId { get; set; }
        public int MinGuestAge { get; set; }
        public string RoomDescription { get; set; }
        public long PromoId { get; set; }
        public string PromoDescription { get; set; }
        public int CurrentAllotment { get; set; }
        public bool PropertyAvailable { get; set; }
        public bool PropertyRestricted { get; set; }
        public string RateKey { get; set; }
        public bool NonRefundable { get; set; }
        public List<RateInfo> RateInfos { get; set; }
        public List<ValueAdd> ValueAdds { get; set; } 
    }
}