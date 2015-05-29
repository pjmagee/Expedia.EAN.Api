namespace EAN.Api.Messages
{
    using System.ComponentModel;

    public enum Options
    {
        [Description("Default")] DEFAULT,
        [Description("Hotel Summary")] HOTEL_SUMMARY,
        [Description("Hotel Details")] HOTEL_DETAILS,
        [Description("Suppliers")] SUPPLIERS,
        [Description("Room Types")] ROOM_TYPES,
        [Description("Room Amenities")] ROOM_AMENITIES,
        [Description("Property Amenities")] PROPERTY_AMENITIES,
        [Description("Hotel Images")] HOTEL_IMAGES
    }
}