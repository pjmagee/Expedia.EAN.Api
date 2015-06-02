namespace EAN.Api.Messages.Response
{
    using System;
    using System.Collections.Generic;

    public class RoomAvailabilityResponse : CommonResponse
    {
        public long HotelId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelStateProvince { get; set; }
        public string HotelCity { get; set; }
        public string HotelCountry { get; set; }
        public int NumberOfRoomsRequested { get; set; }
        public string CheckInInstructions { get; set; }
        public string RateKey { get; set; }
        public int TripAdvisorReviewCount { get; set; }
        public string TripAdvisorRatingUrl { get; set; }
        public decimal TripAdvisorRating { get; set; }
        public List<HotelRoomResponse> HotelRoomResponse { get; set; }
    }
}

