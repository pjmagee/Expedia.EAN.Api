namespace EAN.Api.Messages.Request
{
    public class LocationInfoRequest
    {
        // By Destination String
        public string DestinationString { get; set; }

        // By Address
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string Destination { get; set; }

        // Destination Id
        public string DestinationId { get; set; }
    }
}
