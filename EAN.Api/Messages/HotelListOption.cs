using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public enum HotelListOption
    {
        ///<summary>
        ///Returns all three data types below. Response will be the same as if options were omitted entirely.
        ///</summary>
        DEFAULT,

        ///<summary>
        ///Returns dynamic hotel information with a small amount of identifying static information (hotel name and address, location description, hotelId, etc). Does not contain dynamic rate information. The slimmest possible availability response.
        ///</summary>
        HOTEL_SUMMARY,

        ///<summary>
        ///Returns dynamic room rate information and a bare minimum of static information via hotelId and roomDescription.
        ///</summary>
        ROOM_RATE_DETAILS,

        ///<summary>
        ///Return deep links for the template with basic static info only.
        ///</summary>
        DEEP_LINKS
    }
}
