using Gridnine.FlightCodingTest;
using Gridnine.Tests.TestData;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gridnine.Tests
{
    public class FlightFilterHandlerTests
    {
        [Fact]
        public void Print_Exception()
        {
            var filterHandler = new FlightFilterHandler();

            Action actual = () => filterHandler.Print(null);

            var exception = Assert.Throws<ArgumentNullException>(actual);

            Assert.Equal(FlightFilterHandlerTestData.ExceptionMessage, exception.Message);
        }

        [Fact]
        public void GetFilteredValues_Exception()
        {
            var filterHandler = new FlightFilterHandler();

            Action actual = () => filterHandler.GetFilteredValues(1, null);

            var exception = Assert.Throws<ArgumentNullException>(actual);

            Assert.Equal(FlightFilterHandlerTestData.ExceptionMessage, exception.Message);
        }

        [Fact]
        public void GetFilteredValues_BadKey()
        {
            var filterHandler = new FlightFilterHandler();

            var result = filterHandler.GetFilteredValues(FlightFilterHandlerTestData.BadKey, new List<Flight>());

            Assert.Null(result);
        }

        [Fact]
        public void GetCurrentFlights_Ok()
        {
            var flightBuilder = new FlightBuilder();

            var filterHandler = new FlightFilterHandler();

            var flights = flightBuilder.GetFlights();

            var deleteFligthts = FlightFilterHandlerTestData.GetDeletedFlightsForFilter_1(flights);

            var result = filterHandler.GetFilteredValues(1, flights);

            foreach (var deleteFligtht in deleteFligthts)
            {
                Assert.All(result, item => Assert.DoesNotContain(deleteFligtht, result));
            }
        }

        [Fact]
        public void GetInvalidFlights_Ok()
        {
            var flightBuilder = new FlightBuilder();

            var filterHandler = new FlightFilterHandler();

            var flights = flightBuilder.GetFlights();

            var deleteFlights = FlightFilterHandlerTestData.GetDeletedFlightsForFilter_2(flights);

            var result = filterHandler.GetFilteredValues(2, flights);

            foreach (var deleteFlight in deleteFlights)
            {
                Assert.All(result, item => Assert.DoesNotContain(deleteFlight, result));
            }
        }

        [Fact]
        public void GetLongFlights_Ok()
        {
            var flightBuilder = new FlightBuilder();

            var filterHandler = new FlightFilterHandler();

            var flights = flightBuilder.GetFlights();

            var longFlights = FlightFilterHandlerTestData.GetDeletedFlightsForFilter_3(flights);

            var result = filterHandler.GetFilteredValues(3, flights);

            foreach (var longFlight in longFlights)
            {
                Assert.All(result, item => Assert.DoesNotContain(longFlight, result));
            }
        }
    }
}
