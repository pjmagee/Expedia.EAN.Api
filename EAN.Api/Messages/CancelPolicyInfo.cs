namespace EAN.Api.Messages
{
    using System;

    public class CancelPolicyInfo
    {
        /// <summary>
        /// Version ID value.
        /// </summary>
        public int VersionId { get; set; }

        /// <summary>
        /// Time of day the policy window begins/ends, in 24 hour format.
        /// </summary>
        public DateTime CancelTime { get; set; }

        /// <summary>
        /// Hours before the day of check-in that the policy window begins, counting back from the specific time returned in cancelTime. This will return as 0 within the first instance of cancelPolicyInfo (since the window extends up until the actual check-in time) and then the actual number of hours the policy window spans for the second instance.
        /// Returns with a value of 999 for nonrefundable rooms.
        /// </summary>
        public string StartWindowHours { get; set; }

        /// <summary>
        /// The number of nights charged as a penalty for cancelling within the policy window. A value of 1 = the first night's value plus tax; 2 = first and second night's individual values plus tax (do not multiply the first night's value).
        /// </summary>
        public string NightCount { get; set; }

        /// <summary>
        /// Percentage of the value of the total cost of stay that will be charged as a penalty for cancelling within the policy window
        /// </summary>
        public string Percent { get; set; }

        /// <summary>
        /// Flat fee to be charged as a penalty for cancelling within the policy window
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Currency code penalties will be charged in
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Time zone the property applies to the stated policy period
        /// </summary>
        public string TimeZoneDescription { get; set; }
    }
}