namespace Gridnine.FlightCodingTest
{
    public class WorkerNestedTypesFactory
    {
        public IFlightBuilder GetFlightBuilder() => new FlightBuilder();
        public IFilterBuilder GetFilterBuilder() => new FilterBuilder();
        public IFilterHandler<Flight> GetFilterHandler() => new FlightFilterHandler();
    }
}
