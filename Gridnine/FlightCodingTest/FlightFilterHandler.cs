using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    public class FlightFilterHandler : IFilterHandler<Flight>
    {
        public void Print(IList<Flight> flights)
        {
            if (flights is null)
                throw new ArgumentNullException(nameof(flights), "Передана пустая ссылка на объект");

            var count = 0;

            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight №{++count}: ");

                foreach (var segment in flight.Segments)
                {
                    Console.WriteLine($"DepartureDate = {segment.DepartureDate}, ArrivalDate = {segment.ArrivalDate}");
                }

                Console.WriteLine();
            }
        }

        public IList<Flight> GetFilteredValues(int key, IList<Flight> flights)
        {
            if (flights is null)
                throw new ArgumentNullException(nameof(flights), "Передана пустая ссылка на объект");

            switch (key)
            {
                case 1:
                    return GetFlightsForFilterOne(flights);
                case 2:
                    return GetFlightsForFilterTwo(flights);
                case 3:
                    return GetFlightsForFilterThree(flights);
                default:
                    Console.WriteLine($"Нет правила фильтрации с ключом = {key}{Environment.NewLine}");
                    return null;
            }
        }

        private IList<Flight> GetFlightsForFilterOne(IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { Flight = f, Segment = s })
                .Where(anonim => anonim.Segment.DepartureDate > DateTime.Now)
                .GroupBy(anonim => anonim.Flight)
                .Select(grouping => grouping.Key).ToList();
        }

        private IList<Flight> GetFlightsForFilterTwo(IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { Flight = f, Segment = s })
               .Where(anonim => anonim.Segment.ArrivalDate > anonim.Segment.DepartureDate)
               .GroupBy(anonim => anonim.Flight)
               .Select(grouping => grouping.Key).ToList();
        }

        private IList<Flight> GetFlightsForFilterThree(IList<Flight> flights)
        {
            var fastFlights = new List<Flight>();

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

                if (temp <= TimeSpan.FromHours(2))
                    fastFlights.Add(flight);
            }

            return fastFlights;
        }
    }
}
