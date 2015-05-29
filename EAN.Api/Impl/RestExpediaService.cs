namespace EAN.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Extensions;
    using Messages;
    using Messages.Request;
    using Messages.Response;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Extensions;
    using RestSharp.Validation;

    // HTTP request headers should include Accept-Encoding: gzip,deflate 
    // http://developer.ean.com/general_info/Properly_Handling_Data_Transfers
    // User-agent should NOT include MSIE anywhere in the string, which will cause the results not to be compressed.
    // Ensuring that compressed content is transmitted will greatly speed up the response time of your results, especially when transferring large messages.
    
    /// <summary>
    /// A REST Implementation of the Expedia API
    /// 
    /// This implementation makes use of the following third party libraries:
    /// 
    /// RESTSharp, a HTTP Rest Client that makes it easier to serialize and deserialize 
    /// HTTP Requests and HTTP Responses into concrete classes
    /// </summary>
    public class RestExpediaService : AbstractExpediaService
    {
        private const string BaseUrl = "http://api.ean.com/ean-services/rs/hotel/v3";

        // Injected properties
        public override long Cid { get; set; }
        public override string ApiKey { get; set; }
        public override int MinorRev { get; set; }
        public override string Locale { get; set; }
        public override string CurrencyCode { get; set; }
        public override string CustomerSessionId { get; set; }
        public override string CustomerIpAddress { get; set; }
        public override string CustomerUserAgent { get; set; } 
        public override string Sig { get; set; }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            client.ClearHandlers();
            client.AddHandler("application/json",  new JsonDeserializer());
            client.AddDefaultParameter("Accept-Encoding", "gzip,deflate", ParameterType.HttpHeader);
            
            request.AddParameter("apiKey", ApiKey);
            request.AddParameter("cid", Cid); 
            request.AddParameter("minorRev", MinorRev);
            request.AddParameter("currencyCode", CurrencyCode);
            request.AddParameter("locale", Locale);

            if(CustomerUserAgent.HasValue())
                request.AddParameter("customerUserAgent", CustomerUserAgent);

            if(CustomerSessionId.HasValue())       
                request.AddParameter("customerSessionId", CustomerSessionId);

            if(CustomerIpAddress.HasValue())
                request.AddParameter("customerIpAddress", CustomerIpAddress);

            request.Parameters.ForEach(p => Debug.WriteLine(p.Name + "=" + p.Value));

            // This is a fix for the RestSharp Deserialiser
            // Not a long term fix
            // Better to migrate from RestSharp Json Deserialiser to Json.NET Deserialiser
            // and decorate our classes with properties
            request.OnBeforeDeserialization = removeAttributeSymbol;

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }
        
        private const string Pattern = @"(@{1})(?=[A-Za-z]{1,}"":)"; // Remove @ attribute
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled);

        private void removeAttributeSymbol(IRestResponse restResponse)
        {
            restResponse.Content = Regex.Replace(restResponse.Content, string.Empty);
        }

        /// <summary>
        ///REST Room and guest counts are formatted differently than XML and SOAP. 
        // Review the REST room format section on the hotel list request page.
        // http://developer.ean.com/docs/read/hotels/version_3/request_hotel_rooms
        // &room[room number, starting with 1]=
        // [number of adults],
        // [comma-delimited list of children's ages] 
        /// </summary>
        /// <param name="hotelListRequest"></param>
        /// <returns></returns>
        public override HotelListResponse GetHotelAvailabilityList(HotelListRequest hotelListRequest)
        {
            Require.Argument("hotelListRequest", hotelListRequest); // Guard Clause

            RestRequest request = new RestRequest
                {
                    Resource = "list",
                    Method = Method.GET,
                    RootElement = "HotelListResponse",
                    RequestFormat = DataFormat.Json,
                    DateFormat = "mmddyyyy"
                };

            // This is a paging request
            if (hotelListRequest.CacheKey.HasValue() && hotelListRequest.CacheLocation.HasValue())
            {
                request.AddParameter("cacheKey", hotelListRequest.CacheKey);
                request.AddParameter("cacheLocation", hotelListRequest.CacheLocation);
                return Execute<HotelListResponse>(request);
            }

            // This check-in date
            if (hotelListRequest.ArrivalDate.HasValue)
                request.AddParameter("arrivalDate", hotelListRequest.ArrivalDate.Value.ToShortDateString());

            // This check-out date
            if (hotelListRequest.DepartureDate.HasValue)
                request.AddParameter("departureDate", hotelListRequest.DepartureDate.Value.ToShortDateString());


            if (hotelListRequest.DestinationId.HasValue()) // If I gave you a destination id, use that
            {
                request.AddParameter("destinationId", hotelListRequest.DestinationId); 
            }
            else if (hotelListRequest.DestinationString.HasValue()) // otherwise, use the destination string I gave
            {
                request.AddParameter("destinationString", hotelListRequest.DestinationString);
            }
            else
            {
                // if destination id nor destination string have values, try and use city, state and county

                if (hotelListRequest.City.HasValue())
                    request.AddParameter("city", hotelListRequest.City);

                if (hotelListRequest.CountryCode.HasValue())
                    request.AddParameter("countryCode", hotelListRequest.CountryCode);

                if (hotelListRequest.StateProvinceCode.HasValue())
                    request.AddParameter("stateProvinceCode", hotelListRequest.StateProvinceCode);
            }

            // Default this to 50 per request
            request.AddParameter("numberOfResults", 50);
            request.AddParameter("supplierType", "E"); // Expedia Collect Properties

            HandleFilteringMethods(request, hotelListRequest);


            if (hotelListRequest.RoomGroup != null)
            {
                for(int i = 0; i < hotelListRequest.NumberOfBedRooms; i++)
                {
                    Room room = hotelListRequest.RoomGroup[i];
                    int adults = room.NumberOfAdults;
                    int children = room.NumberOfChildren;
                    List<int> ages = room.ChildAges;
                    int roomNumber = hotelListRequest.RoomGroup.IndexOf(room) + 1;

                    var parameter = new Parameter();

                    parameter.Value = adults + (ages.OrEmptyIfNull().Any() ? ("," + string.Join(",", ages.Take(children).ToArray())) : string.Empty );
                    parameter.Type = ParameterType.GetOrPost;
                    parameter.Name = string.Format("room{0}", roomNumber);
                    request.AddParameter(parameter);
                }
            }

            // for performance boost
            request.AddParameter("supplierCacheTolerance", "MAX_ENHANCED");

            return Execute<HotelListResponse>(request);
        }

        public override HotelListResponse GetHotelActiveList(HotelListRequest hotelListRequest)
        {
            Require.Argument("hotelListRequest", hotelListRequest);  // Guard Clause

            RestRequest restRequest = new RestRequest
                {
                    Resource = "list",
                    Method = Method.GET,
                    RootElement = "HotelListResponse"
                };

            if (hotelListRequest.DestinationString.HasValue())
            {
                // Free text destination search
                restRequest.AddParameter("destinationString", hotelListRequest.DestinationString);
            }
            else
            {
                // City, State, Country Search

                if (hotelListRequest.City.HasValue())
                    restRequest.AddParameter("city", hotelListRequest.City);

                if (hotelListRequest.CountryCode.HasValue())
                    restRequest.AddParameter("countryCode", hotelListRequest.CountryCode); 

                if (hotelListRequest.StateProvinceCode.HasValue())
                    restRequest.AddParameter("stateProvinceCode", hotelListRequest.StateProvinceCode); 
            }

            HandleFilteringMethods(restRequest, hotelListRequest);

            return Execute<HotelListResponse>(restRequest);
        }

        public override HotelInformationResponse GetHotelInformation(HotelInformationRequest hotelInformationRequest)
        {
            Require.Argument("hotelInformationRequest", hotelInformationRequest); // Guard Clause

            var request = new RestRequest
                {
                    Resource = "info",
                    Method = Method.GET,
                    RootElement = "HotelInformationResponse"
                };

            request.AddParameter("hotelId", hotelInformationRequest.HotelId);
            request.AddParameter("options", hotelInformationRequest.Options != null ? String.Join(",", hotelInformationRequest.Options) : "DEFAULT");

            return Execute<HotelInformationResponse>(request);
        }

        /**
         * http://api.ean.com/ean‑services/rs/hotel/v3/avail?minorRev=[current minorRev #]
         * &cid=55505
         * &apiKey=[xxx-yourOwnKey-xxx]
         * &customerUserAgent=[xxx]
         * &customerIpAddress=[xxx]
         * &customerSessionId=[xxx]
         * &locale=en_US
         * &currencyCode=USD
         * &hotelId=109496
         * &arrivalDate=08/03/2012
         * &departureDate=08/04/2012
         * &includeDetails=true
         * &room1=2
         * &options=HOTEL_DETAILS 
         */

        public override HotelRoomAvailabilityResponse GetHotelRoomAvailability(HotelRoomAvailabilityRequest roomAvailabilityRequest)
        {
            Require.Argument("roomAvailabilityRequest", roomAvailabilityRequest);

            RestRequest request = new RestRequest();
            request.Resource = "avail";
            request.Method = Method.GET;

            request.RootElement = "HotelRoomAvailabilityResponse";
            request.AddParameter("options", "ROOM_TYPES,ROOM_AMENITIES");
            request.AddParameter("hotelId", roomAvailabilityRequest.HotelId);
            request.AddParameter("arrivalDate", roomAvailabilityRequest.ArrivalDate.ToShortDateString());
            request.AddParameter("departureDate", roomAvailabilityRequest.DepartureDate.ToShortDateString());
            request.AddParameter("includeDetails", "true");
            request.AddParameter("includeRoomImages", "true");

            if (roomAvailabilityRequest.RoomGroup != null)
            {
                for (int i = 0; i < roomAvailabilityRequest.NumberOfBedrooms; i++)
                {
                    var parameter = new Parameter();
                    parameter.Value = roomAvailabilityRequest.RoomGroup[i].NumberOfAdults + (roomAvailabilityRequest.RoomGroup[i].ChildAges == null ? string.Empty : ("," + String.Join(",", roomAvailabilityRequest.RoomGroup[i].ChildAges.Take(roomAvailabilityRequest.RoomGroup[i].NumberOfChildren).ToArray())));
                    parameter.Type = ParameterType.GetOrPost;
                    parameter.Name = "room" + (roomAvailabilityRequest.RoomGroup.IndexOf(roomAvailabilityRequest.RoomGroup[i]) + 1);
                    request.AddParameter(parameter);
                }
            }

            return Execute<HotelRoomAvailabilityResponse>(request);
        }

        public override LocationInfoResponse GetGeoSearch(LocationInfoRequest locationInfoRequest)
        {
            Require.Argument("locationInfoRequest", locationInfoRequest);
            
            RestRequest request = new RestRequest();
            request.Resource = "geoSearch";
            request.Method = Method.GET;
            request.RootElement = "LocationInfoResponse";

            // LOCATION REQUESTS
            
            //Values: 
            //0: unknown
            //1: city
            //2: landmark
            //3: neighborhood
            //4: airport
            //5: address

            if (locationInfoRequest.DestinationString.HasValue())
            {
                // Get Landmarks by Destination String
                request.AddParameter("destinationString", locationInfoRequest.DestinationString);
                request.AddParameter("type", 2); // Landmarks I presume
            }

            if (locationInfoRequest.DestinationId.HasValue())
            {
                // Return information about an already known destination Id, something specific for a stored session
                request.AddParameter("destinationId", locationInfoRequest.DestinationId);
                request.AddParameter("type", 2); // Landmarks I presume
            }

            return Execute<LocationInfoResponse>(request);
        }


        /// <summary>
        /// <a href="http://developer.ean.com/docs/hotels/version_3/cancel_reservation/">Cancel Reservation</a>
        /// </summary>
        /// <param name="hotelRoomCancellationRequest"></param>
        /// <returns></returns>
        public override HotelRoomCancellationResponse GetHotelRoomCancel(HotelRoomCancellationRequest hotelRoomCancellationRequest)
        {
            throw new NotImplementedException();
        }

        public override PingResponse GetPing(PingRequest pingRequest)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This is used in two other API calls.
        /// 
        ///  A Hotel Availability request
        /// <see cref="GetHotelAvailabilityList"/>
        /// A Hotel Dateless / Active hotels request 
        /// <see cref="GetHotelActiveList"/>
        /// </summary>
        /// <param name="request">The RestRequest</param>
        /// <param name="hotelListRequest">The HotelListRequest</param>
        private void HandleFilteringMethods(RestRequest request, HotelListRequest hotelListRequest)
        {
            if (hotelListRequest.PropertyCategories != null)
            {
                request.AddParameter("propertyCategory", string.Join(",", hotelListRequest.PropertyCategories.Select(pc => Convert.ToInt32(pc))));
            }

            if (hotelListRequest.Amenities != null)
            {
                request.AddParameter("amenities", string.Join(",", hotelListRequest.Amenities.Select(a => Convert.ToInt32(a))));
            }

            if (hotelListRequest.MinStarRating.HasValue)
            {
                request.AddParameter("minStarRating", hotelListRequest.MinStarRating.Value);
            } 

            if (hotelListRequest.MaxStarRating.HasValue)
            {
                request.AddParameter("maxStarRating", hotelListRequest.MaxStarRating.Value);
            }
        }
    }
}
