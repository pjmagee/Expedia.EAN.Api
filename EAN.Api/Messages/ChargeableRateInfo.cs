namespace EAN.Api.Messages
{
    public class ChargeableRateInfo
    {
        /// <summary>
        /// The total of all nightly rates, taxes, and surcharges to be charged for the reservation. This is the total value that must be displayed to the customer and included in the booking request.
        /// </summary>
        public decimal Total { get; set; }
        
        /// <summary>
        /// Total of TaxAndServiceFee and ExtraPersonFee from the Surcharges array.
        /// </summary>
        public decimal SurchargeTotal { get; set; }
        
        /// <summary>
        /// Total of all values in the nightlyRatesPerRoom array contained within this object.
        /// </summary>
        public decimal NightlyRateTotal { get; set; }

        /// <summary>
        /// Highest nightly rate of all rates returned
        /// </summary>
        public decimal MaxNightlyRate { get; set; }
        
        /// <summary>
        /// Currency code for the rates returned
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Amount used to calculate partner commissions, in USD. Total of nightly rates less surcharges.
        /// </summary>
        public decimal CommissionableUsdTotal { get; set; }
        
        /// <summary>
        /// Average of all nightly rates with any promo values applied, without surcharges.
        /// </summary>
        public decimal AverageRate { get; set; }

        /// <summary>
        /// Average of all nightly rates without any promo values applied, without surcharges. Will return the same as previous value if no promos present.
        /// </summary>
        public decimal AverageBaseRate { get; set; }
        
        /// <summary>
        /// Container for NightlyRate array. Has size attribute to indicate number of nodes in the array, which will correspond to the number of nights in the request. Rates return in sequential order across the duration of the stay.
        /// </summary>
        public NightlyRatesPerRoom NightlyRatesPerRoom { get; set; }

        /// <summary>
        /// Container for Surcharge array. This array itemizes the individual surcharges that make up the value returned for surchargeTotal. Has size attribute to indicate number of nodes in the array.
        /// </summary>
        public Surcharges Surcharges { get; set; }
    }
}