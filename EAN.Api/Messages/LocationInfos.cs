namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class LocationInfos
    {
        public int Size { get; set; }
        public List<LocationInfo> LocationInfo { get; set; }
    }
}