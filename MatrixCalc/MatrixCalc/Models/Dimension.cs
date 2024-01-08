using System;
using System.Collections.Generic;

namespace MatrixCalc.Models
{
	public class Dimension
	{
        public const int MAXDIM = 10;
        public const int MINDIM = 1;

        private int _upperBound;
        private int _lowerBound;
        private int _currentDimension;

        public Dimension(int lowerBound, int upperBound, int currentDimension)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            CurrentDimension = currentDimension;
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

        public int CurrentDimension
        {
            get { return _currentDimension; }
            private set
            {
                if (LowerBound == 0 || UpperBound == 0)
                    throw new IndexOutOfRangeException("StartDimension must be set last");

                if (LowerBound >= UpperBound)
                    throw new IndexOutOfRangeException("LowerBound must be lower than UpperBound");

                if (UpperBound <= LowerBound)
                    throw new IndexOutOfRangeException("UpperBound must be higher than LowerBound");


                if (value < LowerBound)
                    _currentDimension = LowerBound;
                else
                if (value > UpperBound)
                    _currentDimension = UpperBound;
                else
                    _currentDimension = value;
            }

        }

        public void SetDimension(int newDimension)
        {
            CurrentDimension = newDimension;
        }

        public void IncreaseDimension()
        {
            if (CurrentDimension < UpperBound)
                CurrentDimension++;
        }


        public void DecreaseDimension()
        {
            if (CurrentDimension > LowerBound)
                CurrentDimension--;
        }
    }
}

