using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    public interface IFilterBuilder
    {
        Dictionary<int, string> GetFilters();
        void AddFilter(string filter);
        bool RemoveFilter(int key);
    }
}
