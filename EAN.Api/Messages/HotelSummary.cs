namespace EAN.Api.Messages
{
    public class HotelSummary
    {
        public int Order { get; set; }
        public string UbsScore { get; set; }
        public long HotelId { get; set; } // hotelId=211540
        public string Name { get; set; } // name=OLIVER PLAZA
        public string Address1 { get; set; } // address1=33 TREBOVIR ROAD
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; } // postalCode=SWSOLR
        public string CountryCode { get; set; } //countryCode=GB
        public string AirportCode { get; set; } // airportCode=LHR
        public int PropertyCategory { get; set; } // propertyCategory=4
        public double HotelRating { get; set; }
        public int ConfidenceRating { get; set; }
        public int AmenityMask { get; set; }
        public double TripAdvisorRating { get; set; }
        public int TripAdvisorReviewCount { get; set; } // tripAdvisorReviewCount=1439
        public string TripAdvisorRatingUrl { get; set; } // tripAdvisorRatingUrl=http://www.tripadvisor.com/img/cdsi/img2/ratings/traveler/4.0-12345-4.gif
        public string LocationDescription { get; set; } // locationDescription=Near Kensington Palace
        public string ShortDescription { get; set; } // shortDescription=- HOTEL&#x0D;&#x0D;YEAR BUILT -
        public decimal HighRate { get; set; } // highRate=286.61685
        public decimal LowRate { get; set; } // lowRate=69.47807
        public string RateCurrencyCode { get; set; }
        public double Latitude { get; set; } // latitude=51.4915
        public double Longitude { get; set; } // longitude=-0.19515
        public double ProximityDistance { get; set; }
        public string ProximityUnit { get; set; } // proximityUnit=MI
        public bool HotelInDestination { get; set; } // hotelInDestination=True
        public string ThumbNailUrl { get; set; } //thumbNailUrl=/hotels/1000000/920000/914300/914263/914263_159_t.jpg
        public string DeepLink { get; set; }
        public RoomRateDetailsList RoomRateDetailsList { get; set; }

        /// <summary>
        /// Returns the Amenties from the BitMask property
        /// </summary>
        public Amenities Amenities
        {
            get { return (Amenities)AmenityMask; }
        } 

    }

}