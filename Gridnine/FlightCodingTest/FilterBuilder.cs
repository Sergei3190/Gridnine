using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    public class FilterBuilder : IFilterBuilder
    {
        private readonly Dictionary<int, string> _filters = new Dictionary<int, string>
        {
            { 1, "вылет до текущего момента времени" },
            { 2, "имеются сегменты с датой прилёта раньше даты вылета" },
            { 3, "общее время, проведённое на земле превышает два часа" }
        };

        public Dictionary<int, string> GetFilters() => _filters;

        public void AddFilter(string filter)
        {
            if (_filters.ContainsValue(filter))
            {
                Console.WriteLine($"Данный фильтр уже существует");
                return;
            }

            var lastKey = _filters.Keys.Count;

            _filters.Add(++lastKey, filter);
        }

        public bool RemoveFilter(int key)
        {
            if (_filters.ContainsKey(key))
            {
                _filters.Remove(key);
                return true;
            }

            return false;
        }
    }
}
