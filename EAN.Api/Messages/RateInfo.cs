namespace EAN.Api.Messages
{
    public class RateInfo
    {
        /// <summary>
        /// Indicates if a full price breakdown including taxes and total price to be charged is included.
        /// </summary>
        public bool PriceBreakDown { get; set; }

        /// <summary>
        /// Indicates if the rate returned is a promotional rate.
        /// </summary>
        public bool Promo { get; set; }
        
        /// <summary>
        /// Indicates if the rate is different for at least one of the nights during the stay.
        /// </summary>
        public bool RateChange { get; set; }

        /// <summary>
        /// Confirms the contents of the same RoomGroup object sent in the request as they apply to the rates provided. For minorRev=29 and higher, contains per-room nightly rate details.
        /// </summary>
        public RoomGroup RoomGroup { get; set; }

        /// <summary>
        /// ID for the promo offer returned, if any. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public string PromoId { get; set; }

        /// <summary>
        /// Description for the promo returned, if any. Max of 255 chars will return. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public string PromoDescription { get; set; }

        /// <summary>
        /// Extra details for the promo returned, if any. Returned in HotelRoomResponse below minorRev=20 or lower.
        /// </summary>
        public string PromoDetailText { get; set; }

        /// <summary>
        /// Indicates if the booking is nonrefundable. Must display if returned - all charges are final after a successful booking. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public bool NonRefundable { get; set; }

        /// <summary>
        /// Always returns as true for Expedia Collect.
        /// </summary>
        public bool DepositRequired { get; set; }

        /// <summary>
        /// Indicates if the rate returned is prepaid via EAN or post-paid at the hotel. Either returns with a value of MerchantStandard for prepaid availability, or does not return at all for post-paid.
        /// Returned in this location for minorRev=20 or higher. minorRev=18 and 19 return this element in the main body of the response.
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// The number of bookable rooms remaining at the property. Use this value to create rules for urgency messaging to alert users to low availability on busy travel dates or at popular properties.
        /// If the value returns as 0, it does not indicate a lack of rooms at the property. The rules needed to calculate the value were simply not met - this value does not indicate absolute availability. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public int CurrentAllotment { get; set; }

        /// <summary>
        /// Hotel's cancellation policy for this room. Must display on individual room pages as well as any booking and booking confirmation pages. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public string CancellationPolicy { get; set; }
        
        /// <summary>
        /// Details specifics of the cancellation policy, typically the times determining the penalty period and the penalties incurred for cancellation. Returned in HotelRoomResponse below minorRev=20.
        /// </summary>
        public CancelPolicyInfoList CancelPolicyInfoList { get; set; }

        /// <summary>
        /// This object's attributes contain the absolute total to be charged for the reservation as well as rate averages and totals. Nodes within the object provide details on individual nightly rates and surcharges.
        /// </summary>
        public ChargeableRateInfo ChargeableRateInfo { get; set; }

        /// <summary>
        /// Rate information converted to the customer's requested currency. Returned only if the chargeable and converted currencies are different, i.e. if the hotel cannot accept the customer's requested currency. Contains the same attributes as ChargeableRateInfo.
        /// </summary>
        public ChargeableRateInfo ConvertedRateInfo { get; set; }

        /// <summary>
        /// Indicates whether any promos returned are mobile-specific or standard promotions. Returns Mobile for mobile promotions and Standard for all others.
        /// In order to return mobile promotions, you must identify your mobile site or app via the proper customerUserAgent string.
        /// Available with minorRev=21 or higher.
        /// </summary>
        public string PromoType { get; set; }
        
        /// <summary>
        /// This element breaks out certain taxes and fees collected by the hotel that are otherwise not specifically detailed in the Surcharges array.
        /// All values within this element are charged by the hotel upon check in or checkout. They are not part of any charges collected at booking time.
        /// When populated, use this element to meet the rate/tax/fee display format required by major search engines and aggregators.
        /// Contains size attribute to indicate the number of charges contained.
        /// Available with minorRev=19 or higher.
        /// </summary>
        public HotelFees HotelFees { get; set; }

    }
}