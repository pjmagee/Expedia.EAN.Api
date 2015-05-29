namespace EAN.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Messages;
    using NUnit.Framework;

    [TestFixture]
    public class RequestBuildingTests
    {
        [Test]
        public void PropertyCategoryTest()
        {
            // Arrange
            var categories = new List<PropertyCategory>();
            categories.Add(PropertyCategory.AllInclusive);
            categories.Add(PropertyCategory.Hotel);
            categories.Add(PropertyCategory.Resort);
            categories.Add(PropertyCategory.VacationRentalCondo);

            // Act
            string delimitedParameter = string.Join(",", categories.Select(category => Convert.ToInt32(category)));

            // Assert
            Console.WriteLine(delimitedParameter);
            var split = delimitedParameter.Split(new[] {','}).Select(int.Parse).OrderByDescending(i => i).ToArray();
        }

        [Test]
        public void AmenitiesTest()
        {
            //Arrange 
            var amenities = new List<Amenity>();
            amenities.Add(Amenity.SwimmingPool);
            amenities.Add(Amenity.Kitchen);
            amenities.Add(Amenity.FitnessCenter);

            // Act
            string delimitedParameter = string.Join(",", amenities.Select(a => Convert.ToInt32(a)));

            // Assert
            Console.WriteLine(delimitedParameter);
        }

    }
}
