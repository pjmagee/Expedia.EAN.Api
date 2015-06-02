namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class Room
    {
        /// <summary>
        /// Adult guest count for the room.
        /// Properties typically accommodate no more than 4 guests before incurring extra person fees. 
        /// Do not offer more than 8 guests per room, as results will not return above this guest count for most markets.
        /// </summary>
        public int NumberOfAdults { get; set; }

        /// <summary>
        /// Child guest count for the room. Required for all properties. Used in combination with childAges to determine availability and rates.
        /// </summary>
        public int NumberOfChildren { get; set; }

        /// <summary>
        /// Always require this info from customers when child guests are specified. Unexpected extra person charges may result if children's ages are not provided prior to booking.
        /// </summary>
        public List<int> ChildAges { get; set; }

        /// <summary>
        /// Found in responses only.
        /// </summary>
        public string RateKey { get; private set; }
    }
}