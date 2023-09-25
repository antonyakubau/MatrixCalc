using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class InternalMath : IPageMath
	{
		public InternalMath()
		{
		}

		public int CalculateMin(List<InputEntry> EntryList)
		{
			int currentMin = int.MaxValue;

				foreach (var item in EntryList)
				{
					if (Convert.ToInt32(item.Text) < currentMin)
					{
						currentMin = Convert.ToInt32(item.Text);
					}
				}

			return currentMin;
		}


		public int CalculateMax(List<InputEntry> EntryList)
		{
			int currentMax = int.MinValue;

				foreach (var item in EntryList)
				{
					if (Convert.ToInt32(item.Text) > currentMax)
					{
						currentMax = Convert.ToInt32(item.Text);
					}
				}

			return currentMax;
		}


		public int CalculateAverage(List<InputEntry> EntryList)
		{
			return CalculateSum(EntryList) / EntryList.Count;
		}

		public int CalculateSum(List<InputEntry> EntryList)
		{
			int currentSum = 0;

			foreach (var item in EntryList)
			{ 
				currentSum += Convert.ToInt32(item.Text);
            }

			return currentSum;
		}
	}
}

