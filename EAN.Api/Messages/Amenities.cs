namespace EAN.Api.Messages
{
    using System;
    using System.ComponentModel;

    [Flags]
    public enum Amenities
    {
        None = 0x0000000,
        [Description("Business Center")] BusinessCenter = 0x0000001,
        [Description("Gym")] FitnessCenter = 0x0000002,
        [Description("Hot Tub")] HotTubOnSite = 0x0000004,
        [Description("Internet")] Internet = 0x0000008,
        [Description("Children Activities")] KidsActivities = 0x0000010,
        [Description("Kitchen")] Kitchen = 0x0000020,
        [Description("Pets Allowed")] PetsAllowed = 0x0000040,
        [Description("Pool")] Pool = 0x0000080,
        [Description("Restaurant")] Restauraunt = 0x0000100,
        [Description("Spa")] Spa = 0x0000200,
        [Description("Whirl Pool Bath")] WhirlPoolBath = 0x0000400,
        [Description("Breakfast")] Breakfast = 0x0000800,
        [Description("Babysitting Services")] Babysitting = 0x0001000,
        [Description("Jacuzzi")] Jacuzzi = 0x0002000,
        [Description("On-Site Parking")] Parking = 0x0004000,
        [Description("Room Service")] RoomService = 0x0008000,
        [Description("Disability Access")] AccessiblePathOfTravel = 0x0010000,
        [Description("Bathroom")] Bathroom = 0x0020000,
        [Description("Roll-In Show")] RollInShower = 0x0040000,
        [Description("Disabled Parking")] HandicappedParking = 0x0080000,
        [Description("In room accessability")] InRoomAccessability = 0x0100000,
        [Description("Accessability for Hearing Impaired")] AccessibilityEquipmentForDeaf = 0x0200000,
        [Description("Raised / Braille Signage")] Braille = 0x0400000,
        [Description("Free Airport Shuttle Service")] FreeAirportShuttle = 0x0800000,
        [Description("Indoor Pool")] IndoorPool = 0x1000000,
        [Description("Outdoor Pool")] OutdoorPool = 0x2000000,
        [Description("Extended Parking")] ExtendedParking = 0x4000000,
        [Description("Free Parking")] FreeParking = 0x8000000,
    }
}