using System;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class Dimension
	{
        private int MaxDimension;
        private int MinDimension;

        private int startDimension;
		public int StartDimension
        {
            get { return startDimension; }
            set
            {
                if (LowerBound == 0 || UpperBound == 0)
                    throw new IndexOutOfRangeException("StartDimension must be set last");

                if (LowerBound >= UpperBound)
                    throw new IndexOutOfRangeException("LowerBound must be lower than UpperBound");

                if (UpperBound <= LowerBound)
                    throw new IndexOutOfRangeException("UpperBound must be higher than LowerBound");


                if (value < LowerBound)
                    startDimension = LowerBound;
                else
                if (value > UpperBound)
                    startDimension = UpperBound;
                else
                    startDimension = value;
            }

        }

        private int upperBound;
        public int UpperBound
        {
            get { return upperBound; }

            set
            {
                if (value <= MaxDimension)
                    upperBound = value;
                else
                    upperBound = MaxDimension;
            }

        }

        private int lowerBound;
        public int LowerBound
        {
            get { return lowerBound; }
            set
            {
                if (value >= MinDimension)
                    lowerBound = value;
                else
                    lowerBound = MinDimension;
            }
        }

        public Dimension()
        {
            MaxDimension = 20;
            MinDimension = 2;
        }

        public int ChangeDimension(string action, int currentMatrixDimension)
        {
            switch (action)
            {
                case "inc":
                    if (currentMatrixDimension < UpperBound)
                    {
                        currentMatrixDimension++;
                        GetInfoButton.DecreaseFontSize(); // try to change
                        InputEntry.UpdateFontSize();
                        return currentMatrixDimension;
                    }
                    break;
                case "dec":
                    if (currentMatrixDimension > LowerBound)
                    {
                        currentMatrixDimension--;
                        GetInfoButton.IncreaseFontSize();
                        InputEntry.UpdateFontSize();
                        return currentMatrixDimension;
                    }
                    break;
            }
            return currentMatrixDimension;
        }
        public int IncreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension < UpperBound)
            {
                currentMatrixDimension++;
                GetInfoButton.DecreaseFontSize(); // try to change
                InputEntry.UpdateFontSize();
                return currentMatrixDimension;
            }
                   
            return currentMatrixDimension;
        }


        public int DecreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension > LowerBound)
            {
                currentMatrixDimension--;
                GetInfoButton.IncreaseFontSize();
                InputEntry.UpdateFontSize();
                return currentMatrixDimension;
            }

            return currentMatrixDimension;
        }
    }
}

