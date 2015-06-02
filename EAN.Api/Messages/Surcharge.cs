namespace EAN.Api.Messages
{
    public class Surcharge
    {
        /// <summary>
        /// Amount of the specific surcharge
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Possible values:
        /// TaxAndServiceFee
        /// ExtraPersonFee
        /// Tax
        /// ServiceFee
        /// SalesTax
        /// HotelOccupancyTax
        /// </summary>
        public string Type { get; set; }
    }
}