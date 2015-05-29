namespace EAN.Api.Messages
{
    public class LocationInfo
    {
        public string DestinationId { get; set; }
        public bool Active { get; set; }
        public int ActivePropertyCount { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public int GeoAccuracy { get; set; }
        public bool LocationInDestination { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double RefLocationMileage { get; set; }
    }


}