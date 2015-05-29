namespace EAN.Api.Messages
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "RoomGroup")]
    public class RoomGroup
    {
        [DataMember(Name = "Room")]
        public List<Room> Room { get; set; }
    }
}