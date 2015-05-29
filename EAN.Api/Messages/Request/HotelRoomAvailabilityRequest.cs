namespace EAN.Api.Messages.Request
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Retrieve all available rooms at a specific hotel that accomodate the provided guest count and any other criteria.
    /// This request is required prior to placing a reservation - it returns the specific rateKey needed for a successful booking.
    ///  <remarks>
    /// All nullable value types are optional for the api request
    /// </remarks> 
    /// </summary>
    public class HotelRoomAvailabilityRequest
    {
        /// <summary>
        /// ID of the property to query for room availability
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Check-in date, in MM/DD/YYYY format.
        /// 500 day advance limit for Expedia Collect.
        /// 320 day advance limit for Hotel Collect.
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Check-out date, in MM/DD/YYYY format.
        /// Total length of stay cannot exceed 29 nights. 
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Container for the Room arrays that define guest and room count.
        /// If you used REST in your list request, remember to continue to follow the unique REST format.
        /// </summary>
        public List<Room> RoomGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IncludeDetails { get; set; }

        /// <summary>
        /// This parameter is valid for condos/vacation rentals only. 
        /// Specifies the number of bedrooms requested - 4 maximum.
        /// </summary>
        public int NumberOfBedrooms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IncludeRoomImages { get; set; }

        /// <summary>
        /// With minorRev=12 or higher, use this parameter in place of a separate hotel information request.
        /// Send a single value or combination of values (comma-separated list for XML and REST)
        /// 
        /// HOTEL_DETAILS
        /// ROOM_TYPES
        /// ROOM_AMENITIES
        /// PROPERTY_AMENITIES
        /// HOTEL_IMAGES
        /// </summary>
        public List<string> Options { get; set; }

        public string SupplierType { get; set; }
        public string RateKey { get; set; }
        public string RoomTypeCode { get; set; }
        public string RateCode { get; set; }
    }
}
