using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class InternalMath
    {
        private MatrixPageVM matrixPageVM;

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }
        public List<List<int>> Lines { get; set; }

        public InternalMath(MatrixPageVM _matrixPageVM)
		{
            matrixPageVM = _matrixPageVM;
		}


        public void RefreshMin()
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
                    matrixPageVM.UpdateMainMatrix();
                }

            }
            matrixPageVM.Min = currentMin;
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
                    matrixPageVM.UpdateMainMatrix();
                }
            }

            return currentMin;
        }

        public void RefreshMax()
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
                    matrixPageVM.UpdateMainMatrix();
                }

            }
            matrixPageVM.Max = currentMax;
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
                    matrixPageVM.UpdateMainMatrix();
                }
            }

            return currentMax;
        }

        public void RefreshAverage()
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
                    matrixPageVM.UpdateMainMatrix();
                }

            }
            matrixPageVM.Average = currentSum / EntryList.Count;
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
                    matrixPageVM.UpdateMainMatrix();
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
                    matrixPageVM.UpdateMainMatrix();
                }
            }

            return currentSum;
        }
    }
}

