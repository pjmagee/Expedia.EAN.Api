namespace EAN.Api.Messages
{
    public class ChargeableRateInfo
    {
        public decimal Total { get; set; }
        public decimal SurchargeTotal { get; set; }
        public decimal NightlyRateTotal { get; set; }

        public decimal MaxNightlyRate { get; set; }
        public string CurrencyCode { get; set; }

        public decimal CommissionableUsdTotal { get; set; }
        public decimal AverageRate { get; set; }
        public decimal AverageBaseRate { get; set; }
        
        public NightlyRatesPerRoom NightlyRatesPerRoom { get; set; }
        public Surcharges Surcharges { get; set; }
    }
}