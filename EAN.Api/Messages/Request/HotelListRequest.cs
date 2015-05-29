namespace EAN.Api.Messages.Request
{
    using System;
    using System.Collections.Generic;

    public class HotelListRequest
    {
        public int Id { get; set; }

        //1 .  Base Parameters
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? NumberOfResults { get; set; }
        public List<Room> RoomGroup { get; set; }

        //2.  Primary Search Methods
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string DestinationString { get; set; }
        public string DestinationId { get; set; }

        public List<int> HotelIdList { get; set; } // comma-separated list of long

        // Geographical
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? SearchRadius { get; set; }
        public int? SearchRadiusUnit { get; set; }
        public string Sort { get; set; }      

        // Additional secondary search options
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PropertyName { get; set; }

        // Search Filtering Options
        public List<PropertyCategory> PropertyCategories { get; set; }
        public List<Amenity> Amenities { get; set; }
        public float? MaxStarRating { get; set; }
        public float? MinStarRating { get; set; }
        public float? MinRate { get; set; }
        public float? MaxRate { get; set; }
        public int? NumberOfBedRooms { get; set; }
        public SupplierType? SupplierType { get; set; } // Filters results by supplier type.
        public int? MaxRatePlanCount { get; set; } // Defines the number of room types to return with each property.

        // Cached results and paging
        public string SupplierCacheTolerance { get; set; }
        public string CacheLocation { get; set; }
        public string CacheKey { get; set; }
    }
}