using Gridnine.FlightCodingTest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.Tests.TestData
{
    internal static class FlightFilterHandlerTestData
    {
        internal static int BadKey { get; } = 4;
        internal static string ExceptionMessage { get; } = "Передана пустая ссылка на объект (Parameter 'flights')";

        internal static IList<Flight> GetDeletedFlightsForFilter_1(IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { Flight = f, Segment = s })
                .Where(anonim => anonim.Segment.DepartureDate < DateTime.Now)
                .GroupBy(anonim => anonim.Flight)
                .Select(grouping => grouping.Key).ToList();
        }

        internal static IList<Flight> GetDeletedFlightsForFilter_2(IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { Flight = f, Segment = s })
               .Where(anonim => anonim.Segment.ArrivalDate < anonim.Segment.DepartureDate)
               .GroupBy(anonim => anonim.Flight)
               .Select(grouping => grouping.Key).ToList();
        }

        internal static IList<Flight> GetDeletedFlightsForFilter_3(IList<Flight> flights)
        {
            var longFlights = new List<Flight>();

            foreach (var flight in flights)
            {
                TimeSpan temp = default;
                DateTime arrivalDate = default;

                foreach (var segment in flight.Segments)
                {
                    if (arrivalDate != default)
                        temp += segment.DepartureDate.Subtract(arrivalDate);

                    arrivalDate = segment.ArrivalDate;
                }

                if (temp > TimeSpan.FromHours(2))
                    longFlights.Add(flight);
            }

            return longFlights;
        }
    }
}
