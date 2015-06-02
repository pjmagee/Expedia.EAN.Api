namespace EAN.Api.Messages
{
    public class NightlyRate
    {
        /// <summary>
        /// Indicates if a promo rate is applied for this night's rate.
        /// </summary>
        public bool Promo { get; set; }
        
        /// <summary>
        /// The nightly rate before the promo, if any, is applied.
        /// </summary>
        public double BaseRate { get; set; }

        /// <summary>
        /// The nightly rate after the promo, if any, is applied.
        /// </summary>
        public double Rate { get; set; }
    }
}