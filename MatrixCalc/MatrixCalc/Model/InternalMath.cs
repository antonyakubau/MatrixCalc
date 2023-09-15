using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class InternalMath : IPageMath
    {
        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }
        public List<List<int>> Lines { get; set; }

        public InternalMath()
		{
		}

        public int RefreshMin()
        {
            int currentMin = int.MaxValue;

            try
            {
                foreach (var item in EntryList)
                {
                    if (Convert.ToInt32(item.Text) < currentMin)
                    {
                        currentMin = Convert.ToInt32(item.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentMin;
        }

        public int RefreshMin(int lineNum)
        {
            int currentMin = int.MaxValue;
            List<int> line = Lines[lineNum];

            try
            {
                foreach (var item in line)
                {
                    if (item < currentMin)
                    {
                        currentMin = item;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentMin;
        }

        public int RefreshMax()
        {
            int currentMax = int.MinValue;

            try
            {
                foreach (var item in EntryList)
                {
                    if (Convert.ToInt32(item.Text) > currentMax)
                    {
                        currentMax = Convert.ToInt32(item.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            return currentMax;
        }

        public int RefreshMax(int lineNum)
        {
            int currentMax = int.MinValue;
            List<int> line = Lines[lineNum];

            try
            {
                foreach (var item in line)
                {
                    if (item > currentMax)
                    {
                        currentMax = item;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentMax;
        }

        public int RefreshAverage()
        {
            int currentSum = 0;

            try
            {
                foreach (var item in EntryList)
                {
                    currentSum += Convert.ToInt32(item.Text);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentSum / EntryList.Count;
        }


        public int RefreshAverage(int lineNum)
        {
            int currentSum = 0;
            List<int> line = Lines[lineNum];

            try
            {
                foreach (var item in line)
                {
                    currentSum += item;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentSum / line.Count;
        }

        public int RefreshSum(int lineNum)
        {
            int currentSum = 0;
            List<int> line = Lines[lineNum];

            try
            {
                foreach (var item in line)
                {
                    currentSum += item;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return currentSum;
        }
    }
}

