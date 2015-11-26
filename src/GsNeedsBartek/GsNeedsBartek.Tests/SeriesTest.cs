using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace GsNeedsBartek.Tests
{
    [TestFixture]
    public class SeriesTest
    {
        [Test]
        public void SeriesShouldNotContainAnyDuplicates()
        {
            var series = new Series().OveralSeries(0, 1, 10);


            var duplicates = series.ToLookup(x => x).Where(e => e.Count() > 1);

            duplicates.Should().BeEmpty("series should not contain any duplicates");
        }

        [Test]
        public void SeriesShouldBeOrderedAscending()
        {
            var series = new Series().OveralSeries(0, 1, 10);
           
            series.Should().BeInAscendingOrder("series should be ordered ascending");
        }

        [Test]
        public void NumbersInTheSeriesShouldBeRounded() //todo nearest
        {
            var series = new Series().OveralSeries(0, 1, 10);

            

            series.Should()
                .Match(s => s.All(e =>  e%0.25f == 0), "numbers in the series should be rounded");

        }
    }
}
