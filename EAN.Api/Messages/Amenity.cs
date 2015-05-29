namespace EAN.Api.Messages
{
    using System.ComponentModel;

    public enum Amenity
    {
        [Description("Swimming Pool")] SwimmingPool = 1,
        [Description("Fitness Center")] FitnessCenter = 2,
        [Description("Restaurant")] Restaurant = 3,
        [Description("Children Activities")] ChildrenActivities = 4,
        [Description("Complimentary Breakfast")] ComplimentaryBreakfast = 5,
        [Description("Meeting Facilities")] MeetingFacilities = 6,
        [Description("Pets Allowed")] PetsAllowed = 7,
        [Description("Wheelchair Accessible")] WheelChairAccessible = 8,
        [Description("Kitchen")] Kitchen = 9
    }
}