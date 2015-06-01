namespace EAN.Api.Messages.Request
{
    using System;
    using System.Collections.Generic;

    public class HotelListRequest
    {
        /// <summary>
        /// Required for availability. 
        /// </summary>
        public DateTime? ArrivalDate { get; set; }
       
        /// <summary>
        /// Required for availability. Availability can be searched up to 500 days in advance of this date. 
        /// Total length of stay cannot be greater than 28 nights.
        /// </summary>
        public DateTime? DepartureDate { get; set; }
        
        /// <summary>
        /// Maximum number of hotels to return per response (before needing to page for additional results). Acceptable value range is 1 to 200. Default: 20 
        /// Does not limit results for a dateless list request.
        /// </summary>
        public int? NumberOfResults { get; set; }
        
        /// <summary>
        /// Required for availability. Container for the Room arrays that define guest and room count.
        /// </summary>
        public List<Room> RoomGroup { get; set; }

        /// <summary>
        /// Required for two-step booking. 
        /// Determines whether or not a rate key, cancellation policies, bed types, and smoking preferences should be returned with each room option.
        /// Requesting these values at this level allows you to offer a two-step booking path directly from the list results.
        /// Returns additional elements only with minorRev=22 or above.
        /// </summary>
        public bool IncludeDetails { get; set; }

        /// <summary>
        /// Returns the element HotelFeeBreakdown, which contains a more detailed response structure for the HotelFees array that includes how often each fee applies and how it is applied. 
        /// Available with minorRev=24 and higher.
        /// </summary>
        public bool IncludeHotelFeeBreakdown { get; set; }

        // Search Method 1: City/state/country search
        /// <summary>
        /// City to search within. Use only full city names.
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Two character code for the state/province containing the specified city.
        /// </summary>
        public string StateProvinceCode { get; set; }
        
        /// <summary>
        /// Two character ISO-3166 code for the country containing the specified city.
        /// Use only country codes designated as "officially assigned" in the ISO-3166 decoding table.
        /// </summary>
        public string CountryCode { get; set; }

        // Search Method 2: Free text destination string
        /// <summary>
        /// A string containing at least a city name. 
        /// You can also send city and state, city and country, city/state/country, etc.
        /// This parameter is the best option for taking direct customer input. 
        /// Ambiguous entries will return an error containing a list of likely intended locations, including their destinationId (see below) whenever possible.
        /// </summary>
        public string DestinationString { get; set; }

        // Search Method 3: Use a destinationId
        /// <summary>
        /// The unique hex key value for a specific city, metropolitan area, or landmark.
        /// Obtain this value via a geo function request, or from a multiple locations error returned by a destinationString availability request.
        /// Values for landmarks such as buildings, major neighborhoods, train stations, etc. can be obtained via a geo function request for landmarks.
        /// </summary>
        public string DestinationId { get; set; }

        // Search Method 4: Use a list of hotelIds
        /// <summary>
        /// Check for availability against a fixed set of hotels.
        /// Use the sort score provided by the SequenceNumber field in the ActivePropertyList database file to order the hotels in your response.
        /// </summary>
        public List<int> HotelIdList { get; set; }

        // Search Method 5: Search within a geographical area
        /// <summary>
        /// Latitude coordinate for the search's origin point
        /// </summary>
        public decimal? Latitude { get; set; }
        
        /// <summary>
        /// Longitude coordinate for the search's origin point
        /// </summary>
        public decimal? Longitude { get; set; }
        
        /// <summary>
        /// Defines radius of a circular search area, with the provided latitude and longitude values defining the center.
        /// Minimum of 1 MI or 2 KM, maximum of 50 MI or 80 KM. Values exceeding the maximum will automatically be reduced before results are returned.
        /// Defaults to 20 MI.
        /// </summary>
        public int? SearchRadius { get; set; }
        
        /// <summary>
        /// Sets the unit of distance for the search radius. Send MI or KM. Defaults to MI if empty or not included.
        /// </summary>
        public string SearchRadiusUnit { get; set; }

        /// <summary>
        /// We recommend sending initial searches without a specified sort order, as the default sort order is calculated to place the most preferred and best-converting properties at the top.
        /// Instead, allow customers to choose a different sort order after the initial list is returned.
        /// For searching by lat/lng: You must send a value of proximity if you want the results to be sorted by distance from the origin point, otherwise the default sort order is applied to any hotels that fall within the search radius.
        /// </summary>
        public SortOption Sort { get; set; }

        // Additional Search Methods
        /// <summary>
        /// Search nearby a local street address. The response will contain each property's proximity to the given address.
        /// Even if a specific hotel's address is entered, its place in the default sort order will not be overridden if it is not already at the top.
        /// Requires city and countryCode parameters to be defined.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Optionally include an address' postal code.
        /// Requires city and countryCode parameters to be defined.
        /// </summary>
        public string PostalCode { get; set; }
        
        /// <summary>
        /// Name to search for availability. Value can be an exact name or part of a name, e.g. "Holiday" or "Best."
        /// The response will contain any properties whose names contain the value included in this parameter.
        /// If a specific property name is sent, an empty response may return if there is no availability for the given dates of stay.
        /// Requires city and countryCode parameters to be defined.
        /// </summary>
        public string PropertyName { get; set; }

        // Filtering Methods
        /// <summary>
        /// When sent as false, this parameter will exclude hotels outside of the area defined in your search parameters.
        /// Use if you want to prevent hotels from other nearby cities or outlying areas from appearing in your results.
        /// </summary>
        public bool IncludeSurrounding { get; set; }
        
        /// <summary>
        /// Filters results by property category. Send either a single value or a list of values to return a combination of property categories.
        /// </summary>
        public List<PropertyCategory> PropertyCategories { get; set; }
        
        /// <summary>
        /// This element is no longer recommended for use. The values for this element do not match either Expedia's amenities nor our own amenity database files.
        /// Instead, you can apply amenity filtering after receiving a response in one of two ways:
        /// 1. Decode the bitmask from the amenityMask value in the results to obtain each property's discrete amenities. You can use this sample utility to check your unmasking code: http://sandbox.ean.so/amenity/amenity.php
        /// 2. Download the AttributeList database file locally and use it to filter against hotels that are both in the requested location and that have the filtered amenities.
        /// </summary>
        public List<Amenity> Amenities { get; set; }

        /// <summary>
        /// Filters results by a maximum star rating.
        /// Valid values are 1.0 - 5.0 in increments of 0.5.
        /// </summary>
        public float? MaxStarRating { get; set; }
        
        /// <summary>
        /// Filters results by a minimum star rating.
        /// Valid values are 1.0 - 5.0 in increments of 0.5.
        /// </summary>
        public float? MinStarRating { get; set; }
        
        /// <summary>
        /// Filters results by properties with rates equal to or greater than the provided value.
        /// Searches against the averageRate response value (average of the individual nightly rates during the dates of stay). Valid for availability searches only.
        /// </summary>
        public float? MinRate { get; set; }
        
        /// <summary>
        /// Filters results by properties with rates equal to or less than the provided value.
        /// Searches against the averageRate response value (average of the individual nightly rates during the dates of stay). Valid for availability searches only.
        /// </summary>
        public float? MaxRate { get; set; }
        
        /// <summary>
        /// This parameter is valid for condos/vacation rentals only. Specifies the number of bedrooms requested - 4 maximum.
        /// </summary>
        public int? NumberOfBedRooms { get; set; }
        
        /// <summary>
        /// Defines the number of room types to return with each property.
        /// Setting a higher value will attempt to return the corresponding number of room types at each property in the response, depending on individual property availabilities.
        /// Defaults to 1, where the only the first room type at each property is returned. Under Expedia user testing, this value has been proven to provide the best conversion rates and is recommended to be left as-is, saving additional rooms for display during the room selection stage.
        /// </summary>
        public int? MaxRatePlanCount { get; set; }

        // Additional Data Request
        /// <summary>
        /// Defines the type of limited data to return. Send a single value or a combination.
        /// </summary>
        public List<HotelListOption> Options { get; set; }

        // Cached results and paging
        /// <summary>
        /// Must send with value E to allow paging system to accurately indicate additional results.
        /// </summary>
        public SupplierType? SupplierType { get; set; }
        
        /// <summary>
        /// Defines the EAN server location of the requested cache. Use the value returned in the previous hotel list response.
        /// </summary>
        public string CacheLocation { get; set; }
        
        /// <summary>
        /// The key for the specific cached response requested. Use the value returned in the previous hotel list response.
        /// </summary>
        public string CacheKey { get; set; }
    }
}