using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public class HotelFees
    {
        public int Size { get; set; }
        public List<HotelFee> HotelFee { get; set; }
    }
}
