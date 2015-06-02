using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages.Response
{
    public abstract class CommonResponse
    {
        public EanWsError EanWsError { get; set; }
        public string CustomerSessionId { get; set; }
    }
}
