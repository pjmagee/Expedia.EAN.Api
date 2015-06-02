namespace EAN.Api.Messages
{
    public class RateInfos
    {
        public int Size { get; set; }

        /// <summary>
        /// Contains all rate information for a single room within several different objects and individual values.
        /// </summary>
        public RateInfo RateInfo { get; set; }
    }
}