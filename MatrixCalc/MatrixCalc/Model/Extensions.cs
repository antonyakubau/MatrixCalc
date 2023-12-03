using System;
namespace MatrixCalc.Model
{
	public static class Extensions
	{
        public static string InRange(this string value, int lowerBound, int upperBound)
        {
            return new Random().Next(lowerBound, upperBound).ToString();
        }
    }
}

