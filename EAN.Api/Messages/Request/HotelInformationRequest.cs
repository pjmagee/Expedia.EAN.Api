namespace EAN.Api.Messages.Request
{
    using System.Collections.Generic;

    public class HotelInformationRequest
    {
        public int HotelId { get; set; }
        public List<Options> Options { get; set; }
    }
}