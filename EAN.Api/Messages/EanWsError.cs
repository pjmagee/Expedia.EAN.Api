namespace EAN.Api.Messages
{
    public class EanWsError
    {
        public int ItineraryId { get; set; }
        public string Handling { get; set; }
        public string Category { get; set; }
        public int ExceptionConditionId { get; set; }
        public string PresentationMessage { get; set; }
        public string VerboseMessage { get; set; }
        public ServerInfo ServerInfo { get; set; }
    }
}