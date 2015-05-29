namespace EAN.Api.Messages
{
    public class RateInfo
    {
        public bool RateChange { get; set; }
        public bool Promo { get; set; }
        public bool PriceBreakDown { get; set; }
        public string CancellationPolicy { get; set; }
        public CancelPolicyInfoList CancelPolicyInfoList { get; set; }
        public ChargeableRateInfo ChargeableRateInfo { get; set; }
        public int CurrentAllotment { get; set; }
        public bool DepositRequired { get; set; }
        public bool GuaranteeRequired { get; set; }
        public bool NonRefundable { get; set; }
        public string PromoDescription { get; set; }
        public long PromoId { get; set; }
        public string RateType { get; set; }
        public RoomGroup RoomGroup { get; set; }
        public decimal TaxRate { get; set; }
    }
}