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
    public class OverallSeriesTest
    {
        float firstNumber = 1.62f;
        float growRate = 2.5f;
        int length = 5;
        IEnumerable<float> series;

        public IEnumerable<float> GivenSeries()
        {
            series = Series.OverallSeries(firstNumber, growRate, length);
            return series;
        }

        [Test]
        public void SeriesLengthShouldBeAsRequested()
        {
            GivenSeries();
            series.Count().ShouldBeEquivalentTo(length, "series length sould be as long as requested");
        }
        
        [Test]
        public void SeriesShouldNotContainAnyDuplicates()
        {
            GivenSeries();

            series.Should().OnlyHaveUniqueItems("series should not contain any duplicates");
        }

        [Test]
        public void SeriesShouldBeOrderedAscending()
        {
            GivenSeries();
           
            series.Should().BeInAscendingOrder("series should be ordered ascending");
        }

        [Test]
        public void NumbersInTheSeriesShouldBeRounded() 
        {
            GivenSeries();

            

            series.Should()
                .Match(s => s.All(e =>  e%0.25f == 0), "numbers in the series should be rounded");

        }

        [Test]
        public void NumbersInTheSeriesShouldBeRoundedToTheNearest() 
        {
            throw new NotImplementedException();
        }
    }
}
