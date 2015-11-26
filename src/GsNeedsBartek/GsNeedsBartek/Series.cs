using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsNeedsBartek
{
    public class Series
    {
        public readonly float X;
        public readonly float Y;
        public readonly int Length;

        public Series(float x, float y, int length)
        {
            X = x;
            Y = y;
            Length = length;
        }

        public IEnumerable<float> Generate()
        {
            var firstNumber = SeriesGenerator.FirstNumber(X);

            return SeriesGenerator.OverallSeries(firstNumber, SeriesGenerator.GrowRate(Y, firstNumber),Length);
        }

        /// <summary>
        /// a. Number1 is the third largest number in the ordered series
        /// </summary>
        /// <returns></returns>
        public float Number1()
        {
            return Generate().OrderByDescending(_ => _).Skip(2).FirstOrDefault();
        }

        /// <summary>
        /// b. Number2 is chosen by first calculating the product of the following function
        ////where ‘y’ is a constant
        ////and ‘z’ is an input of the function
        ////then by selecting the closest number in the series to the aproximateNumber. If two
        ////numbers are evenly apart from the approximateNumber the highest number is chosen.
        ////approximateNumber = y/z
        /// </summary>
        /// <returns></returns>
        public float Number2(float y, float z)
        {
            var approximateNumber = y/z;

            return
                Generate()
                    .Select(e => new {Distance = Math.Abs(e - approximateNumber), Value = e})
                    .ToLookup(t => t.Distance, t => t.Value)
                    .OrderBy(g => g.Key)
                    .First().Max();
        }
    }
}
