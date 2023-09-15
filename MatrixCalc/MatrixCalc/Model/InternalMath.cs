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

        public int RefreshMin(List<InputEntry> EntryList)
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

        public int RefreshMin(int lineNum, List<List<InputEntry>> Lines)
        {
            int currentMin = int.MaxValue;
            int itemText;
            List<InputEntry> line = Lines[lineNum];

                foreach (var item in line)
                {
                    itemText = Convert.ToInt32(item.Text);
                    if (itemText < currentMin)
                    {
                        currentMin = itemText;
                    }
                }

            return currentMin;
        }

        public int RefreshMax(List<InputEntry> EntryList)
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

        public int RefreshMax(int lineNum, List<List<InputEntry>> Lines)
        {
            int currentMax = int.MinValue;
            int itemText;
            List<InputEntry> line = Lines[lineNum];

            foreach (var item in line)
            {
                itemText = Convert.ToInt32(item.Text);
                if (itemText > currentMax)
                    {
                        currentMax = itemText;
                    }
            }

            return currentMax;
        }

        public int RefreshAverage(List<InputEntry> EntryList)
        {
            int currentSum = 0;

                foreach (var item in EntryList)
                {
                    currentSum += Convert.ToInt32(item.Text);
                }

            return currentSum / EntryList.Count;
        }


        public int RefreshAverage(int lineNum, List<List<InputEntry>> Lines)
        {
            int currentSum = 0;
            int itemText;
            List<InputEntry> line = Lines[lineNum];

            foreach (var item in line)
            {
                itemText = Convert.ToInt32(item.Text);
                currentSum += itemText;
            }

            return currentSum / line.Count;
        }

        public int RefreshSum(int lineNum, List<List<InputEntry>> Lines)
        {
            int currentSum = 0;
            int itemText;
            List<InputEntry> line = Lines[lineNum];

            foreach (var item in line)
            {
                itemText = Convert.ToInt32(item.Text);
                currentSum += itemText;
            }

            return currentSum;
        }
    }
}

