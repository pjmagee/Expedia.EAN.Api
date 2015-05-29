namespace EAN.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EAN.Api.Impl;
    using Messages;
    using Messages.Request;
    using Messages.Response;
    using NUnit.Framework;

    [TestFixture]
    public class HotelListTests
    {
        private RestExpediaService expediaService;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            expediaService = new RestExpediaService();
            expediaService.ApiKey = "[API KEY]";
            expediaService.Cid = 55505;
            expediaService.CurrencyCode = "GBP";
            expediaService.MinorRev = 13;
            expediaService.Locale = "en_GB";
        }

        [SetUp]
        public void SetUp()
        {
           
        }

        [Test(Description = "Search request with City and Country code returns results")]
        public void HotelListRequestMethodOneUk()
        {
            // Arrange
            HotelListRequest hotelListRequest = new HotelListRequest();
            hotelListRequest.City = "London";
            hotelListRequest.CountryCode = "UK";

            // Act
            HotelListResponse hotelListResponse = expediaService.GetHotelActiveList(hotelListRequest);

            // Assert
            Assert.That(hotelListResponse.HotelList.HotelSummary.Any());
        }

        [Test(Description = "Search request with City, Country and State returns results")]
        public void HotelListRequestMethodOneUs()
        {
            // Arrange
            HotelListRequest hotelListRequest = new HotelListRequest();
            hotelListRequest.City = "New York";
            hotelListRequest.CountryCode = "US";
            hotelListRequest.StateProvinceCode = "NY";

            // Act
            HotelListResponse hotelListResponse = expediaService.GetHotelActiveList(hotelListRequest);

            // Assert
            Assert.That(hotelListResponse.HotelList.HotelSummary.Any());
        }

        [Test(Description = "Search request with City, Country, Dates and Rooms returns results")]
        public void HotelListRequestBasicAvailability()
        {
            // Arrange
            HotelListRequest hotelListRequest = new HotelListRequest();
            hotelListRequest.City = "London";
            hotelListRequest.CountryCode = "UK";
            hotelListRequest.ArrivalDate = new DateTime(2013, 02, 07);
            hotelListRequest.DepartureDate = new DateTime(2013, 03, 07);
            hotelListRequest.RoomGroup = new List<Room>();
            hotelListRequest.RoomGroup.Add(new Room {NumberOfAdults = 1, NumberOfChildren = 0});
            hotelListRequest.RoomGroup.Add(new Room {NumberOfAdults = 2, NumberOfChildren = 2, ChildAges = new List<int> {14, 16}});

            // Act
            //HotelListResponse hotelListResponse = expediaService.GetHotelAvailabilityList(hotelListRequest);

            // Assert
            //Assert.That(hotelListResponse.HotelList.HotelSummary.Any());
        }


        [Test(Description = "Search request with City, Country, and Property Category all Inclusive returns results")]
        public void HotelListRequestWithAllInclusiveFilter()
        {
            // Arrange
            HotelListRequest hotelListRequest = new HotelListRequest();
            hotelListRequest.City = "London";
            hotelListRequest.CountryCode = "UK";
            hotelListRequest.PropertyCategories = new List<PropertyCategory>();
            hotelListRequest.PropertyCategories.Add(PropertyCategory.AllInclusive); // Return all that are Inclusive

            // Act
            HotelListResponse hotelListResponse = expediaService.GetHotelActiveList(hotelListRequest);

            // Assert
            if (hotelListResponse.HotelList != null)
            {
                if (hotelListResponse.HotelList.HotelSummary != null)
                {
                    foreach (var summary in hotelListResponse.HotelList.HotelSummary)
                    {
                        Console.WriteLine((PropertyCategory)summary.PropertyCategory);

                        Assert.That(hotelListRequest.PropertyCategories.Contains((PropertyCategory)summary.PropertyCategory));
                    }
                }
            }
        }

        [Test(Description = "Search request with Swimming Pool amenity brings back results with swimming")]
        public void HotelListRequestWithAmenitiesFilter()
        {
            // Arrange
            HotelListRequest hotelListRequest = new HotelListRequest();
            hotelListRequest.City = "New York";
            hotelListRequest.CountryCode = "US";
            hotelListRequest.StateProvinceCode = "NY";

            hotelListRequest.Amenities = new List<Amenity>(){ Amenity.SwimmingPool };

            // Act
            HotelListResponse hotelListResponse = expediaService.GetHotelActiveList(hotelListRequest);

            // Assert
            if (hotelListResponse.HotelList != null)
            {
                if (hotelListResponse.HotelList.HotelSummary != null)
                {
                    foreach (var summary in hotelListResponse.HotelList.HotelSummary)
                    {
                        Console.WriteLine("Amenity Mask: " + summary.AmenityMask);
                        Console.WriteLine("Contained amenties: ");
                    }
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}
