using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public class HotelFeeBreakdown
    {
        /// <summary>
        /// How the fee is distributed. Possible values:
        /// Per Person
        /// Per Room
        /// Per accommodation
        /// Per house
        /// Per apartment
        /// Per adult
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Frequency of the fee. Possible values:
        /// Per Night
        /// Per Day
        /// Per Stay
        /// Per week
        /// </summary>
        public string Frequency { get; set; }
    }
}
