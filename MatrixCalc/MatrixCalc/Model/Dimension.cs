using System;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public class Dimension
	{
        public const int MAXDIM = 10;
        public const int MINDIM = 1;

        private int _upperBound;
        private int _lowerBound;
        private int _startDimension;

        public Dimension(int lowerBound, int upperBound, int startDimension)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            StartDimension = startDimension;
        }

        public int UpperBound
        {
            get { return _upperBound; }
            private set
            {
                if (value <= MAXDIM)
                    _upperBound = value;
                else
                    _upperBound = MAXDIM;
            }

        }

        public int LowerBound
        {
            get { return _lowerBound; }
            private set
            {
                if (value >= MINDIM)
                    _lowerBound = value;
                else
                    _lowerBound = MINDIM;
            }
        }

        public int StartDimension
        {
            get { return _startDimension; }
            private set
            {
                if (LowerBound == 0 || UpperBound == 0)
                    throw new IndexOutOfRangeException("StartDimension must be set last");

                if (LowerBound >= UpperBound)
                    throw new IndexOutOfRangeException("LowerBound must be lower than UpperBound");

                if (UpperBound <= LowerBound)
                    throw new IndexOutOfRangeException("UpperBound must be higher than LowerBound");


                if (value < LowerBound)
                    _startDimension = LowerBound;
                else
                if (value > UpperBound)
                    _startDimension = UpperBound;
                else
                    _startDimension = value;
            }

        }

        public int IncreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension < UpperBound)
                currentMatrixDimension++;

            return currentMatrixDimension;
        }


        public int DecreaseDimension(int currentMatrixDimension)
        {
            if (currentMatrixDimension > LowerBound)
                currentMatrixDimension--;

            return currentMatrixDimension;
        }
    }
}

