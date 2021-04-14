using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    public interface IFilterHandler<T>
    {
        void Print(IList<T> source);
        IList<T> GetFilteredValues(int key, IList<T> source);
    }
}
