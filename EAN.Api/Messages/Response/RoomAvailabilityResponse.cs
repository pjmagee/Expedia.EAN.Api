namespace EAN.Api.Messages.Response
{
    using System;
    using System.Collections.Generic;

    public class RoomAvailabilityResponse : CommonResponse
    {
        /// <summary>
        /// ID for the property. This same ID will be used in any subsequent reservation requests.
        /// </summary>
        public long HotelId { get; set; }
        
        /// <summary>
        /// Confirms the check-in date submitted in the request.
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        
        /// <summary>
        /// Confirms the check-out date submitted in the request.
        /// </summary>
        public DateTime DepartureDate { get; set; }
        
        /// <summary>
        /// Name of the hotel
        /// </summary>
        public string HotelName { get; set; }
        
        /// <summary>
        /// Hotel street address
        /// </summary>
        public string HotelAddress { get; set; }

        /// <summary>
        /// Hotel city
        /// </summary>
        public string HotelCity { get; set; }

        /// <summary>
        /// Two character code for the state/province containing the specified city. Returns only for US, CA, and AU country codes.
        /// </summary>
        public string HotelStateProvince { get; set; }
        
        /// <summary>
        /// Two character ISO-3166 code for the country the hotel is located in.
        /// </summary>
        public string HotelCountry { get; set; }
        
        /// <summary>
        /// Confirms the number of Room nodes sent in the request.
        /// </summary>
        public int NumberOfRoomsRequested { get; set; }
        
        /// <summary>
        /// Must be displayed if returned by the property. May include fees that can be incurred at check-in, instructions for after-hours check-in, etc
        /// </summary>
        public string CheckInInstructions { get; set; }

        /// <summary>
        /// Each node contains rates and details for an individual room at the hotel.
        /// </summary>
        public List<HotelRoomResponse> HotelRoomResponse { get; set; }





        public string RateKey { get; set; }
        
        public int TripAdvisorReviewCount { get; set; }
        
        public string TripAdvisorRatingUrl { get; set; }
        
        public decimal TripAdvisorRating { get; set; }
        
    }
}

