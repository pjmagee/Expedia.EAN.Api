namespace EAN.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Messages;
    using Messages.Response;
    using NUnit.Framework;
    using RestSharp;
    using RestSharp.Deserializers;

    [TestFixture]
    public class JsonDeserializerTests
    {
        private readonly string _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "SampleData");
        private const string Pattern = @"(@{1})(?=[a-z]{1,}"":)";
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled);

        private string PathFor(string sampleFile)
        {
            return Path.Combine(_sampleDataPath, sampleFile);
        }

        [Test(Description = "Can deserialise hotel summary")]
        public void JsonAmenitiesBitmaskFromHotelSummary()
        {
            // Arrange
            string doc = File.ReadAllText(PathFor("HotelSummary.json"));

            // Act
            JsonDeserializer jsonDeserializer = new JsonDeserializer { RootElement = "HotelSummary" };
            List<HotelSummary> output = jsonDeserializer.Deserialize<List<HotelSummary>>(new RestResponse { Content = Regex.Replace(doc, "") });

            // Assert
            Assert.NotNull(output);
        }


        [Test(Description = "Can deserialise location info")]
        public void JsonLocationInfoResponse()
        {
            // Arrange
            string doc = File.ReadAllText(PathFor("LocationInfoResponse.json"));

            // Act
            JsonDeserializer jsonDeserializer = new JsonDeserializer() { RootElement = "LocationInfoResponse" };
            LocationInfoResponse output = jsonDeserializer.Deserialize<LocationInfoResponse>(new RestResponse() { Content = Regex.Replace(doc, "") });

            // Assert
            Assert.NotNull(output);
        }

        [Test(Description = "Can deserialise hotel information")]
        public void JsonHotelInformationResponse()
        {
            // Arrange
            string doc = File.ReadAllText(PathFor("HotelInformationResponse.json"));

            // Act
            JsonDeserializer jsonDeserializer = new JsonDeserializer { RootElement = "HotelInformationResponse" };
            HotelInformationResponse output = jsonDeserializer.Deserialize<HotelInformationResponse>(new RestResponse { Content = Regex.Replace(doc, "") });

            // Assert
            Assert.NotNull(output);

            Assert.That(output.HotelSummary.Name == "The Strand Palace");
            Assert.NotNull(output.HotelDetails);
            Assert.That(output.HotelDetails.NumberOfRooms == 785);
            Assert.That(output.RoomTypes.RoomType.Any(roomType => roomType.RoomAmenities.RoomAmenity.Any(roomAmenity => roomAmenity.Amenity == "In-room safe (laptop compatible) ")));

            Assert.NotNull(output.HotelImages);
            Assert.NotNull(output.HotelSummary);
            Assert.NotNull(output.PropertyAmenities);
            Assert.NotNull(output.Suppliers);

        }

        [Test(Description = "Can deserialise room availability response")]
        public void JsonRoomAvailabilityResponse()
        {
            // Arrange
            string doc = File.ReadAllText(PathFor("HotelRoomAvailabilityResponse2.json"));
            
            // Act
            JsonDeserializer jsonDeserializer = new JsonDeserializer() {RootElement = "HotelRoomAvailabilityResponse"};
            RoomAvailabilityResponse output = jsonDeserializer.Deserialize<RoomAvailabilityResponse>(new RestResponse() { Content = Regex.Replace(doc, "") });

            // Assert
            Assert.NotNull(output.CustomerSessionId);
            Assert.NotNull(output.HotelAddress);
            Assert.NotNull(output.HotelCity);
            Assert.NotNull(output.HotelCountry);
            Assert.NotNull(output.HotelRoomResponse);
            Assert.IsNotEmpty(output.HotelRoomResponse);
            
            output.HotelRoomResponse.ForEach(
                (room) =>
                {
                    Assert.True(room.SupplierType == SupplierType.E);
                    Assert.NotNull(room);
                    Assert.NotNull(room.DeepLink);
                    Assert.NotNull(room.PropertyId);
                    Assert.NotNull(room.QuotedOccupancy);

                    Assert.NotNull(room.BedTypes);

                });
        }
    }
}
