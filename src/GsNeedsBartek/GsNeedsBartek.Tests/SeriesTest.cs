﻿using System;
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
        float firstNumber = 0;
        float growRate = 1;
        int length = 10;
        IEnumerable<float> series;

        public IEnumerable<float> GivenSeries()
        {
            series = Series.OveralSeries(firstNumber, growRate, length);
            return series;
        }

        [Test]
        public void SeriesLengthShouldBeAsRequested()
        {
            GivenSeries();
            series.Count().ShouldBeEquivalentTo(10, "series length sould be as long as requested");
        }
        
        [Test]
        public void SeriesShouldNotContainAnyDuplicates()
        {
            GivenSeries();


            var duplicates = series.ToLookup(x => x).Where(e => e.Count() > 1);

            duplicates.Should().BeEmpty("series should not contain any duplicates");
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
