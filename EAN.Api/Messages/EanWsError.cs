namespace EAN.Api.Messages
{
    public class EanWsError
    {
        /// <summary>
        /// The ID associated with a EAN itinerary. This value is necessary in all correspondence with customer service agents on bookings.
        /// An itinerary ID is only returned on booking requests. Data validation errors on booking requests do not return an itineraryID.  If one is returned, then always return it to the client as a reference number. 
        /// If not, then the error did not get far enough to generate a reference itineraryID.
        /// </summary>
        public long ItineraryId { get; set; }

        /// <summary>
        /// for internal reference only
        /// </summary>
        public int ExceptionConditionId { get; set; }

        /// <summary>
        /// presentation error message returned
        /// </summary>
        public string PresentationMessage { get; set; }

        /// <summary>
        /// more specific detailed error message
        /// </summary>
        public string VerboseMessage { get; set; }

        /// <summary>
        /// value indicating the severity of the exception and how it may be handled
        /// </summary>
        public string Handling { get; set; }
        
        /// <summary>
        /// value indicating the nature of the exception or the reason it occurred
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// additional error data. This element typcally returns data for secure code credit card processing or correcting multiple location errors.
        /// </summary>
        //TODO: public string ErrorAttributes { get; set; }

        /// <summary>
        /// (minRev 7 and higher)
        /// </summary>
        public ServerInfo ServerInfo { get; set; }
    }
}