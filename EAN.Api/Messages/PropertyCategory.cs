namespace EAN.Api.Messages
{
    using System.ComponentModel;

    public enum PropertyCategory
    {
        [Description("Hotels")] Hotel = 1,
        [Description("Suites")] Suite = 2,
        [Description("Resorts")] Resort = 3,
        [Description("Rented Condos")] VacationRentalCondo = 4,
        [Description("Bed and Breakfast")] BedAndBreakfast = 5,
        [Description("All Inclusive")] AllInclusive = 6
    }
}