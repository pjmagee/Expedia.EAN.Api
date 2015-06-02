namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class Room
    {
        /// <summary>
        /// Adult guest count for the room.
        /// Properties typically accommodate no more than 4 guests before incurring extra person fees. 
        /// Do not offer more than 8 guests per room, as results will not return above this guest count for most markets.
        /// </summary>
        public int NumberOfAdults { get; set; }

        /// <summary>
        /// Child guest count for the room. Required for all properties. Used in combination with childAges to determine availability and rates.
        /// </summary>
        public int NumberOfChildren { get; set; }

        /// <summary>
        /// Always require this info from customers when child guests are specified. Unexpected extra person charges may result if children's ages are not provided prior to booking.
        /// </summary>
        public List<int> ChildAges { get; set; }

        /// <summary>
        /// Found in responses only.
        /// Key to the search parameters and other values determining the rate
        /// Note that this value is almost always different from the value returned in the hotel availability response - always pass over the value from this response to the booking request.
        /// Every time search parameters are changed (guest count change, different dates of stay, adding children, etc) a new request must be sent to obtain a new value for this parameter.
        /// For minorRev=18 and below, this element will return in the main body of the response.
        /// </summary>
        public string RateKey { get; private set; }

        /// <summary>
        /// Found in responses only.
        /// Container for NightlyRate array for the room. Rates returned are specific to the individual room and return in sequential order across the duration of the stay.
        /// For an average per-night cost across multiple rooms, use the values provided by nightlyRatesPerRoom. 
        /// Returns for minorRev=29 and higher.
        /// </summary>
        public List<NightlyRate> ChargeableNightlyRates { get; private set; }

        /// <summary>
        /// Found in responses only.
        /// Rate information converted to the customer's requested currency. Returned only if the requested currency is non-billable by the hotel or within the customer's market region. Contains the same attributes as ChargeableNightyRates. Returns for minorRev=29 and higher.
        /// </summary>
        //TODO public List<NightlyRate> ConvertedNightlyRates { get; private set; }
    }
}