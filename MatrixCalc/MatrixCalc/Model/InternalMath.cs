using System;
using System.Collections.Generic;
using MatrixCalc.Model.MathInterfaces;
using MatrixCalc.Model.MatrixInterfaces;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class InternalMath : IPageMath
    {
        public List<IMatrixEntry> EntryList { get; set; }
        public List<IMatrixButton> ButtonList { get; set; }
        public List<List<int>> Lines { get; set; }

        public InternalMath()
		{
		}

        public int RefreshMin()
        {
            int currentMin = int.MaxValue;
            foreach (var item in EntryList)
            {
                try
                {
                    if (Convert.ToInt32(item.Text) < currentMin)
                    {
                        currentMin = Convert.ToInt32(item.Text);
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }

            }
            return currentMin;
        }

        public int RefreshMin(int lineNum)
        {
            int currentMin = int.MaxValue;
            List<int> line = Lines[lineNum];

            foreach (var item in line)
            {
                try
                {
                    if (item < currentMin)
                    {
                        currentMin = item;
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

            return currentMin;
        }

        public int RefreshMax()
        {
            int currentMax = int.MinValue;
            foreach (var item in EntryList)
            {
                try
                {
                    if (Convert.ToInt32(item.Text) > currentMax)
                    {
                        currentMax = Convert.ToInt32(item.Text);
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }

            }
            return currentMax;
        }

        public int RefreshMax(int lineNum)
        {
            int currentMax = int.MinValue;
            List<int> line = Lines[lineNum];

            foreach (var item in line)
            {
                try
                {
                    if (item > currentMax)
                    {
                        currentMax = item;
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

            return currentMax;
        }

        public int RefreshAverage()
        {
            int currentSum = 0;
            foreach (var item in EntryList)
            {
                try
                {
                    currentSum += Convert.ToInt32(item.Text);
                }
                catch (Exception ex)
                {
                    return -1;
                }

            }
            return currentSum / EntryList.Count;
        }


        public int RefreshAverage(int lineNum)
        {
            int currentSum = 0;
            List<int> line = Lines[lineNum];

            foreach (var item in line)
            {
                try
                {
                    currentSum += item;
                }
                catch (Exception ex)
                {
                    return -1;
                }

            }
            return currentSum / line.Count;
        }

        public int RefreshSum(int lineNum)
        {
            int currentSum = 0;
            List<int> line = Lines[lineNum];

            foreach (var item in line)
            {
                try
                {
                    currentSum += item;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

            return currentSum;
        }
    }
}

