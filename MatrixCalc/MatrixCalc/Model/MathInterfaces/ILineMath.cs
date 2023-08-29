using System;
namespace MatrixCalc.Model.MathInterfaces
{
	public interface ILineMath
	{
		int RefreshMax(int lineNum);
        int RefreshMin(int lineNum);
        int RefreshAverage(int lineNum);
        int RefreshSum(int lineNum);
    }
}

