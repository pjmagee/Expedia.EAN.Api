namespace EAN.Api.Messages
{
    using System.ComponentModel;

    public enum SupplierType
    {
        [Description("Expedia")] E,
        [Description("Venere")] V,
        [Description("Expedia And Venere")] EV,
        [Description("Sabre")] S,
        [Description("Worldspan")] W
    }
}