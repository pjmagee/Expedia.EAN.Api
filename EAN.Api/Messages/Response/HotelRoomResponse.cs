using System.Collections.Generic;
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
        /// <summary>
        /// Additional miscellaneous policies, e.g. photo ID required for check-in.
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// Code to the displayed rate.
        /// </summary>
        public string RateCode { get; set; }

        /// <summary>
        /// Room type code for the room. 
        /// If the options parameter was sent in the room availability request, this element will not return. The value is instead sent as the roomCode attribute of the RoomType object.
        /// </summary>
        public string RoomTypeCode { get; set; }

        /// <summary>
        /// Short description of both the room and the rate to be charged, e.g. Deluxe Room King - All Inclusive.
        /// Recommended for primary display.
        /// </summary>
        public string RateDescription { get; set; }

        /// <summary>
        /// Short description of the room type, e.g. Deluxe Room King.
        /// If the options parameter was sent in the room availability request, this element will not return. The value is instead sent as the description element within the RoomType object.
        /// </summary>
        public string RoomTypeDescription { get; set; }

        /// <summary>
        /// Supplier of the hotel. This same supplier will be used to process any reservations placed.
        /// </summary>
        public SupplierType SupplierType { get; set; }

        /// <summary>
        /// Other miscellaneous info on the hotel, if available.
        /// </summary>
        public string OtherInformation { get; set; }

        /// <summary>
        /// Expedia's ID for the hotel. Use this value to map to a hotelId when cross-referencing to Expedia. A complete cross-reference file is also available in the database catalog.
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Available smoking preferences for the room, if any. Comma separated list of strings
        /// Values:
        /// NS: non-smoking
        /// S: smoking
        /// E: either
        /// </summary>
        public string SmokingPreferences { get; set; }

        /// <summary>
        /// The minimum age of any guests in the room, e.g. 18 or 21 if children are not allowed.. Will return as 0 or not at all if there is no minimum age.
        /// </summary>
        public int MinGuestAge { get; set; }

        /// <summary>
        /// Guest count upon which the provided room rate is based. May be less than the specified guest count if the room rate does not change between this guest count and the guest count provided in rateOccupancyPerRoom.
        /// </summary>
        public int QuotedOccupancy { get; set; }

        /// <summary>
        /// Indicates how many guests the room can accommodate for the provided rate. 
        /// If the requested guest count exceeds this value (or the total of these values, for multiple rooms), alert users to such discrepancies to make them aware of potential extra person charges or the hotel's inability to fully accommodate their party prior to booking.
        /// </summary>
        public int RateOccupancyPerRoom { get; set; }

        /// <summary>
        /// Deep link into the corresponding room availability page on your template, used if you are creating a hybrid site. 
        /// Format returned is only compatible with legacy template accounts. If you have a Chameleon template account, the URL will return an error. Refer to the deep link formatting guide on the hybrid sites page to create deep links compatible with your template.
        /// These links can also be masked with a CNAME.
        /// </summary>
        public string DeepLink { get; set; }

        /// <summary>
        /// The bed type choices for the individual room. May return a single bed type or a choice to include at booking time.
        /// </summary>
        public BedTypes BedTypes { get; set; }

        /// <summary>
        /// Contains an array of ValueAdd elements, if available, for the provided room and rate. Has a size attribute to indicate the number of value adds returned.
        /// </summary>
        public ValueAdds ValueAdds { get; set; }

        /// <summary>
        /// Array of any available room-level image URLs, if requested via the includeRoomImages parameter.
        /// </summary>
        public RoomImages RoomImages { get; set; }
        
        /// <summary>
        /// Returned when options parameter is sent with a value of ROOM_TYPES and/or ROOM_AMENITIES.
        /// </summary>
        public RoomType RoomType { get; set; }
        
        /// <summary>
        /// Contains an array of RateInfo elements that provide detailed rate information for individual rooms. 
        /// If you are using an older integration running on minorRev=6 or earlier, RateInfo will return without the RateInfos container.
        /// </summary>
        public RateInfos RateInfos { get; set; }
    }
}