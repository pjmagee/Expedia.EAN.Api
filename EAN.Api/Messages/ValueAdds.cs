namespace EAN.Api.Messages
{
    using System.Collections.Generic;

    public class ValueAdds
    {
        public int Size { get; set; }
        public List<ValueAdd> ValueAdd { get; set; }
    }
}