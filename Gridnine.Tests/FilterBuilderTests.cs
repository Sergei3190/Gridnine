using Gridnine.FlightCodingTest;
using Gridnine.Tests.TestData;
using Xunit;

namespace Gridnine.Tests
{
    public class FilterBuilderTests
    {
        [Fact]
        public void GetFilters_Ok()
        {
            var filterBuilder = new FilterBuilder();

            var result = filterBuilder.GetFilters();

            Assert.NotEmpty(result);
        }

        [Fact]
        public void AddFilter_Ok()
        {
            var filterBuilder = new FilterBuilder();

            var oldCount = filterBuilder.GetFilters().Count;

            filterBuilder.AddFilter(FilterBuilderTestData.GoodNewFilter);

            var newCount = filterBuilder.GetFilters().Count;

            Assert.NotEqual<int>(oldCount, newCount);
        }

        [Fact]
        public void AddFilter_Bad()
        {
            var filterBuilder = new FilterBuilder();

            var oldCount = filterBuilder.GetFilters().Count;

            filterBuilder.AddFilter(FilterBuilderTestData.BadNewFilter);

            var newCount = filterBuilder.GetFilters().Count;

            Assert.Equal<int>(oldCount, newCount);
        }

        [Fact]
        public void RemoveFilter_Ok()
        {
            var filterBuilder = new FilterBuilder();

            var oldCount = filterBuilder.GetFilters().Count;

            var result = filterBuilder.RemoveFilter(3);

            var newCount = filterBuilder.GetFilters().Count;

            Assert.NotEqual<int>(oldCount, newCount);
            Assert.True(result);
        }

        [Fact]
        public void RemoveFilter_Exception()
        {
            var filterBuilder = new FilterBuilder();

            var oldCount = filterBuilder.GetFilters().Count;

            var result = filterBuilder.RemoveFilter(5);

            var newCount = filterBuilder.GetFilters().Count;

            Assert.Equal<int>(oldCount, newCount);
            Assert.False(result);
        }
    }
}
