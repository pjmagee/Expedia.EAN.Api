namespace EAN.Api.Messages
{
    public class ServerInfo
    {
        /// <summary>
        /// current readable formatted time
        /// </summary>
        public string ServerTime { get; set; }
        
        /// <summary>
        /// the current time in seconds
        /// </summary>
        public string Timestamp { get; set; }
        
        /// <summary>
        /// an internal server instance
        /// </summary>
        public string Instance { get; set; }
    }
}