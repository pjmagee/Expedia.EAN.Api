namespace EAN.Api
{
    using Messages.Request;
    using Messages.Response;

    /// <summary>
    /// Most of these parameters must be sent as part of every request you 
    /// make to the API; some can be provided optionally for testing purposes, 
    /// or are only required for specific setups.
    /// 
    /// Expedia state that required properties are
    /// UserAgent, User IP Address, Cid, ApiKey, Locale
    /// 
    /// Note, an implementation should extend the abstract class 
    /// and over ride the 
    /// <remarks>
    ///   Author: Patrick Magee
    ///   Documentation transferred from the Developer EAN site documentation at:
    ///   <a href="http://developer.ean.com/docs/read/hotels/version_3/Endpoints_amp_Common_Elements">Endpoints and Common Elements</a>
    /// </remarks>
    /// </summary>
    public abstract class AbstractExpediaService : IExpediaService
    {
        /// <summary>
        /// Your EAN-issued account ID. This number is used for tracking sales 
        /// for statistics and commissions purposes on live sites.
        /// Paired with apiKey(s) as part of authentication.
        /// </summary>
        public abstract long Cid { get; set; }

        /// <summary>
        /// Your EAN-issued access key to the API.
        ///  Determines your access to live bookings, 
        /// your authentication method (IP or signature-based) and request quotas.
        /// </summary>
        public abstract string ApiKey { get; set; }

        /// <summary>
        /// Sets the minor revision used for processing requests and returning 
        /// responses. Defaults to 4 (original release) if omitted.
        /// </summary>
        public abstract int MinorRev { get; set; }

        /// <summary>
        /// Returns data in other languages where available for Expedia Collect 
        /// properties only. Default: en_US
        /// http://developer.ean.com/general_info/Hotel_Language_Options
        /// </summary>
        public abstract string Locale { get; set; }

        /// <summary>
        /// Returns data in other currencies where available.
        /// When booking, this value must match the value returned 
        /// within the ChargeableRateInfo node from the prior room availability 
        /// response to prevent price mismatch errors.
        /// Default: USD
        /// http://developer.ean.com/general_info/Hotel_Currency_Options
        /// </summary>
        public abstract string CurrencyCode { get; set; }

        /// <summary>
        /// Returned in the first response following a customer's initial search. 
        /// Continue to pass this same value for each customer during each booking 
        /// session, using a new value for each new search, to track user behavior 
        /// in your own statistics.
        /// </summary>
        public abstract string CustomerSessionId { get; set; }

        /// <summary>
        /// IP address of the customer, as captured by your integration.
        /// Ensure your integration passes the customer's IP, not your own. 
        /// This value helps determine their location and assign the correct
        /// payment gateway. Also used for fraud recovery and other important 
        /// analytics.
        /// </summary>
        public abstract string CustomerIpAddress { get; set; }

        /// <summary>
        /// Customer's user agent string, as captured by your integration.
        /// For mobile sites, include the string value MOBILE_SITE anywhere within 
        /// this element. Use MOBILE_APP for mobile apps. 
        /// 
        /// These values can be sent by themselves or appended to a captured user
        /// agent string. If neither mobile-specific string is detected, the
        /// API will still attempt to determine the usage of a mobile site or 
        /// mobile app via the contents of the raw user agent string, but this
        /// is not guaranteed to work for all mobile browsers/devices. A desktop 
        /// browser is assumed if neither of the mobile strings nor any 
        /// mobile-specific keywords are detected.
        /// </summary>
        public abstract string CustomerUserAgent { get; set; }

        /// <summary>
        /// The sig value used with signature authentication - ensure this value 
        /// remains clear of any visible code. All sig values are required to be 
        /// at least 32 lower-case characters in length. 
        /// 
        /// If you receive errors when generating your own digital signature, 
        /// send a ping request to verify your Unix time against EAN's or check 
        /// your value against EAN's sig generator.
        /// </summary>
        public abstract string Sig { get; set; }

        public abstract HotelListResponse GetHotelAvailabilityList(HotelListRequest hotelListRequest);
        public abstract HotelListResponse GetHotelActiveList(HotelListRequest hotelListRequest);
        public abstract HotelInformationResponse GetHotelInformation(HotelInformationRequest hotelInformationRequest);
        public abstract HotelRoomAvailabilityResponse GetHotelRoomAvailability(HotelRoomAvailabilityRequest roomAvailabilityRequest);
        public abstract LocationInfoResponse GetGeoSearch(LocationInfoRequest locationInfoRequest);
        public abstract HotelRoomCancellationResponse GetHotelRoomCancel(HotelRoomCancellationRequest hotelRoomCancellationRequest);
        public abstract PingResponse GetPing(PingRequest pingRequest);

    }
}