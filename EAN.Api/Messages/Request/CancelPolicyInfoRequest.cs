namespace EAN.Api.Messages.Request
{
    using System;

    public class CancelPolicyInfoRequest
    {
        public long VersionId { get; set; }
        public DateTime CancelTime { get; set; }
        public int StartWindowHours { get; set; }
        public int NightCount { get; set; }
        public decimal Percent { get; set; }
        public string CurrencyCode { get; set; }
        public string TimeZoneDescription { get; set; }
    }
}