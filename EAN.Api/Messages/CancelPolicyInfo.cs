namespace EAN.Api.Messages
{
    using System;

    public class CancelPolicyInfo
    {
        public int VersionId { get; set; }
        public DateTime CancelTime { get; set; }
        public string CurrencyCode { get; set; }
        public int Percent { get; set; }
        public int NightCount { get; set; }
        public int StartWindowHours { get; set; }
        public string TimeZoneDescription { get; set; }
    }
}