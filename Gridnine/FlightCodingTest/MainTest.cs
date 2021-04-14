using System;

namespace Gridnine.FlightCodingTest
{
    class MainTest
    {
        private static void Main()
        {
            var worker = new Worker(new WorkerNestedTypesFactory());

            var result = worker.RunWorker();

            Console.WriteLine($"Программа отработала с кодом {result}");
        }
    }
}
