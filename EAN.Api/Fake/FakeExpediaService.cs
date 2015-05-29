namespace EAN.Api.Fake
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Messages.Request;
    using Messages.Response;
    using RestSharp;
    using RestSharp.Deserializers;

    /// <summary>
    /// A Fake Expedia Service
    /// Used for Testing
    /// </summary>
    public class FakeExpediaService : AbstractExpediaService
    {
        private const string Pattern = @"(@{1})(?=[A-Za-z]{1,}"":)";
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled);

        /// <summary>
        /// When we publish to IIS, we need to get the executing assembly path location, which would be
        /// </summary>
        private readonly string _contentPath = Path.Combine(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath, "Fake", "Content");
        
        // http://stackoverflow.com/questions/2947489/how-can-i-remove-the-file-from-the-return-value-of-path-getdirectoryname
        private string PathFor(string file)
        {
            return Path.Combine(_contentPath, file);
        }

        public override long Cid { get; set; }
        public override string ApiKey { get; set; }
        public override int MinorRev { get; set; }
        public override string Locale { get; set; }
        public override string CurrencyCode { get; set; }
        public override string CustomerSessionId { get; set; }
        public override string CustomerIpAddress { get; set; }
        public override string CustomerUserAgent { get; set; }
        public override string Sig { get; set; }

        /// <summary>
        /// Fiddler URL Dump
        /// 
        /// http://api.ean.com/ean-services/rs/hotel/v3/list?arrivalDate=2%2F13%2F2013&departureDate=2%2F19%2F2013&destinationId=E1D27871-773E-4AD1-B710-D21640A26300&numberOfResults=50&supplierType=E&minStarRating=1&maxStarRating=5&room1=1%2C&room2=2%2C&room3=1%2C4&supplierCacheTolerance=MAX_ENHANCED&apiKey=ty7wujrv6jc2vbrm2cpnmear&cid=55505&minorRev=20&currencyCode=GBP&locale=en_GB&customerUserAgent=Mozilla%2F5.0%20%28Windows%20NT%206.2%3B%20WOW64%29%20AppleWebKit%2F537.17%20%28KHTML%2C%20like%20Gecko%29%20Chrome%2F24.0.1312.57%20Safari%2F537.17&customerIpAddress=%3A%3A1
        /// </summary>
        /// <param name="hotelListRequest"></param>
        /// <returns></returns>
        public override HotelListResponse GetHotelAvailabilityList(HotelListRequest hotelListRequest)
        {
            string path = PathFor("HotelListResponse.json");
            string content = Regex.Replace(File.ReadAllText(path), "");
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "HotelListResponse" };
            HotelListResponse hotelListResponse = jsonDeserializer.Deserialize<HotelListResponse>(new RestResponse() { Content = content });
            return hotelListResponse;
        }

        /// <summary>
        /// Fiddler URL Dump
        /// 
        /// </summary>
        /// <param name="hotelListRequest"></param>
        /// <returns></returns>
        public override HotelListResponse GetHotelActiveList(HotelListRequest hotelListRequest)
        {
            string path = PathFor("HotelListResponse.json");
            string content = Regex.Replace(File.ReadAllText(path), "");
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "HotelListResponse" };
            HotelListResponse hotelListResponse = jsonDeserializer.Deserialize<HotelListResponse>(new RestResponse() {Content = content});
            return hotelListResponse;
        }

        /// <summary>
        /// Fiddler URL Dump
        /// 
        /// http://api.ean.com/ean-services/rs/hotel/v3/info?hotelId=164989&options=HOTEL_IMAGES&apiKey=ty7wujrv6jc2vbrm2cpnmear&cid=55505&minorRev=20&currencyCode=GBP&locale=en_GB&customerUserAgent=Mozilla%2F5.0%20%28Windows%20NT%206.2%3B%20WOW64%29%20AppleWebKit%2F537.17%20%28KHTML%2C%20like%20Gecko%29%20Chrome%2F24.0.1312.57%20Safari%2F537.17&customerSessionId=0ABAA843-0682-2391-3CC2-CF6F03393718&customerIpAddress=%3A%3A1
        /// </summary>
        /// <param name="hotelInformationRequest"></param>
        /// <returns></returns>
        public override HotelInformationResponse GetHotelInformation(HotelInformationRequest hotelInformationRequest)
        {
            string path = PathFor("HotelInformationResponse.json");
            string content = Regex.Replace(File.ReadAllText(path), "");
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "HotelInformationResponse" };
            HotelInformationResponse hotelInformationResponse = jsonDeserializer.Deserialize<HotelInformationResponse>(new RestResponse() {Content = content});
            return hotelInformationResponse;
        }

        public override HotelRoomAvailabilityResponse GetHotelRoomAvailability(HotelRoomAvailabilityRequest roomAvailabilityRequest)
        {
            string path = PathFor("HotelRoomAvailabilityResponse.json");
            string content = Regex.Replace(File.ReadAllText(path), "");
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "HotelRoomAvailabilityResponse" };
            HotelRoomAvailabilityResponse hotelRoomAvailabilityResponse = jsonDeserializer.Deserialize<HotelRoomAvailabilityResponse>(new RestResponse() {Content = content});
            return hotelRoomAvailabilityResponse;
        }

        public override LocationInfoResponse GetGeoSearch(LocationInfoRequest locationInfoRequest)
        {
            string path = PathFor("LocationInfoResponse.json");
            string content = Regex.Replace(File.ReadAllText(path), "");
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "LocationInfoResponse" };
            LocationInfoResponse locationInfoResponse = jsonDeserializer.Deserialize<LocationInfoResponse>(new RestResponse() {Content = content});
            return locationInfoResponse;
        }

        public override HotelRoomCancellationResponse GetHotelRoomCancel(HotelRoomCancellationRequest hotelRoomCancellationRequest)
        {
            throw new NotImplementedException();
        }

        public override PingResponse GetPing(PingRequest pingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
