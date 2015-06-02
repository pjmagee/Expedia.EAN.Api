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
    public class RoomAvailabilityRequest
    {
        /// <summary>
        /// ID of the property to query for room availability
        /// </summary>
        public long HotelId { get; set; }

        /// <summary>
        /// Include today's date to request same-day availability.
        /// Bookings may be made up to 11:59PM local hotel time (9:59PM for PST and Pacific islands).
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Availability can be searched up to 500 days in advance of this date.
        /// Total length of stay cannot be greater than 28 nights.
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// This parameter is valid for condos/vacation rentals only. 
        /// Specifies the number of bedrooms requested - 4 maximum.
        /// </summary>
        public int? NumberOfBedrooms { get; set; }

        /// <summary>
        /// Supply the same value returned in the previous hotel list response.
        /// Values: "E" (Expedia Collect)
        /// </summary>
        public string SupplierType { get; set; }

        /// <summary>
        /// Key for the parameters that determined the rate provided in the prior hotel list response.
        /// </summary>
        public string RateKey { get; set; }

        /// <summary>
        /// Container for the Room arrays that define guest and room count.
        /// </summary>
        public List<Room> RoomGroup { get; set; }

        /// <summary>
        /// Used only if the customer's specific room choice is already known. This will return the cancellation policy, bed types, and smoking preferences for the room.
        /// Send together with rateCode
        /// </summary>
        public string RoomTypeCode { get; set; }

        /// <summary>
        /// Used only if the customer's specific room choice is already known. This will return the cancellation policy, bed types, and smoking preferences for the room.
        /// Send together with roomTypeCode
        /// </summary>
        public string RateCode { get; set; }

        /// <summary>
        /// Unlike in the hotel list request, this parameter only controls whether rates returned are cached or uncached (requested directly from the databases) with corresponding speed and accuracy impacts.
        /// Sending as true will return a direct, uncached rate. Sending as false will return a cached rate.
        /// Defaults to false if omitted or sent empty.
        /// </summary>
        public bool IncludeDetails { get; set; }

        /// <summary>
        /// Retrieves room-level images for the specified hotelId.
        /// Also available as a standalone request. http://developer.ean.com/docs/room-images 
        /// </summary>
        public bool IncludeRoomImages { get; set; }

        /// <summary>
        /// Returns a more detailed response structure for the HotelFees array that includes how often each fee applies and how it is applied. Available with minorRev=24 and higher.
        /// </summary>
        public bool IncludeHotelFeeBreakdown { get; set; }

        /// <summary>
        /// With minorRev=12 or higher, use this parameter in place of a separate hotel information request.
        /// Send a single value or combination of values
        /// </summary>
        public List<RoomAvailibilityOption> Options { get; set; }

        public RoomAvailabilityRequest()
        {
            this.Options = new List<RoomAvailibilityOption>();
        }
    }
}
