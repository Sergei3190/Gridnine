using System;

namespace Gridnine.FlightCodingTest
{
    public class Worker
    {
        private readonly IFlightBuilder _flightBuilder;
        private readonly IFilterBuilder _filterBuilder;
        private readonly IFilterHandler<Flight> _filterHandler;

        public Worker(WorkerNestedTypesFactory workerNestedTypesFactory)
        {
            _flightBuilder = workerNestedTypesFactory.GetFlightBuilder();
            _filterBuilder = workerNestedTypesFactory.GetFilterBuilder();
            _filterHandler = workerNestedTypesFactory.GetFilterHandler();
        }

        public int RunWorker()
        {
            try
            {
                Console.WriteLine($"**********Программа фильтрации списка авиа перелетов**********{Environment.NewLine}");

                Console.WriteLine($"Список авиа перелетов:{Environment.NewLine}");

                var flights = _flightBuilder.GetFlights();

                _filterHandler.Print(flights);

                Console.WriteLine($"Доступные фильтры для исключения из списка авиа перелетов:{Environment.NewLine}");

                foreach (var item in _filterBuilder.GetFilters())
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }

                Console.WriteLine();

                var input = string.Empty;

                do
                {
                    Console.WriteLine(@"Введите номер фильтрации или ""q"" для выхода из программы: ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int key))
                    {
                        var filteredFlights = _filterHandler.GetFilteredValues(key, flights);

                        if (filteredFlights != null)
                            _filterHandler.Print(filteredFlights);
                    }

                } while (!input.Equals("q", StringComparison.OrdinalIgnoreCase));

                return 1;
            }
            catch (ArgumentNullException ax)
            {
                Console.WriteLine($"{ax.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return -1;
            }
        }
    }
}
