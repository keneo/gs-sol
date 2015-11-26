using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsNeedsBartek
{
    public class Series
    {
        /// <summary>
        /// a. The first number is calculated given the following function (which accepts a parameter ‘x’):
        /// ((0.5 * x^2) + (30 * x) + 10) / 25
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float FirstNumber(float x)
        {
            return -1; //todo
        }

        /// <summary>
        /// b. A growth rate for the series is calculated using the following function (which accepts
        /// parameters ‘y’ and the first number from a.):
        /// (2% of y)/25/(firstNumber)
        /// </summary>
        /// <param name="y"></param>
        /// <param name="firstNumber"></param>
        /// <returns></returns>
        public static float GrowRate(float y, float firstNumber)
        {
            return -1; //todo
        }

        private static IEnumerable<float> OverallSeriesFormula(float firstNumber, float growthRate)
        {
            yield return firstNumber;

            float number = growthRate;

            while (true)
            {
                yield return number;
                number *= firstNumber;
            }
        }

        /// <summary>
        /// c. The overall series is calculated using a function that accepts three parameters
        ////firstNumber – the number from a.
        ////growthRate – the number from b.
        ////length ­ the length of the resulting series
        ////The series should start with the first number; the subsequent numbers should be calculated
        ////as a product of:
        ////growthRate * (firstNumber^(index of the number being generated))
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="growthRate"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<float> OverallSeries(float firstNumber, float growthRate, int length)
        {
            return
                OverallSeriesFormula(firstNumber, growthRate)
                .Distinct()
                .Take(length)
                .OrderBy(x=>x)
                .Select(x=>ApplyRounding(x));

        }

        private static float ApplyRounding(float f)
        {
            return (float) (Math.Round(f*4)/4);
        }
    }
}
