using System;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class Dimension
	{
		public int StartDimension { get; set; }
		public int UpperBound { get; set; }
		public int LowerBound { get; set; }

        public Dimension()
        {

        }

        public int ChangeDimension(string action, int currentMatrixDimension)
        {
            switch (action)
            {
                case "inc":
                    if (currentMatrixDimension < UpperBound)
                    {
                        currentMatrixDimension++;
                        GetInfoButton.DecreaseFontSize();
                        InputEntry.DecreaseFontSize();
                        return currentMatrixDimension;
                    }
                    break;
                case "dec":
                    if (currentMatrixDimension > LowerBound)
                    {
                        currentMatrixDimension--;
                        GetInfoButton.IncreaseFontSize();
                        InputEntry.IncreaseFontSize();
                        return currentMatrixDimension;
                    }
                    break;
            }
            return currentMatrixDimension;
        }

    }
}

