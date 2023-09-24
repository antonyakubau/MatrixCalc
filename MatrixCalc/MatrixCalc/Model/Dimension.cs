using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;

namespace MatrixCalc.Model
{
	public class Dimension
	{
        public const int MAXDIM = 10;
        public const int MINDIM = 1;

        private int upperBound;
        private int lowerBound;
        private int startDimension;

        public Dimension(int lowerBound, int upperBound, int startDimension)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            StartDimension = startDimension;
        }

        public int UpperBound
        {
            get { return upperBound; }
            private set
            {
                if (value <= MAXDIM)
                    upperBound = value;
                else
                    upperBound = MAXDIM;
            }

        }

        public int LowerBound
        {
            get { return lowerBound; }
            private set
            {
                if (value >= MINDIM)
                    lowerBound = value;
                else
                    lowerBound = MINDIM;
            }
        }

        public int StartDimension
        {
            get { return startDimension; }
            private set
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

        public int IncreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension < UpperBound)
            {
                currentMatrixDimension++;
                return currentMatrixDimension;
            }

            return currentMatrixDimension;
        }


        public int DecreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension > LowerBound)
            {
                currentMatrixDimension--;
                return currentMatrixDimension;
            }

            return currentMatrixDimension;
        }
    }
}

