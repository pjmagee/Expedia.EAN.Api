namespace EAN.Api.Messages.Response
{
    public class LocationInfoResponse
    {
        public EanWsError EanWsError { get; set; }
        public string CustomerSessionId { get; set; }
        public LocationInfos LocationInfos { get; set; }
    }
}