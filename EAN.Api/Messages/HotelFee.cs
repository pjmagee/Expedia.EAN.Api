using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public class HotelFee
    {
        /// <summary>
        /// The type of charge. Possible values:
        /// MandatoryFee
        /// MandatoryTax
        /// ResortFee
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Value for the charge.
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Returns if includeHotelFeeBreakdown was sent in the request. Details how the fee is applied and how often it applies.
        /// Available with minorRev=24 or higher.
        /// </summary>
        public HotelFeeBreakdown HotelFeeBreakdown { get; set; }
    }
}
