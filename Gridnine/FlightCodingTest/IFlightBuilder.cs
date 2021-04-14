using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    public interface IFlightBuilder
    {
        IList<Flight> GetFlights();
    }
}
