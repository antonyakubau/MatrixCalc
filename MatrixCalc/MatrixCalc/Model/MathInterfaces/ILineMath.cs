using System;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public interface ILineMath
	{
		int RefreshMax(int lineNum, List<List<InputEntry>> Lines);
        int RefreshMin(int lineNum, List<List<InputEntry>> Lines);
        int RefreshAverage(int lineNum, List<List<InputEntry>> Lines);
        int RefreshSum(int lineNum, List<List<InputEntry>> Lines);
    }
}

