namespace EAN.Api.Messages.Response
{
    public class CachedSupplierResponse
    {
        public EanWsError EanWsError { get; set; }
        public string MatchedLocale { get; set; }
        public string MatchedCurrency { get; set; }
        public string TpidUsed { get; set; }
        public string OtherOverheadTime { get; set; }
        public string CandidatePreptime { get; set; }
        public string SupplierResponseTime { get; set; }
        public string SupplierResponseNum { get; set; }
        public string SupplierRequestNum { get; set; }
        public string CachedTime { get; set; }
        public string SupplierCacheTolerance { get; set; }
    }
}