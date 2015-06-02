using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public enum RoomAvailibilityOption
    {
        ///<summary>
        ///Retrieve only the hotel details (property description)
        ///</summary>
        HOTEL_DETAILS,

        ///<summary>
        ///Retrieve room types
        ///</summary>
        ROOM_TYPES,

        ///<summary>
        ///Retrieve room amenities list (kitchenette, TV, etc)
        ///</summary>
        ROOM_AMENITIES,

        ///<summary>
        ///Retrieve property amenities list (spa, gym, conference rooms)
        ///</summary>
        PROPERTY_AMENITIES,

        ///<summary>
        ///Retrieve only the hotel image URLs (not room images)
        ///</summary>
        HOTEL_IMAGES
    }
}
